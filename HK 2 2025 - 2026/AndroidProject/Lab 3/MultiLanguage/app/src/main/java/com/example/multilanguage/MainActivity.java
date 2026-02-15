package com.example.multilanguage;

import android.content.res.Configuration;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.Locale;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        // Cần đảm bảo ActionBar hiển thị để có chỗ chứa Menu
        if (getSupportActionBar() != null) {
            getSupportActionBar().setTitle(R.string.app_name);
        }
    }
    // 1. Khởi tạo Menu
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main_menu, menu);
        return true;
    }

    // 2. Xử lý sự kiện khi chọn Item trong Menu
    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        int id = item.getItemId();

        if (id == R.id.mn_vi) {
            setLocale("vi"); // Tiếng Việt
            return true;
        } else if (id == R.id.mn_en) {
            setLocale("en"); // Tiếng Anh
            return true;
        } else if (id == R.id.mn_fr) {
            setLocale("fr"); // Tiếng Pháp
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    // 3. Hàm đổi ngôn ngữ
    private void setLocale(String langCode) {
        Locale locale = new Locale(langCode);
        Locale.setDefault(locale);
        Configuration config = new Configuration();
        config.locale = locale;

        // Cập nhật cấu hình
        getBaseContext().getResources().updateConfiguration(
                config,
                getBaseContext().getResources().getDisplayMetrics()
        );

        // Load lại Activity để áp dụng ngôn ngữ mới ngay lập tức
        recreate();
    }
}