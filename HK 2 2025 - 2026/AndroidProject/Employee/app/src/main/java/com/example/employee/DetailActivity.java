package com.example.employee;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class DetailActivity extends AppCompatActivity {

    private TextView tvCode, tvName, tvAge;
    private Button btnDelete, btnBack;
    private DatabaseHelper dbHelper;
    private Employee employee;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detail);

        dbHelper = new DatabaseHelper(this);

        tvCode = findViewById(R.id.tv_code);
        tvName = findViewById(R.id.tv_name);
        tvAge = findViewById(R.id.tv_age);
        btnDelete = findViewById(R.id.btn_delete);
        btnBack = findViewById(R.id.btn_back);

        // Nhận đối tượng Employee từ Intent
        Intent intent = getIntent();
        if (intent != null && intent.hasExtra("employee")) {
            employee = (Employee) intent.getSerializableExtra("employee");
            if (employee != null) {
                // Hiển thị thông tin
                tvCode.setText(employee.getCode());
                tvName.setText(employee.getName());
                tvAge.setText(String.valueOf(employee.getAge()));
            }
        }

        // Sự kiện nút Xóa
        btnDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (employee != null) {
                    dbHelper.deleteEmployee(employee);
                    // Gửi kết quả về MainActivity để nó biết cần cập nhật lại danh sách
                    setResult(Activity.RESULT_OK);
                    finish(); // Đóng DetailActivity
                }
            }
        });

        // Sự kiện nút Trở về
        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish(); // Chỉ cần đóng Activity hiện tại
            }
        });
    }
}