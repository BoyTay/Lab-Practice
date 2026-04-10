package com.example.doichieudai;

import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {
    private String[] units = {
            "Hải lý", "Dặm", "Km", "Lý", "Met", "Yard", "Foot", "Inch"
    };

    private double[][] ratio = {
            { 1.00000000, 1.15077945, 1.85200000, 20.2537183, 1852.0000, 2025.37183, 6076.11549, 72913.38583 },
            { 0.86897624, 1.00000000, 1.60934400, 17.6000000, 1609.3440, 1760.00000, 5280.00000, 63360.00000 },
            { 0.53995680, 0.62137119, 1.00000000, 10.9361330, 1000.0000, 1093.61330, 3280.83990, 39370.07874 },
            { 0.04937365, 0.05681818, 0.09140000, 1.00000000,   91.4400,  100.00000,  300.00000,  3600.00000 },
            { 0.00053996, 0.00062137, 0.00100000, 0.01093610,   1.00000,    1.09361,    3.28084,    39.37008 },
            { 0.00049374, 0.00056818, 0.00091440, 0.01000000,   0.91440,    1.00000,    3.00000,    36.00000 },
            { 0.00016458, 0.00018939, 0.00030480, 0.00333330,   0.30480,    0.33333,    1.00000,    12.00000 },
            { 0.00001371, 0.00001578, 0.00002540, 0.00027780,   0.02540,    0.02778,    0.08333,     1.00000 }
    };

    // ③ Khai báo View
    private EditText txtNumber;
    private Spinner spnUnits;
    private TextView[] lblResults;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        txtNumber = findViewById(R.id.txtNumber);
        spnUnits  = findViewById(R.id.spnUnit);
        lblResults = new TextView[]{
                findViewById(R.id.lblHaiLy),
                findViewById(R.id.lblDam),
                findViewById(R.id.lblKm),
                findViewById(R.id.lblLy),
                findViewById(R.id.lblMet),
                findViewById(R.id.lblYard),
                findViewById(R.id.lblFoot),
                findViewById(R.id.lblInch)
        };
        ArrayAdapter<String> adapter = new ArrayAdapter<>(
                this,
                android.R.layout.simple_spinner_item,
                units
        );
        adapter.setDropDownViewResource(android.R.layout.simple_list_item_1);
        spnUnits.setAdapter(adapter);


        spnUnits.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int pos, long id) {
                changeLengthUnit();
            }
            @Override
            public void onNothingSelected(AdapterView<?> parent) { }
        });

        txtNumber.addTextChangedListener(new TextWatcher() {
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                changeLengthUnit();
            }
            @Override public void beforeTextChanged(CharSequence s, int start, int count, int after) { }
            @Override public void afterTextChanged(Editable s) { }
        });
    }

    private void changeLengthUnit() {
        int rowIdx = spnUnits.getSelectedItemPosition();
        if (rowIdx < 0) rowIdx = 0;

        String input = txtNumber.getText().toString();
        if (input.isEmpty()) input = "0";

        double number = Double.parseDouble(input);

        for (int i = 0; i < lblResults.length; i++) {
            double result = number * ratio[rowIdx][i];
            // Hiển thị 4 chữ số thập phân
            lblResults[i].setText(String.format("%.4f", result));
        }
    }
}