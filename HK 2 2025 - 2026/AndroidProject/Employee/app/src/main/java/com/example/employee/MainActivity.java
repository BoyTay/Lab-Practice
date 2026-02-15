package com.example.employee;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import androidx.activity.EdgeToEdge;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.List;

public class MainActivity extends AppCompatActivity {

    private ListView lvEmployees;
    private List<Employee> employeeList;
    private ArrayAdapter<Employee> adapter;
    private DatabaseHelper dbHelper;
    private static final int DETAIL_REQUEST_CODE = 1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);

        // Áp dụng padding cho system bars
        View mainLayout = findViewById(R.id.main);
        ViewCompat.setOnApplyWindowInsetsListener(mainLayout, (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        dbHelper = new DatabaseHelper(this);
        lvEmployees = findViewById(R.id.listview_employees);

        loadEmployeeData();

        // Yêu cầu c: Xử lý sự kiện nhấn lâu (Long Click)
        lvEmployees.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                Employee selectedEmployee = employeeList.get(position);

                Intent intent = new Intent(MainActivity.this, DetailActivity.class);
                intent.putExtra("employee", selectedEmployee); // Truyền đối tượng Employee
                startActivityForResult(intent, DETAIL_REQUEST_CODE);

                return true; // Đánh dấu sự kiện đã được xử lý
            }
        });
    }

    private void loadEmployeeData() {
        employeeList = dbHelper.getAllEmployees();
        adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, employeeList);
        lvEmployees.setAdapter(adapter);
    }

    // Cập nhật lại danh sách sau khi xóa ở DetailActivity
    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == DETAIL_REQUEST_CODE && resultCode == RESULT_OK) {
            // Tải lại dữ liệu từ CSDL và cập nhật ListView
            loadEmployeeData();
        }
    }
}
