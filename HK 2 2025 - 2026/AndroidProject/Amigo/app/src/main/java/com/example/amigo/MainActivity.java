package com.example.amigo;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;

import com.example.amigo.Amigo;
import com.example.amigo.R;
import com.example.amigo.SQLiteHelper;

import java.util.List;

public class MainActivity extends AppCompatActivity {

    EditText edtId, edtName, edtPhone;
    Button btnAdd, btnUpdate, btnDelete, btnView;
    TextView txtResult;
    SQLiteHelper dbHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // 1. Ánh xạ View
        edtId = findViewById(R.id.edtId);
        edtName = findViewById(R.id.edtName);
        edtPhone = findViewById(R.id.edtPhone);
        btnAdd = findViewById(R.id.btnAdd);
        btnUpdate = findViewById(R.id.btnUpdate);
        btnDelete = findViewById(R.id.btnDelete);
        btnView = findViewById(R.id.btnView);
        txtResult = findViewById(R.id.txtResult);

        // 2. Khởi tạo Database Helper
        dbHelper = new SQLiteHelper(this);
        dbHelper.openDB(); // Mở kết nối

        // 3. Sự kiện nút THÊM
        btnAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    int id = Integer.parseInt(edtId.getText().toString());
                    String name = edtName.getText().toString();
                    String phone = edtPhone.getText().toString();

                    Amigo amigo = new Amigo(id, name, phone);
                    dbHelper.insert(amigo); // Gọi hàm insert bên Helper

                    Toast.makeText(MainActivity.this, "Đã thêm thành công!", Toast.LENGTH_SHORT).show();
                    loadData(); // Load lại danh sách để xem
                } catch (Exception e) {
                    Toast.makeText(MainActivity.this, "Lỗi: Vui lòng nhập ID là số", Toast.LENGTH_SHORT).show();
                }
            }
        });

        // 4. Sự kiện nút XEM DANH SÁCH
        btnView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                loadData();
            }
        });

        // 5. Sự kiện nút XÓA (theo ID)
        btnDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    int id = Integer.parseInt(edtId.getText().toString());
                    dbHelper.delete(id); // Gọi hàm delete bên Helper
                    Toast.makeText(MainActivity.this, "Đã xóa ID: " + id, Toast.LENGTH_SHORT).show();
                    loadData();
                } catch (Exception e) {
                    Toast.makeText(MainActivity.this, "Nhập ID để xóa", Toast.LENGTH_SHORT).show();
                }
            }
        });

        // 6. Sự kiện nút SỬA (theo ID)
        btnUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    int id = Integer.parseInt(edtId.getText().toString());
                    String name = edtName.getText().toString();
                    String phone = edtPhone.getText().toString();

                    Amigo amigo = new Amigo(id, name, phone);
                    dbHelper.update(amigo); // Gọi hàm update bên Helper
                    Toast.makeText(MainActivity.this, "Đã sửa ID: " + id, Toast.LENGTH_SHORT).show();
                    loadData();
                } catch (Exception e) {
                    Toast.makeText(MainActivity.this, "Nhập đủ thông tin để sửa", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    // Hàm phụ để hiển thị danh sách lên màn hình
    private void loadData() {
        List<Amigo> list = dbHelper.getAll(); // Gọi hàm getAll bên Helper
        StringBuilder builder = new StringBuilder();

        for (Amigo a : list) {
            builder.append("ID: ").append(a.recID)
                    .append(" - Tên: ").append(a.name)
                    .append(" - SĐT: ").append(a.phone)
                    .append("\n-----------------\n");
        }
        txtResult.setText(builder.toString());
    }
}