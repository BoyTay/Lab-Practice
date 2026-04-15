package com.example.canvas;

import static android.opengl.ETC1.getHeight;
import static android.opengl.ETC1.getWidth;

import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.Random;

public class MainActivity extends AppCompatActivity {
    MyCanvas canvas;
    Button button;
    int [] colors = new int[]{Color.RED,Color.GREEN,Color.BLUE,Color.YELLOW,Color.CYAN,Color.WHITE};
    Random rd = new Random();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        MyCanvas canvas = findViewById(R.id.myCanvas);
        Button btnDraw = findViewById(R.id.btnDraw);
        btnDraw.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //Random chỉ số màu
                int colorIndex = rd.nextInt(colors.length);
                //Lấy màu trong mảng và gán giá trị màu trong lớp MyCanvas
                MyCanvas.color = colors[colorIndex];
                //Vẽ lại
                canvas.invalidate();
            }
        });
    }
}