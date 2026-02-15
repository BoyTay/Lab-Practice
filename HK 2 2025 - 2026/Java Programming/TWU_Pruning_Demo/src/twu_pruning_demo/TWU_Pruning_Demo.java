import java.util.*;
import java.io.PrintStream;
import java.nio.charset.StandardCharsets;

public class TWU_Pruning_Demo {

    // Cấu trúc đơn giản để lưu Item và Utility của nó trong giao dịch
    static class ItemEntry {
        String name;
        int utility;
        public ItemEntry(String name, int utility) { this.name = name; this.utility = utility; }
    }

    // Giao dịch lưu danh sách Item và TỔNG giá trị giao dịch (Transaction Utility)
    static class Transaction {
        String id;
        List<ItemEntry> items = new ArrayList<>();
        int transactionUtility = 0; // Tổng tiền của cả giỏ hàng

        public Transaction(String id) { this.id = id; }

        public void addItem(String name, int quantity, int unitProfit) {
            int util = quantity * unitProfit;
            items.add(new ItemEntry(name, util));
            transactionUtility += util; // Cộng dồn vào tổng giỏ hàng
        }
    }

    public static void main(String[] args) {
        System.setOut(new PrintStream(System.out, true, StandardCharsets.UTF_8));
        // --- 1. NHẬP DỮ LIỆU TỪ BẢI BÁO (Bảng 1 & 2) ---
        List<Transaction> database = new ArrayList<>();

        // TId1: Coke(2x5=10), Bread(2x1=2), Steak(1x10=10) -> TU = 22
        Transaction t1 = new Transaction("TId1");
        t1.addItem("Coke", 2, 5); t1.addItem("Bread", 2, 1); t1.addItem("Steak", 1, 10);
        database.add(t1);

        // TId2: Water(3x1=3), Pasta(2x2=4), Steak(1x10=10) -> TU = 17
        Transaction t2 = new Transaction("TId2");
        t2.addItem("Water", 3, 1); t2.addItem("Pasta", 2, 2); t2.addItem("Steak", 1, 10);
        database.add(t2);

        // TId3: Water(2x1=2), Bread(2x1=2) -> TU = 4
        Transaction t3 = new Transaction("TId3");
        t3.addItem("Water", 2, 1); t3.addItem("Bread", 2, 1);
        database.add(t3);

        // TId4: Coke(1x5=5), Bread(2x1=2) -> TU = 7
        Transaction t4 = new Transaction("TId4");
        t4.addItem("Coke", 1, 5); t4.addItem("Bread", 2, 1);
        database.add(t4);

        System.out.println("=== 1. TỔNG GIÁ TRỊ TỪNG GIAO DỊCH (Transaction Utility) ===");
        for (Transaction t : database) {
            System.out.println(t.id + ": " + t.transactionUtility);
        }

        // --- 2. TÍNH TWU CHO TỪNG MÓN (Bước chuẩn bị của Thuật toán) ---
        // TWU(Item A) = Tổng TransactionUtility của TẤT CẢ giao dịch có chứa A
        Map<String, Integer> twuMap = new HashMap<>();
        
        for (Transaction t : database) {
            for (ItemEntry item : t.items) {
                // Nếu giao dịch t có chứa item, cộng TransactionUtility của t vào TWU của item
                int currentTwu = twuMap.getOrDefault(item.name, 0);
                twuMap.put(item.name, currentTwu + t.transactionUtility);
            }
        }

        System.out.println("\n=== 2. GIÁ TRỊ TWU CỦA TỪNG MÓN ===");
        // In kết quả
        for (String item : twuMap.keySet()) {
            System.out.println("Item: " + item + " | TWU: " + twuMap.get(item));
        }

        // --- 3. MINH HỌA CẮT TỈA (PRUNING) ---
        // Giả sử ta đặt ngưỡng minutil = 30 (như Bảng 4)
        int minUtil = 20;
        System.out.println("\n=== 3. QUYẾT ĐỊNH CẮT TỈA (MinUtil = " + minUtil + ") ===");
        
        for (String item : twuMap.keySet()) {
            int twu = twuMap.get(item);
            if (twu < minUtil) {
                System.out.println("X LOẠI BỎ (Prune): " + item + " (TWU " + twu + " < " + minUtil + ")");
                System.out.println("   -> Không cần tốn công tính toán tổ hợp chứa " + item + " nữa.");
            } else {
                System.out.println("V GIỮ LẠI (Keep):  " + item + " (TWU " + twu + " >= " + minUtil + ")");
            }
        }
    }
}