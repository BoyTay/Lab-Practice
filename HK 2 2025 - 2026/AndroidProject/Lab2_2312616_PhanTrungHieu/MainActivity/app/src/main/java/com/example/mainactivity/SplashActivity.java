package com.example.mainactivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.widget.ImageView;
import android.widget.LinearLayout;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import java.util.Random;

public class SplashActivity extends AppCompatActivity {
    LinearLayout layoutRoot;
    ImageView imgIcon;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash);
        layoutRoot = findViewById(R.id.layoutRoot);
        imgIcon = findViewById(R.id.imgIcon);

        // Danh sách màu nền
        int[] colors = {
                R.color.teal_200,
                R.color.teal_700,
                R.color.purple_700,
                R.color.purple_200,
                R.color.purple_500
        };

        // Danh sách icon
        int[] icons = {
                R.drawable.penguin,
                R.drawable.dog,
                R.drawable.cat
        };

        Random random = new Random();

        // Chọn ngẫu nhiên
        int randomColor = colors[random.nextInt(colors.length)];
        int randomIcon = icons[random.nextInt(icons.length)];

        // Áp dụng
        layoutRoot.setBackgroundColor(ContextCompat.getColor(this, randomColor));
        imgIcon.setImageResource(randomIcon);
    }
}
