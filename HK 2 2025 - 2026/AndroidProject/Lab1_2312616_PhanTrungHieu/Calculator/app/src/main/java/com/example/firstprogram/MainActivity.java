package com.example.firstprogram;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {
    EditText txtX,txtY;
    TextView txtResult;
    Button btnPlus;
    Button btnMinus;
    Button btnMultiply;
    Button btnDivide;
    Button btnModulo;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        innitControl();

    }
    private void innitControl(){
        txtX = findViewById(R.id.txtX);
        txtY = findViewById(R.id.txtY);
        txtResult = findViewById(R.id.txtResult);
        btnPlus = findViewById(R.id.btnPlus);
        btnMinus = findViewById(R.id.btnMinus);
        btnMultiply = findViewById(R.id.btnMultiply);
        btnDivide = findViewById(R.id.btnDivide);
        btnModulo = findViewById(R.id.btnModulo);

        btnPlus.setOnClickListener(v -> calculate("+"));
        btnMinus.setOnClickListener(v -> calculate("-"));
        btnMultiply.setOnClickListener(v -> calculate("*"));
        btnDivide.setOnClickListener(v -> calculate("/"));
        btnModulo.setOnClickListener(v -> calculate("%"));
    }
    private void calculate(String operator) {
        if (txtX.getText().toString().isEmpty() || txtY.getText().toString().isEmpty()) {
            txtResult.setText("Vui lòng nhập đủ số");
            return;
        }

        double x = Double.parseDouble(txtX.getText().toString());
        double y = Double.parseDouble(txtY.getText().toString());
        double result;

        switch (operator) {
            case "+":
                result = x + y;
                break;
            case "-":
                result = x - y;
                break;
            case "*":
                result = x * y;
                break;
            case "/":
                if (y == 0) {
                    txtResult.setText("Không chia cho 0");
                    return;
                }
                result = x / y;
                break;
            case "%":
                if (y == 0) {
                    txtResult.setText("Không chia cho 0");
                    return;
                }
                result = x % y;
                break;
            default:
                return;
        }

        txtResult.setText("Kết quả: " + result);
    }
}