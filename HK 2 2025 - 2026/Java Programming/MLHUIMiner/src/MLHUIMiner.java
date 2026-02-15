import javax.swing.*;
import javax.swing.border.TitledBorder;
import java.awt.*;
import java.util.*;
import java.util.List;

public class MLHUIMiner extends JFrame {

    private JTextArea txtTransactions, txtExternalUtility, txtTaxonomy, txtOutput;
    private JTextField txtMinUtil;

    // ===== DATA =====
    private List<Transaction> database = new ArrayList<>();
    private Map<String, Integer> extUtil = new HashMap<>();
    private Map<String, List<String>> taxonomy = new HashMap<>();

    // TWU + EUCS
    private Map<String, Integer> twuGlobal = new HashMap<>();
    private Map<String, Map<String, Integer>> EUCS = new HashMap<>();

    // =========================================================
    // ====================== GUI ==============================
    // =========================================================

    public MLHUIMiner() {

        setTitle("ML-HUI Miner – Paper Correct Version");
    setSize(1000, 700);
    setDefaultCloseOperation(EXIT_ON_CLOSE);
    setLocationRelativeTo(null);
    setLayout(new BorderLayout());

    // ===== INPUT AREAS =====
    JPanel input = new JPanel(new GridLayout(1, 3));

    txtTransactions = new JTextArea(
            "T1: Coke 2, Bread 2, Steak 1\n" +
            "T2: Water 3, Pasta 2, Steak 1\n" +
            "T3: Water 2, Bread 2\n" +
            "T4: Coke 1, Bread 2"
    );
    input.add(scroll(txtTransactions, "Transactions"));

    txtExternalUtility = new JTextArea(
            "Water: 1\nCoke: 5\nBread: 1\nPasta: 2\nSteak: 10"
    );
    input.add(scroll(txtExternalUtility, "External Utility"));

    txtTaxonomy = new JTextArea(
            "Beverage: Coke, Water\nFood: Bread, Pasta, Steak"
    );
    input.add(scroll(txtTaxonomy, "Taxonomy"));

    // ===== OUTPUT =====
    txtOutput = new JTextArea();
    txtOutput.setFont(new Font("Monospaced", Font.PLAIN, 13));
    txtOutput.setEditable(false);
    JScrollPane outputScroll = scroll(txtOutput, "Output");

    // ===== SPLIT PANE (KEY FIX) =====
    JSplitPane split = new JSplitPane(JSplitPane.VERTICAL_SPLIT, input, outputScroll);
    split.setResizeWeight(1);      // 70% trên, 30% dưới
    split.setDividerLocation(300);   // vị trí ban đầu

    add(split, BorderLayout.CENTER);

    // ===== NORTH BAR =====
    JPanel north = new JPanel();
    north.add(new JLabel("MinUtil:"));
    txtMinUtil = new JTextField("20", 5);
    north.add(txtMinUtil);

    JButton run = new JButton("RUN ML-HUI");
    north.add(run);

    add(north, BorderLayout.NORTH);

    run.addActionListener(e -> runMLHUI());
    }

    private JScrollPane scroll(JTextArea ta, String title) {
        JScrollPane sp = new JScrollPane(ta);
        sp.setBorder(new TitledBorder(title));
        return sp;
    }

    // =========================================================
    // ====================== MAIN =============================
    // =========================================================

    private void runMLHUI() {

        txtOutput.setText("");
        database.clear();
        extUtil.clear();
        taxonomy.clear();
        EUCS.clear();
        twuGlobal.clear();

        int minUtil = Integer.parseInt(txtMinUtil.getText().trim());

        parseExternalUtility();
        parseTaxonomy();
        parseTransactions();

        log("=== ML-HUI START (minutil=" + minUtil + ") ===");

        // 1️⃣ TWU
        twuGlobal = computeTWU();

        // 2️⃣ α(level)
        Map<Integer, Integer> levelThr = new HashMap<>();
        levelThr.put(0, minUtil);
        levelThr.put(1, (int) (1.5 * minUtil));

        // 3️⃣ Filter by TWU per level
        Map<Integer, List<String>> itemsByLevel = new HashMap<>();

        for (String item : twuGlobal.keySet()) {

            int level = taxonomy.containsKey(item) ? 1 : 0;

            if (twuGlobal.get(item) >= levelThr.get(level)) {
                itemsByLevel.computeIfAbsent(level, k -> new ArrayList<>()).add(item);
                log("[KEEP L" + level + "] " + item + " TWU=" + twuGlobal.get(item));
            }
        }

        // 4️⃣ Mine each level
        for (int level : itemsByLevel.keySet()) {

            log("\n--- DFS LEVEL " + level + " ---");

            List<UtilityList> ULs = buildUtilityLists(itemsByLevel.get(level));
            mine(new ArrayList<>(), ULs, levelThr.get(level));
        }
    }

    // =========================================================
    // ====================== DFS ==============================
    // =========================================================

    private void mine(List<String> prefix, List<UtilityList> ULs, int minUtil) {

        for (int i = 0; i < ULs.size(); i++) {

            UtilityList X = ULs.get(i);

            List<String> newPrefix = new ArrayList<>(prefix);
            newPrefix.add(X.item);

            // HUI check
            if (X.sumIutil >= minUtil)
                log("HUI " + newPrefix + " = " + X.sumIutil);

            // Upper-bound pruning
            if (X.sumIutil + X.sumRutil < minUtil)
                continue;

            List<UtilityList> exULs = new ArrayList<>();

            for (int j = i + 1; j < ULs.size(); j++) {

                UtilityList Y = ULs.get(j);

                // EUCS pruning
                if (EUCS.getOrDefault(X.item, Collections.emptyMap())
                        .getOrDefault(Y.item, 0) < minUtil)
                    continue;

                UtilityList XY = construct(X, Y);

                if (!XY.nodes.isEmpty())
                    exULs.add(XY);
            }

            mine(newPrefix, exULs, minUtil);
        }
    }

    // =========================================================
    // ====================== UTILITY LIST =====================
    // =========================================================

    private List<UtilityList> buildUtilityLists(List<String> items) {

        // 🔹 Sort by TWU ascending (CRITICAL in ML-HUI)
        items.sort(Comparator.comparingInt(a -> twuGlobal.getOrDefault(a, 0)));

        List<UtilityList> list = new ArrayList<>();
        Map<String, UtilityList> map = new HashMap<>();

        for (String i : items) {
            UtilityList ul = new UtilityList(i);
            list.add(ul);
            map.put(i, ul);
        }

        for (int tid = 0; tid < database.size(); tid++) {

            Transaction t = database.get(tid);

            List<String> present = new ArrayList<>();

            for (String i : items)
                if (utilityOf(i, t) > 0)
                    present.add(i);

            // 🔹 Sort present items by TWU
            present.sort(Comparator.comparingInt(a -> twuGlobal.getOrDefault(a, 0)));

            for (int i = 0; i < present.size(); i++) {

                String item = present.get(i);
                int iutil = utilityOf(item, t);

                int rutil = 0;
                for (int j = i + 1; j < present.size(); j++)
                    rutil += utilityOf(present.get(j), t);

                map.get(item).add(new ULNode(tid, iutil, rutil));

                // EUCS
                for (int j = i + 1; j < present.size(); j++) {

                    String b = present.get(j);

                    EUCS.computeIfAbsent(item, k -> new HashMap<>());
                    EUCS.get(item).put(b,
                            EUCS.get(item).getOrDefault(b, 0) + t.tu);
                }
            }
        }

        return list;
    }

    private UtilityList construct(UtilityList X, UtilityList Y) {

        UtilityList XY = new UtilityList(Y.item);

        int i = 0, j = 0;

        while (i < X.nodes.size() && j < Y.nodes.size()) {

            ULNode nx = X.nodes.get(i);
            ULNode ny = Y.nodes.get(j);

            if (nx.tid == ny.tid) {
                XY.add(new ULNode(nx.tid, nx.iutil + ny.iutil, ny.rutil));
                i++; j++;
            } else if (nx.tid < ny.tid) {
                i++;
            } else {
                j++;
            }
        }

        return XY;
    }

    // =========================================================
    // ====================== TWU ==============================
    // =========================================================

    private Map<String, Integer> computeTWU() {

        Map<String, Integer> map = new HashMap<>();

        for (Transaction t : database) {

            for (String i : t.items.keySet())
                map.put(i, map.getOrDefault(i, 0) + t.tu);

            for (String g : taxonomy.keySet())
                for (String c : taxonomy.get(g))
                    if (t.items.containsKey(c)) {
                        map.put(g, map.getOrDefault(g, 0) + t.tu);
                        break;
                    }
        }

        return map;
    }

    // =========================================================
    // ====================== UTILITY ==========================
    // =========================================================

    private int utilityOf(String item, Transaction t) {

        if (taxonomy.containsKey(item)) {
            int s = 0;
            for (String c : taxonomy.get(item))
                if (t.items.containsKey(c))
                    s += t.items.get(c) * extUtil.get(c);
            return s;
        }

        if (t.items.containsKey(item))
            return t.items.get(item) * extUtil.get(item);

        return 0;
    }

    // =========================================================
    // ====================== PARSE ============================
    // =========================================================

    private void parseTransactions() {

        for (String line : txtTransactions.getText().split("\n")) {

            if (line.trim().isEmpty()) continue;

            String[] p = line.split(":");
            Transaction t = new Transaction();

            for (String part : p[1].split(",")) {
                String[] s = part.trim().split(" ");
                t.add(s[0], Integer.parseInt(s[1]));
            }

            database.add(t);
        }
    }

    private void parseExternalUtility() {

        for (String l : txtExternalUtility.getText().split("\n")) {
            if (l.trim().isEmpty()) continue;

            String[] p = l.split(":");
            extUtil.put(p[0].trim(), Integer.parseInt(p[1].trim()));
        }
    }

    private void parseTaxonomy() {

        for (String l : txtTaxonomy.getText().split("\n")) {
            if (l.trim().isEmpty()) continue;

            String[] p = l.split(":");
            List<String> list = new ArrayList<>();

            for (String c : p[1].split(","))
                list.add(c.trim());

            taxonomy.put(p[0].trim(), list);
        }
    }

    private void log(String s) {
        txtOutput.append(s + "\n");
    }

    // =========================================================
    // ====================== DATA =============================
    // =========================================================

    class Transaction {
        Map<String, Integer> items = new HashMap<>();
        int tu = 0;

        void add(String name, int qty) {
            items.put(name, qty);
            tu += qty * extUtil.getOrDefault(name, 0);
        }
    }

    class ULNode {
        int tid, iutil, rutil;
        ULNode(int t, int i, int r) { tid = t; iutil = i; rutil = r; }
    }

    class UtilityList {
        String item;
        List<ULNode> nodes = new ArrayList<>();
        int sumIutil = 0, sumRutil = 0;

        UtilityList(String item) { this.item = item; }

        void add(ULNode n) {
            nodes.add(n);
            sumIutil += n.iutil;
            sumRutil += n.rutil;
        }
    }

    // =========================================================

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> new MLHUIMiner().setVisible(true));
    }
}
