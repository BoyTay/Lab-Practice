package com.example.barchart;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.view.View;

public class BarChartView extends View {
    // Dữ liệu mặc định
    public float[] values = {3, 8, 6, 2, 7, 1, 3};
    public int[] colors = {
            Color.MAGENTA,
            Color.CYAN,
            Color.GREEN,
            Color.GRAY,
            Color.CYAN,
            Color.GREEN,
            Color.YELLOW
    };

    public BarChartView(Context context) {
        super(context, null);
    }

    public BarChartView(Context context, AttributeSet attrs) {
        super(context, attrs, 0);
    }

    @Override
    protected void onDraw(Canvas canvas) {
        super.onDraw(canvas);

        int width = getWidth();
        int height = getHeight();
        int paddingLeft = 80;
        int paddingBottom = 60;
        int paddingTop = 60;

        // Vẽ nền trắng
        canvas.drawColor(Color.WHITE);

        Paint barPaint = new Paint();
        barPaint.setAntiAlias(true);

        Paint textPaint = new Paint();
        textPaint.setColor(Color.BLACK);
        textPaint.setTextSize(35f);
        textPaint.setTextAlign(Paint.Align.CENTER);
        textPaint.setAntiAlias(true);

        // Tìm giá trị lớn nhất để scale
        float maxValue = 0;
        for (float v : values) if (v > maxValue) maxValue = v;

        int barCount = values.length;
        float chartWidth = width - paddingLeft - 20;
        float chartHeight = height - paddingBottom - paddingTop;
        float barWidth = chartWidth / (barCount * 2f);

        for (int i = 0; i < barCount; i++) {
            float left = paddingLeft + i * (barWidth * 2) + barWidth / 2;
            float right = left + barWidth;
            float barHeight = (values[i] / maxValue) * chartHeight;
            float top = height - paddingBottom - barHeight;
            float bottom = height - paddingBottom;

            // Vẽ cột
            barPaint.setColor(colors[i % colors.length]);
            canvas.drawRect(left, top, right, bottom, barPaint);

            // Số trên đầu cột
            canvas.drawText(
                    String.valueOf((int) values[i]),
                    left + barWidth / 2,
                    top - 10,
                    textPaint
            );
        }

        // Vẽ trục Y
        Paint axisPaint = new Paint();
        axisPaint.setColor(Color.BLACK);
        axisPaint.setStrokeWidth(4f);
        canvas.drawLine(paddingLeft, paddingTop, paddingLeft, height - paddingBottom, axisPaint);

        // Vẽ trục X
        canvas.drawLine(paddingLeft, height - paddingBottom, width - 20, height - paddingBottom, axisPaint);

        // Label trục Y
        textPaint.setTextAlign(Paint.Align.LEFT);
        textPaint.setTextSize(28f);
        canvas.drawText("kWh", 5, paddingTop, textPaint);
    }
}
