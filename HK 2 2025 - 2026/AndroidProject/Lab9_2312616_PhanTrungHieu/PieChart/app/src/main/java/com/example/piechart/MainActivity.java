package com.example.piechart;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {
    PieChartView pieChart;
    Button btnDraw;
    EditText edtValues;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        pieChart  = findViewById(R.id.pieChart);
        btnDraw   = findViewById(R.id.btnDraw);
        edtValues = findViewById(R.id.edtValues);

        btnDraw.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String input = edtValues.getText().toString().trim();

                // Nếu để trống thì dùng dữ liệu mặc định
                if (input.isEmpty()) {
                    pieChart.invalidate();
                    return;
                }

                // Tách chuỗi thành mảng số
                String[] parts = input.split(",");
                float[] newValues = new float[parts.length];
                String[] newLabels = new String[parts.length];

                try {
                    for (int i = 0; i < parts.length; i++) {
                        newValues[i] = Float.parseFloat(parts[i].trim());
                        newLabels[i] = parts[i].trim();
                    }
                } catch (NumberFormatException e) {
                    edtValues.setError("Chỉ nhập số và dấu phẩy!");
                    return;
                }

                // Cập nhật dữ liệu và vẽ lại
                pieChart.values = newValues;
                pieChart.labels = newLabels;
                pieChart.invalidate();
            }
        });
    }
}