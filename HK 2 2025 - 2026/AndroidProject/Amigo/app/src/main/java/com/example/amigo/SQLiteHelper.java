package com.example.amigo;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import  android.database.sqlite.SQLiteDatabase;
import  android.database.sqlite.SQLiteOpenHelper;

import java.util.ArrayList;
import java.util.List;

//SQLiteHelper kế thừa từ SQLiteOpenHelper để quản lý việc tạo và mở kết nối cơ sở dữ liệu
public class SQLiteHelper extends SQLiteOpenHelper {
    Context context;
    private static String DB_NAME = "mydb1.db"; // Tên file database [cite: 41]
    SQLiteDatabase myDB;
    public SQLiteHelper(Context context) {
        super(context, DB_NAME, null, 1);
        this.context = context; // [cite: 42-46]
    }
    @Override
    public void onCreate(SQLiteDatabase db) {
        String query = "create table tblAMIGO (recID INTEGER PRIMARY KEY AUTOINCREMENT, name text, phone text)";
        db.execSQL(query);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // Xóa bảng cũ nếu tồn tại và tạo lại
        db.execSQL("DROP TABLE IF EXISTS tblAMIGO");
        onCreate(db);
    }

    // Hàm mở kết nối database
    public void openDB() {
        myDB = getWritableDatabase(); // [cite: 47-48]
    }

    // Hàm đóng kết nối
    public void closeDB() {
        if (myDB != null && myDB.isOpen()) {
            myDB.close(); // [cite: 50-53]
        }
    }

    public void insert(Amigo amigo) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("recID", amigo.recID); // Lưu ý: Tài liệu dùng key "name" cho ID ở dòng 169, nhưng logic đúng phải là cột ID
        contentValues.put("name", amigo.name);   // [cite: 170]
        contentValues.put("phone", amigo.phone); // [cite: 171]

        myDB.insert("tblAMIGO", null, contentValues); // [cite: 172]
    }
    public void update(Amigo amigo) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("name", amigo.name);   // [cite: 224]
        contentValues.put("phone", amigo.phone); // [cite: 225]

        // Cập nhật dòng có recID tương ứng
        myDB.update("tblAMIGO",
                contentValues,
                "recID = ?",
                new String[]{String.valueOf(amigo.recID)}); // [cite: 226-230]
    }
    public void delete(int recID) {
        myDB.delete("tblAMIGO",
                "recID = ?",
                new String[]{String.valueOf(recID)}); // [cite: 265-266]
    }
    public List<Amigo> getAll() {
        List<Amigo> L = new ArrayList<>();
        String query = "select * from tblAMIGO";
        Cursor cursor = myDB.rawQuery(query, null); // [cite: 341]

        while (cursor.moveToNext()) { // [cite: 342]
            int id = cursor.getInt(cursor.getColumnIndexOrThrow("recID")); // [cite: 343]
            String name = cursor.getString(cursor.getColumnIndexOrThrow("name")); // [cite: 344]
            String phone = cursor.getString(cursor.getColumnIndexOrThrow("phone")); // [cite: 345-346]

            Amigo amigo = new Amigo(id, name, phone);
            L.add(amigo); // [cite: 349]
        }
        cursor.close(); // Nên đóng cursor sau khi dùng
        return L; // [cite: 350]
    }
    public Amigo get(int recID) {
        Amigo amigo;
        Cursor cursor = myDB.query(
                "tblAMIGO",
                null,
                "recID = ?",
                new String[]{String.valueOf(recID)},
                null, null, null); // [cite: 359-366]

        if (cursor.moveToFirst()) { // [cite: 367]
            int id = cursor.getInt(cursor.getColumnIndexOrThrow("recID"));
            String name = cursor.getString(cursor.getColumnIndexOrThrow("name"));
            String phone = cursor.getString(cursor.getColumnIndexOrThrow("phone")); // [cite: 368-370]
            amigo = new Amigo(id, name, phone);
        } else {
            amigo = new Amigo(); // [cite: 372]
        }
        cursor.close(); // [cite: 374]
        return amigo; // [cite: 375]
    }

}
