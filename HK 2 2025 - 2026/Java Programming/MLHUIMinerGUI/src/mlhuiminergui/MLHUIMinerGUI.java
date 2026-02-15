import javax.swing.*;
import javax.swing.border.TitledBorder;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.*;
import java.util.List;

public class MLHUIMinerGUI extends JFrame {

    // Components giao diện
    private JTextArea txtTransactions, txtExternalUtility, txtTaxonomy, txtOutput;
    private JTextField txtMinUtil;
    private JButton btnRun;

    // Dữ liệu nội bộ
    private List<Transaction> database = new ArrayList<>();
    private Map<String, Integer> externalUtilityMap = new HashMap<>();
    private Map<String, List<String>> taxonomyMap = new HashMap<>();

    public MLHUIMinerGUI() {
        // Cấu hình cửa sổ chính
        setTitle("ML-HUI Miner Tool - Mô phỏng thuật toán");
        setSize(1000, 700);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        setLayout(new BorderLayout(10, 10));

        // --- PHẦN 1: KHU VỰC NHẬP LIỆU (INPUT PANEL) ---
        JPanel pnlInput = new JPanel(new GridLayout(1, 3, 5, 5));
        pnlInput.setBorder(new TitledBorder("Dữ liệu đầu vào (Edit để test case khác)"));

        // 1.1 Nhập Giao dịch
        txtTransactions = new JTextArea();
        txtTransactions.setText("TId1: Coke 2, Bread 2, Steak 1\n" +
                "TId2: Water 3, Pasta 2, Steak 1\n" +
                "TId3: Water 2, Bread 2\n" +
                "TId4: Coke 1, Bread 2");
        pnlInput.add(createScrollPanel(txtTransactions, "1. Giao dịch (Format: ID: Item SL, ...)"));

        // 1.2 Nhập Giá/Lợi nhuận
        txtExternalUtility = new JTextArea();
        txtExternalUtility.setText("Water: 1\nCoke: 5\nBread: 1\nPasta: 2\nSteak: 10");
        pnlInput.add(createScrollPanel(txtExternalUtility, "2. Lợi nhuận đơn vị (External Utility)"));

        // 1.3 Nhập Phân loại
        txtTaxonomy = new JTextArea();
        txtTaxonomy.setText("Beverage: Coke, Water\nFood: Bread, Pasta, Steak");
        pnlInput.add(createScrollPanel(txtTaxonomy, "3. Phân loại (Taxonomy)"));

        add(pnlInput, BorderLayout.CENTER);

        // --- PHẦN 2: KHU VỰC ĐIỀU KHIỂN (CONTROL PANEL) ---
        JPanel pnlControl = new JPanel(new FlowLayout(FlowLayout.CENTER, 20, 10));
        pnlControl.add(new JLabel("Ngưỡng MinUtil:"));
        txtMinUtil = new JTextField("20", 5);
        pnlControl.add(txtMinUtil);

        btnRun = new JButton("CHẠY THUẬT TOÁN");
        btnRun.setFont(new Font("Arial", Font.BOLD, 14));
        btnRun.setBackground(new Color(70, 130, 180));
        btnRun.setForeground(Color.WHITE);
        pnlControl.add(btnRun);

        add(pnlControl, BorderLayout.NORTH);

        // --- PHẦN 3: KHU VỰC KẾT QUẢ (OUTPUT PANEL) ---
        txtOutput = new JTextArea();
        txtOutput.setEditable(false);
        txtOutput.setFont(new Font("Monospaced", Font.PLAIN, 13));
        JScrollPane scrollOutput = new JScrollPane(txtOutput);
        scrollOutput.setBorder(new TitledBorder("Kết quả Phân tích & Log Thuật toán"));
        scrollOutput.setPreferredSize(new Dimension(1000, 300));
        add(scrollOutput, BorderLayout.SOUTH);

        // --- SỰ KIỆN NÚT BẤM ---
        btnRun.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                runMiner();
            }
        });
    }

    private JScrollPane createScrollPanel(JTextArea textArea, String title) {
        JScrollPane scroll = new JScrollPane(textArea);
        scroll.setBorder(new TitledBorder(title));
        return scroll;
    }

    // --- LOGIC CHÍNH: XỬ LÝ DỮ LIỆU VÀ TÍNH TOÁN ---
    private void runMiner() {
        txtOutput.setText(""); // Xóa log cũ
        database.clear();
        externalUtilityMap.clear();
        taxonomyMap.clear();

        try {
            int minUtil = Integer.parseInt(txtMinUtil.getText().trim());
            log("=== BẮT ĐẦU QUÁ TRÌNH KHAI PHÁ (MinUtil = " + minUtil + ") ===");

            // BƯỚC 1: PARSE DỮ LIỆU TỪ GIAO DIỆN
            parseExternalUtility();
            parseTaxonomy();
            parseTransactions();

            // BƯỚC 2: TÍNH TOÁN TWU (Transaction-Weighted Utility)
            log("\n--- BƯỚC 1: TÍNH TWU ĐỂ LỌC ỨNG VIÊN ---");
            Map<String, Integer> twuMap = calculateTWU();
            List<String> validItems = new ArrayList<>();

            for (Map.Entry<String, Integer> entry : twuMap.entrySet()) {
                String item = entry.getKey();
                int twu = entry.getValue();
                // Logic lọc theo bài báo: Nếu TWU < MinUtil -> Loại
                if (twu >= minUtil) {
                    validItems.add(item);
                    log("[GIỮ] " + item + " (TWU: " + twu + ")");
                } else {
                    log("[LOẠI] " + item + " (TWU: " + twu + " < " + minUtil + ")");
                }
            }

            // BƯỚC 3: KHAI PHÁ HUI (Level 0 - Sản phẩm cụ thể)
            log("\n--- BƯỚC 2: TÌM HUI (Level 0 - Sản phẩm lẻ) ---");
            // Ở đây demo kiểm tra các tập phổ biến từ các item hợp lệ
            // (Trong thực tế thuật toán sẽ dùng DFS, ở đây ta test các tổ hợp tiềm năng để minh họa)
            checkSpecificCombinations(minUtil, false);

            // BƯỚC 4: KHAI PHÁ GHUI (Level 1 - Nhóm hàng)
            log("\n--- BƯỚC 3: TÌM GHUI (Level 1 - Tổng quát hóa) ---");
            checkSpecificCombinations(minUtil, true);


        } catch (Exception e) {
            log("LỖI: Kiểm tra lại dữ liệu nhập vào!\n" + e.getMessage());
            e.printStackTrace();
        }
    }

    // Hàm kiểm tra các tổ hợp (Mô phỏng quá trình Mining)
    private void checkSpecificCombinations(int minUtil, boolean isGeneralized) {
        // Tạo danh sách các ứng viên để kiểm tra (Dựa trên testcase bài báo)
        List<List<String>> candidates = new ArrayList<>();

        if (!isGeneralized) {
            // Level 0 Candidates
            candidates.add(Arrays.asList("Steak"));
            candidates.add(Arrays.asList("Water")); // Test case quan trọng: TWU đậu nhưng Utility rớt
            candidates.add(Arrays.asList("Bread"));
            candidates.add(Arrays.asList("Coke", "Bread"));
            candidates.add(Arrays.asList("Steak", "Coke"));
        } else {
            // Level 1 Candidates
            candidates.add(Arrays.asList("Food"));
            candidates.add(Arrays.asList("Beverage"));
            candidates.add(Arrays.asList("Food", "Beverage"));
        }

        for (List<String> candidate : candidates) {
            int utility = calculateActualUtility(candidate);
            String status = (utility >= minUtil) ? ">>> HUI/GHUI (ĐẠT)" : "--- Rớt";
            log(String.format("Xét tập %-20s | Lợi nhuận thực: %3d | %s", candidate.toString(), utility, status));
        }
    }

    // --- CÁC HÀM HỖ TRỢ TÍNH TOÁN (CORE ALGORITHM) ---

    // Tính TWU cho cả Item thường và Group
    private Map<String, Integer> calculateTWU() {
        Map<String, Integer> twuMap = new HashMap<>();

        for (Transaction t : database) {
            int tUtility = t.transactionUtility;

            // 1. Cộng TWU cho item thường có trong giao dịch
            for (String item : t.items.keySet()) {
                twuMap.put(item, twuMap.getOrDefault(item, 0) + tUtility);
            }

            // 2. Cộng TWU cho Group (Nếu giao dịch chứa con của Group)
            for (String group : taxonomyMap.keySet()) {
                boolean containsChild = false;
                for (String child : taxonomyMap.get(group)) {
                    if (t.items.containsKey(child)) {
                        containsChild = true;
                        break;
                    }
                }
                if (containsChild) {
                    twuMap.put(group, twuMap.getOrDefault(group, 0) + tUtility);
                }
            }
        }
        return twuMap;
    }

    // Tính lợi nhuận thực tế (Actual Utility) của một tập itemset
    private int calculateActualUtility(List<String> itemset) {
        int totalUtility = 0;
        for (Transaction t : database) {
            int currentTransUtil = 0;
            boolean match = true;
            for (String item : itemset) {
                int u = getUtilityOfItemInTransaction(item, t);
                if (u == 0) {
                    match = false;
                    break;
                }
                currentTransUtil += u;
            }
            if (match) {
                totalUtility += currentTransUtil;
            }
        }
        return totalUtility;
    }

    // Lấy lợi nhuận của 1 item (hoặc group) trong 1 giao dịch cụ thể
    private int getUtilityOfItemInTransaction(String item, Transaction t) {
        // Nếu là Group (Food, Beverage)
        if (taxonomyMap.containsKey(item)) {
            int sum = 0;
            boolean hasChild = false;
            for (String child : taxonomyMap.get(item)) {
                if (t.items.containsKey(child)) {
                    sum += t.items.get(child) * externalUtilityMap.getOrDefault(child, 0);
                    hasChild = true;
                }
            }
            return hasChild ? sum : 0; // Trả về tổng tiền của các con trong group
        }
        // Nếu là Item thường (Coke, Water)
        else if (t.items.containsKey(item)) {
            return t.items.get(item) * externalUtilityMap.getOrDefault(item, 0);
        }
        return 0;
    }

    // --- CÁC HÀM PARSE DỮ LIỆU TỪ TEXT AREA ---
    private void parseTransactions() {
        String text = txtTransactions.getText();
        for (String line : text.split("\n")) {
            if (line.trim().isEmpty()) continue;
            // TId1: Coke 2, Bread 2
            String[] parts = line.split(":");
            String id = parts[0].trim();
            Transaction t = new Transaction(id);
            
            String[] items = parts[1].split(",");
            for (String itemPart : items) {
                String[] i = itemPart.trim().split(" ");
                String name = i[0].trim();
                int qty = Integer.parseInt(i[1].trim());
                int price = externalUtilityMap.getOrDefault(name, 0);
                t.addItem(name, qty, price);
            }
            database.add(t);
        }
    }

    private void parseExternalUtility() {
        for (String line : txtExternalUtility.getText().split("\n")) {
            if (line.trim().isEmpty()) continue;
            String[] parts = line.split(":");
            externalUtilityMap.put(parts[0].trim(), Integer.parseInt(parts[1].trim()));
        }
    }

    private void parseTaxonomy() {
        for (String line : txtTaxonomy.getText().split("\n")) {
            if (line.trim().isEmpty()) continue;
            String[] parts = line.split(":");
            String group = parts[0].trim();
            String[] children = parts[1].split(",");
            List<String> childList = new ArrayList<>();
            for (String c : children) childList.add(c.trim());
            taxonomyMap.put(group, childList);
        }
    }

    private void log(String msg) {
        txtOutput.append(msg + "\n");
    }

    // Lớp Transaction nội bộ
    class Transaction {
        String id;
        Map<String, Integer> items = new HashMap<>();
        int transactionUtility = 0;

        public Transaction(String id) { this.id = id; }
        public void addItem(String name, int qty, int price) {
            items.put(name, qty);
            transactionUtility += (qty * price);
        }
    }

    public static void main(String[] args) {
        // Chạy GUI trên luồng Event Dispatch
        SwingUtilities.invokeLater(() -> {
            new MLHUIMinerGUI().setVisible(true);
        });
    }
}