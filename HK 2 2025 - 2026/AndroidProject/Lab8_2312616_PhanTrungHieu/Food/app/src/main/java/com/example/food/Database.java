package com.example.food;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class Database extends SQLiteOpenHelper {

    private static final String DATABASE_NAME = "QuanLyMonAn.sqlite";
    private static final int DATABASE_VERSION = 2; // Tăng phiên bản để kích hoạt onUpgrade
    public static final String TABLE_MONAN = "MonAn";

    public static final String COLUMN_ID = "Id";
    public static final String COLUMN_TEN = "Ten";
    public static final String COLUMN_MOTA = "MoTa";
    public static final String COLUMN_GIA = "Gia";
    public static final String COLUMN_HINH = "Hinh";

    public Database(@Nullable Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    // Phương thức này dùng để thực thi các câu truy vấn không trả về kết quả (CREATE, INSERT, UPDATE, DELETE)
    public void QueryData(String sql){
        SQLiteDatabase database = getWritableDatabase();
        database.execSQL(sql);
    }

    // Phương thức này dùng để thực thi các câu truy vấn có trả về kết quả (SELECT)
    public Cursor GetData(String sql){
        SQLiteDatabase database = getReadableDatabase();
        return database.rawQuery(sql, null);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        // Khi cơ sở dữ liệu được tạo lần đầu, tạo bảng MonAn
        String createTable = "CREATE TABLE " + TABLE_MONAN + " (" +
                COLUMN_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                COLUMN_TEN + " VARCHAR(200), " +
                COLUMN_MOTA + " VARCHAR(200), " +
                COLUMN_GIA + " VARCHAR(100), " +
                COLUMN_HINH + " TEXT)"; // Đổi từ INTEGER sang TEXT
        db.execSQL(createTable);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // Nếu có cập nhật phiên bản, xóa bảng cũ và tạo lại
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_MONAN);
        onCreate(db);
    }
}
