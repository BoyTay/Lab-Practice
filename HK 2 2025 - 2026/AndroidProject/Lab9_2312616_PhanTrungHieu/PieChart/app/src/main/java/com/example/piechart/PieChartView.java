package com.example.piechart;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.RectF;
import android.util.AttributeSet;
import android.view.View;

public class PieChartView extends View {
    public float[] values = {450, 1230, 200, 400};
    public String[] labels = {"450", "1230", "200", "400"};
    public int[] colors = {
            Color.GREEN,
            Color.BLUE,
            Color.RED,
            Color.YELLOW
    };

    public PieChartView(Context context) {
        super(context, null);
    }

    public PieChartView(Context context, AttributeSet attrs) {
        super(context, attrs, 0);
    }

    @Override
    protected void onDraw(Canvas canvas) {
        super.onDraw(canvas);

        int width  = getWidth();
        int height = getHeight();

        canvas.drawColor(Color.WHITE);

        // Tính tổng
        float total = 0;
        for (float v : values) total += v;

        // Vùng vẽ hình tròn
        int padding = 40;
        int legendHeight = 60; // chừa chỗ cho legend phía dưới
        int diameter = Math.min(width, height - legendHeight) - padding * 2;
        float left = (width - diameter) / 2f;
        float top  = padding;
        RectF oval = new RectF(left, top, left + diameter, top + diameter);

        Paint piePaint = new Paint();
        piePaint.setAntiAlias(true);

        Paint strokePaint = new Paint();
        strokePaint.setColor(Color.WHITE);
        strokePaint.setStyle(Paint.Style.STROKE);
        strokePaint.setStrokeWidth(3f);
        strokePaint.setAntiAlias(true);

        // Vẽ từng phần
        float startAngle = -90f;
        for (int i = 0; i < values.length; i++) {
            float sweepAngle = (values[i] / total) * 360f;

            // Vẽ phần màu
            piePaint.setColor(colors[i % colors.length]);
            canvas.drawArc(oval, startAngle, sweepAngle, true, piePaint);

            // Vẽ đường viền trắng giữa các phần
            canvas.drawArc(oval, startAngle, sweepAngle, true, strokePaint);

            // Vẽ % ở giữa mỗi phần
            float midAngle = startAngle + sweepAngle / 2;
            float radius = diameter / 2f;
            float textX = left + radius + (float) Math.cos(Math.toRadians(midAngle)) * radius * 0.6f;
            float textY = top  + radius + (float) Math.sin(Math.toRadians(midAngle)) * radius * 0.6f;

            Paint pctPaint = new Paint();
            pctPaint.setColor(Color.WHITE);
            pctPaint.setTextSize(32f);
            pctPaint.setTextAlign(Paint.Align.CENTER);
            pctPaint.setAntiAlias(true);
            pctPaint.setFakeBoldText(true);

            int pct = Math.round(values[i] / total * 100);
            canvas.drawText(pct + "%", textX, textY, pctPaint);

            startAngle += sweepAngle;
        }

        // Vẽ legend phía dưới
        Paint legendPaint = new Paint();
        legendPaint.setAntiAlias(true);

        Paint legendTextPaint = new Paint();
        legendTextPaint.setColor(Color.BLACK);
        legendTextPaint.setTextSize(28f);
        legendTextPaint.setAntiAlias(true);

        float legendY = top + diameter + 20;
        float boxSize = 28f;
        float totalLegendWidth = 0;

        // Tính tổng chiều rộng legend để căn giữa
        for (String label : labels) {
            totalLegendWidth += boxSize + 8 + legendTextPaint.measureText(label) + 20;
        }

        float legendX = (width - totalLegendWidth) / 2f;

        for (int i = 0; i < labels.length; i++) {
            legendPaint.setColor(colors[i % colors.length]);
            canvas.drawRect(legendX, legendY, legendX + boxSize, legendY + boxSize, legendPaint);
            canvas.drawText(labels[i], legendX + boxSize + 8, legendY + boxSize - 4, legendTextPaint);
            legendX += boxSize + 8 + legendTextPaint.measureText(labels[i]) + 20;
        }
    }
}
