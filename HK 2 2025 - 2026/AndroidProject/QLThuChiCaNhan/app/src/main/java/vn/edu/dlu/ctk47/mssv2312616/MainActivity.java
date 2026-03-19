package vn.edu.dlu.ctk47.mssv2312616;

import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private TextView tvCashBalance, tvBankBalance;
    private EditText etAmount, etDate;
    private Spinner spAccount, spCategory;
    private Button btnSave;
    private RecyclerView rvHistory;

    private TransactionDAO transactionDAO;
    private TransactionAdapter adapter;
    private List<Category> categories;
    private List<Account> accounts;
    private DecimalFormat df = new DecimalFormat("#,###đ");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        initViews();
        transactionDAO = new TransactionDAO(this);
        
        loadData();
        setupDatePicker();

        btnSave.setOnClickListener(v -> saveTransaction());
    }

    private void initViews() {
        tvCashBalance = findViewById(R.id.tvCashBalance);
        tvBankBalance = findViewById(R.id.tvBankBalance);
        etAmount = findViewById(R.id.etAmount);
        etDate = findViewById(R.id.etDate);
        spAccount = findViewById(R.id.spAccount);
        spCategory = findViewById(R.id.spCategory);
        btnSave = findViewById(R.id.btnSave);
        rvHistory = findViewById(R.id.rvHistory);
    }

    private void loadData() {
        accounts = transactionDAO.getAllAccounts();
        categories = transactionDAO.getAllCategories();
        List<Transaction> transactions = transactionDAO.getAllTransactions();

        for (Account a : accounts) {
            if (a.getName().equals("Tiền mặt")) tvCashBalance.setText(df.format(a.getBalance()));
            if (a.getName().equals("Ngân hàng")) tvBankBalance.setText(df.format(a.getBalance()));
        }

        List<String> accountNames = new ArrayList<>();
        for (Account a : accounts) accountNames.add(a.getName());
        spAccount.setAdapter(new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, accountNames));

        List<String> categoryNames = new ArrayList<>();
        for (Category c : categories) categoryNames.add(c.getName());
        spCategory.setAdapter(new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, categoryNames));

        adapter = new TransactionAdapter(transactions, categories, accounts, this::showEditDeleteDialog);
        rvHistory.setLayoutManager(new LinearLayoutManager(this));
        rvHistory.setAdapter(adapter);
    }

    private void setupDatePicker() {
        etDate.setOnClickListener(v -> {
            Calendar c = Calendar.getInstance();
            new DatePickerDialog(this, (view, year, month, dayOfMonth) -> {
                String date = String.format("%02d-%02d-%d", dayOfMonth, month + 1, year);
                etDate.setText(date);
            }, c.get(Calendar.YEAR), c.get(Calendar.MONTH), c.get(Calendar.DAY_OF_MONTH)).show();
        });
    }

    private void saveTransaction() {
        String amountStr = etAmount.getText().toString().replace(".", "").replace(",", "");
        String date = etDate.getText().toString();
        
        if (amountStr.isEmpty() || date.isEmpty()) {
            Toast.makeText(this, "Vui lòng nhập đầy đủ thông tin", Toast.LENGTH_SHORT).show();
            return;
        }

        try {
            double amount = Double.parseDouble(amountStr);
            int accIndex = spAccount.getSelectedItemPosition();
            int catIndex = spCategory.getSelectedItemPosition();

            int accId = accounts.get(accIndex).getId();
            int catId = categories.get(catIndex).getId();

            Transaction t = new Transaction(0, amount, date, catId, accId);
            if (transactionDAO.insertTransaction(t) > 0) {
                Toast.makeText(this, "Lưu thành công", Toast.LENGTH_SHORT).show();
                etAmount.setText("");
                etDate.setText("");
                loadData();
            }
        } catch (Exception e) {
            Toast.makeText(this, "Số tiền không hợp lệ", Toast.LENGTH_SHORT).show();
        }
    }

    private void showEditDeleteDialog(Transaction t) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Sửa/Xóa Giao dịch");

        View view = LayoutInflater.from(this).inflate(R.layout.dialog_edit_transaction, null);
        builder.setView(view);

        EditText edtAmount = view.findViewById(R.id.edtEditAmount);
        EditText edtDate = view.findViewById(R.id.edtEditDate);
        Spinner spnAccount = view.findViewById(R.id.spnEditAccount);
        Spinner spnCategory = view.findViewById(R.id.spnEditCategory);

        edtAmount.setText(String.valueOf((int) t.getAmount()));
        edtDate.setText(t.getDate());

        List<String> accountNames = new ArrayList<>();
        int accSelection = 0;
        for (int i = 0; i < accounts.size(); i++) {
            accountNames.add(accounts.get(i).getName());
            if (accounts.get(i).getId() == t.getAcc_id()) accSelection = i;
        }
        spnAccount.setAdapter(new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, accountNames));
        spnAccount.setSelection(accSelection);

        List<String> categoryNames = new ArrayList<>();
        int catSelection = 0;
        for (int i = 0; i < categories.size(); i++) {
            categoryNames.add(categories.get(i).getName());
            if (categories.get(i).getId() == t.getCat_id()) catSelection = i;
        }
        spnCategory.setAdapter(new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, categoryNames));
        spnCategory.setSelection(catSelection);

        edtDate.setOnClickListener(v -> {
            Calendar c = Calendar.getInstance();
            new DatePickerDialog(this, (view1, year, month, dayOfMonth) -> {
                String date = String.format("%02d-%02d-%d", dayOfMonth, month + 1, year);
                edtDate.setText(date);
            }, c.get(Calendar.YEAR), c.get(Calendar.MONTH), c.get(Calendar.DAY_OF_MONTH)).show();
        });

        builder.setPositiveButton("Cập nhật", (dialog, which) -> {
            String amountStr = edtAmount.getText().toString();
            String date = edtDate.getText().toString();
            if (!amountStr.isEmpty() && !date.isEmpty()) {
                double amount = Double.parseDouble(amountStr);
                int accId = accounts.get(spnAccount.getSelectedItemPosition()).getId();
                int catId = categories.get(spnCategory.getSelectedItemPosition()).getId();
                
                Transaction newT = new Transaction(t.getTrans_id(), amount, date, catId, accId);
                transactionDAO.updateTransaction(t, newT);
                loadData();
                Toast.makeText(this, "Đã cập nhật", Toast.LENGTH_SHORT).show();
            }
        });

        builder.setNegativeButton("Xóa", (dialog, which) -> {
            transactionDAO.deleteTransaction(t);
            loadData();
            Toast.makeText(this, "Đã xóa", Toast.LENGTH_SHORT).show();
        });

        builder.setNeutralButton("Hủy", null);
        builder.create().show();
    }
}
