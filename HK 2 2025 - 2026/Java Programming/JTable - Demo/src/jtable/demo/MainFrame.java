package jtable.demo;

import javax.swing.*;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.*;
import java.sql.*;
import java.util.Vector;

public class MainFrame extends JFrame {

    // --- KHAI BÁO CÁC COMPONENT GIAO DIỆN ---
    JTable tblSanPham;
    DefaultTableModel model;
    JTextField txtMaSP, txtTenSP, txtDonGia, txtNhaCC;
    JComboBox<String> cboDVT;
    JButton btnThem, btnXoa, btnSua;

    // --- CẤU HÌNH DATABASE ---
    String url = "jdbc:sqlserver://localhost:1433;databaseName=QuanLyBanHang;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";

    public MainFrame() {
        initComponents();
        loadDataToTable(); // Tự động tải dữ liệu khi mở phần mềm
    }

    // --- HÀM TẠO GIAO DIỆN (Được viết tay để giống ảnh) ---
    private void initComponents() {
        setTitle("JTABLE - DEMO");
        setSize(850, 600);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLocationRelativeTo(null); // Ra giữa màn hình
        setLayout(new BorderLayout());

        // 1. PHẦN TIÊU ĐỀ (MÀU HỒNG)
        JLabel lblTitle = new JLabel("Danh sách Sản Phẩm", JLabel.CENTER);
        lblTitle.setFont(new Font("Arial", Font.BOLD, 24));
        lblTitle.setForeground(Color.BLUE);
        lblTitle.setOpaque(true);
        lblTitle.setBackground(Color.MAGENTA); // Màu hồng đậm giống ảnh
        lblTitle.setPreferredSize(new Dimension(800, 50));
        add(lblTitle, BorderLayout.NORTH);

        // 2. PHẦN BẢNG (CENTER)
        String[] columns = {"Mã SP", "Tên SP", "DVT", "Đơn giá bán", "Nhà Cung Cấp"};
        model = new DefaultTableModel(columns, 0);
        tblSanPham = new JTable(model);
        tblSanPham.setRowHeight(25);
        
        // Sự kiện click chuột vào bảng
        tblSanPham.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                fillDataToForm();
            }
        });
        add(new JScrollPane(tblSanPham), BorderLayout.CENTER);

        // 3. PHẦN FORM NHẬP LIỆU & NÚT BẤM (SOUTH)
        JPanel pnlSouth = new JPanel();
        pnlSouth.setLayout(new BorderLayout());
        pnlSouth.setBackground(new Color(255, 255, 204)); // Màu vàng nhạt giống ảnh

        // 3a. Form nhập liệu
        JPanel pnlInput = new JPanel(new GridBagLayout());
        pnlInput.setBackground(new Color(255, 255, 204)); // Nền vàng
        pnlInput.setBorder(BorderFactory.createEmptyBorder(10, 20, 10, 20));
        
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(5, 5, 5, 5); // Khoảng cách giữa các ô
        gbc.fill = GridBagConstraints.HORIZONTAL;

        // Cột 1: Mã SP, Tên SP, ĐVT
        gbc.gridx = 0; gbc.gridy = 0; pnlInput.add(new JLabel("Mã sản phẩm:"), gbc);
        txtMaSP = new JTextField(15);
        gbc.gridx = 1; gbc.gridy = 0; pnlInput.add(txtMaSP, gbc);

        gbc.gridx = 0; gbc.gridy = 1; pnlInput.add(new JLabel("Tên sản phẩm:"), gbc);
        txtTenSP = new JTextField(15);
        gbc.gridx = 1; gbc.gridy = 1; pnlInput.add(txtTenSP, gbc);

        gbc.gridx = 0; gbc.gridy = 2; pnlInput.add(new JLabel("Đơn vị tính:"), gbc);
        String[] dvt = {"Chai", "Thùng", "Kg", "Lon", "Gói"};
        cboDVT = new JComboBox<>(dvt);
        gbc.gridx = 1; gbc.gridy = 2; pnlInput.add(cboDVT, gbc);

        // Cột 2: Đơn giá, Nhà cung cấp (Cách ra một chút)
        gbc.gridx = 2; gbc.gridy = 0; pnlInput.add(new JLabel("        Đơn giá:"), gbc);
        txtDonGia = new JTextField(15);
        gbc.gridx = 3; gbc.gridy = 0; pnlInput.add(txtDonGia, gbc);

        gbc.gridx = 2; gbc.gridy = 1; pnlInput.add(new JLabel("        Nhà cung cấp:"), gbc);
        txtNhaCC = new JTextField(15);
        gbc.gridx = 3; gbc.gridy = 1; pnlInput.add(txtNhaCC, gbc);

        pnlSouth.add(pnlInput, BorderLayout.CENTER);

        // 3b. Panel chứa nút bấm
        JPanel pnlButtons = new JPanel(new FlowLayout(FlowLayout.CENTER, 20, 10));
        pnlButtons.setBackground(new Color(0, 100, 0)); // Nền xanh đậm phía dưới
        
        btnThem = new JButton("Thêm Sản Phẩm");
        btnXoa = new JButton("Xóa Sản Phẩm");
        btnSua = new JButton("Điều chỉnh thông tin");
        
        // Sự kiện nút bấm
        btnThem.addActionListener(e -> addProduct());
        btnXoa.addActionListener(e -> deleteProduct());
        btnSua.addActionListener(e -> updateProduct());

        pnlButtons.add(btnThem);
        pnlButtons.add(btnXoa);
        pnlButtons.add(btnSua);

        pnlSouth.add(pnlButtons, BorderLayout.SOUTH);
        
        add(pnlSouth, BorderLayout.SOUTH);
    }

    // --- CÁC HÀM XỬ LÝ LOGIC ---

    // 1. Đổ dữ liệu từ bảng lên ô nhập
    private void fillDataToForm() {
        int row = tblSanPham.getSelectedRow();
        if (row >= 0) {
            txtMaSP.setText(model.getValueAt(row, 0).toString());
            txtTenSP.setText(model.getValueAt(row, 1).toString());
            cboDVT.setSelectedItem(model.getValueAt(row, 2).toString());
            txtDonGia.setText(model.getValueAt(row, 3).toString());
            txtNhaCC.setText(model.getValueAt(row, 4).toString());
        }
    }

    // 2. Tải dữ liệu từ SQL lên bảng
    private void loadDataToTable() {
        model.setRowCount(0);
        try (Connection conn = DriverManager.getConnection(url);
             Statement stmt = conn.createStatement();
             ResultSet rs = stmt.executeQuery("SELECT * FROM SanPham")) {
             
            while (rs.next()) {
                Vector<Object> row = new Vector<>();
                row.add(rs.getString("MaSP"));
                row.add(rs.getString("TenSP"));
                row.add(rs.getString("DVT"));
                row.add(rs.getDouble("DonGia"));
                row.add(rs.getString("NhaCungCap"));
                model.addRow(row);
            }
        } catch (Exception e) {
            System.out.println("Lỗi tải dữ liệu (Kiểm tra lại kết nối SQL): " + e.getMessage());
        }
    }

    // 3. Thêm
    private void addProduct() {
        try (Connection conn = DriverManager.getConnection(url);
             PreparedStatement ps = conn.prepareStatement("INSERT INTO SanPham VALUES (?, ?, ?, ?, ?)")) {
            
            ps.setString(1, txtMaSP.getText());
            ps.setString(2, txtTenSP.getText());
            ps.setString(3, cboDVT.getSelectedItem().toString());
            ps.setDouble(4, Double.parseDouble(txtDonGia.getText()));
            ps.setString(5, txtNhaCC.getText());
            
            ps.executeUpdate();
            loadDataToTable();
            JOptionPane.showMessageDialog(this, "Thêm thành công!");
            clearForm();
        } catch (Exception e) {
            JOptionPane.showMessageDialog(this, "Lỗi thêm: " + e.getMessage());
        }
    }

    // 4. Xóa
    private void deleteProduct() {
        if (txtMaSP.getText().isEmpty()) {
            JOptionPane.showMessageDialog(this, "Vui lòng chọn sản phẩm cần xóa!");
            return;
        }
        int confirm = JOptionPane.showConfirmDialog(this, "Bạn có chắc muốn xóa không?", "Xác nhận", JOptionPane.YES_NO_OPTION);
        if (confirm == JOptionPane.YES_OPTION) {
            try (Connection conn = DriverManager.getConnection(url);
                 PreparedStatement ps = conn.prepareStatement("DELETE FROM SanPham WHERE MaSP = ?")) {
                
                ps.setString(1, txtMaSP.getText());
                ps.executeUpdate();
                loadDataToTable();
                JOptionPane.showMessageDialog(this, "Xóa thành công!");
                clearForm();
            } catch (Exception e) {
                JOptionPane.showMessageDialog(this, "Lỗi xóa: " + e.getMessage());
            }
        }
    }

    // 5. Sửa
    private void updateProduct() {
        try (Connection conn = DriverManager.getConnection(url);
             PreparedStatement ps = conn.prepareStatement("UPDATE SanPham SET TenSP=?, DVT=?, DonGia=?, NhaCungCap=? WHERE MaSP=?")) {
            
            ps.setString(1, txtTenSP.getText());
            ps.setString(2, cboDVT.getSelectedItem().toString());
            ps.setDouble(3, Double.parseDouble(txtDonGia.getText()));
            ps.setString(4, txtNhaCC.getText());
            ps.setString(5, txtMaSP.getText());
            
            ps.executeUpdate();
            loadDataToTable();
            JOptionPane.showMessageDialog(this, "Cập nhật thành công!");
        } catch (Exception e) {
            JOptionPane.showMessageDialog(this, "Lỗi cập nhật: " + e.getMessage());
        }
    }

    // Hàm xóa trắng form
    private void clearForm() {
        txtMaSP.setText("");
        txtTenSP.setText("");
        txtDonGia.setText("");
        txtNhaCC.setText("");
        cboDVT.setSelectedIndex(0);
    }

    // Hàm Main để chạy chương trình
    public static void main(String[] args) {
        try {
            // Chỉnh giao diện cho đẹp (Windows style)
            UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
        } catch (Exception e) {}
        
        SwingUtilities.invokeLater(() -> new MainFrame().setVisible(true));
    }
}