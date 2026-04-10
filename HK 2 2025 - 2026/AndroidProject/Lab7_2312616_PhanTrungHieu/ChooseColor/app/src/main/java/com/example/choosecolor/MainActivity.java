package com.example.choosecolor;

import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.SeekBar;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private SeekBar sbR, sbG, sbB;
    private TextView tvR, tvG, tvB;
    private View viewRGB, viewCMY;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // Removed EdgeToEdge to keep it simple and avoid overlapping with status bar
        setContentView(R.layout.activity_main);

        setTitle("ChooseColor"); // Set the title for the ActionBar

        initViews();
        setupSeekBars();
        updateColors();
    }

    private void initViews() {
        sbR = findViewById(R.id.sbR);
        sbG = findViewById(R.id.sbG);
        sbB = findViewById(R.id.sbB);

        tvR = findViewById(R.id.tvR);
        tvG = findViewById(R.id.tvG);
        tvB = findViewById(R.id.tvB);

        viewRGB = findViewById(R.id.viewRGB);
        viewCMY = findViewById(R.id.viewCMY);
    }

    private void setupSeekBars() {
        SeekBar.OnSeekBarChangeListener listener = new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                if (seekBar.getId() == R.id.sbR) {
                    tvR.setText("R = " + progress);
                } else if (seekBar.getId() == R.id.sbG) {
                    tvG.setText("G = " + progress);
                } else if (seekBar.getId() == R.id.sbB) {
                    tvB.setText("B = " + progress);
                }
                updateColors();
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {}

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {}
        };

        sbR.setOnSeekBarChangeListener(listener);
        sbG.setOnSeekBarChangeListener(listener);
        sbB.setOnSeekBarChangeListener(listener);
    }

    private void updateColors() {
        int r = sbR.getProgress();
        int g = sbG.getProgress();
        int b = sbB.getProgress();

        int rgbColor = Color.rgb(r, g, b);
        viewRGB.setBackgroundColor(rgbColor);

        int c = 255 - r;
        int m = 255 - g;
        int y = 255 - b;
        int cmyColor = Color.rgb(c, m, y);
        viewCMY.setBackgroundColor(cmyColor);
    }
}
