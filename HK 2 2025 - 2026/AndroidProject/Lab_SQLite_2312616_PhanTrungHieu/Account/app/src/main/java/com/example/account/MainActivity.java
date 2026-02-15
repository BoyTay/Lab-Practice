package com.example.account;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;


public class MainActivity extends AppCompatActivity {

    public static  final String SAVE_PREF = "save_pref";
    SQLiteHelper helper;
    private void InitialDB(){
        helper = new SQLiteHelper(this);
        helper.openDB();
        helper.createTable();
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        InitialDB();
        getSupportFragmentManager()
                .beginTransaction()
                .replace(R.id.ln_main, new M000LoginFragment())
                .commit();

    }

    public SQLiteHelper getHelper() {
        return helper;
    }
}