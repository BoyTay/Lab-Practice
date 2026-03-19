package vn.edu.dlu.ctk47.mssv2312616;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DatabaseHelper extends SQLiteOpenHelper {
    private static final String DB_NAME = "finance.db";
    private static final int DB_VERSION = 1;
    public DatabaseHelper(Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }
    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE Category (" +
                "cat_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "name TEXT NOT NULL," +
                "type INTEGER NOT NULL)");
        
        db.execSQL("CREATE TABLE Account (" +
                "acc_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "acc_name TEXT NOT NULL," +
                "balance REAL NOT NULL)");

        db.execSQL("CREATE TABLE [Transaction] (" +
                "trans_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "amount REAL NOT NULL," +
                "date TEXT NOT NULL," +
                "cat_id INTEGER," +
                "acc_id INTEGER," +
                "FOREIGN KEY(cat_id) REFERENCES Category(cat_id)," +
                "FOREIGN KEY(acc_id) REFERENCES Account(acc_id))");

        insertDefaultData(db);
    }

    private void insertDefaultData(SQLiteDatabase db) {

        db.execSQL("INSERT INTO Category(name,type) VALUES('Lương',1)");
        db.execSQL("INSERT INTO Category(name,type) VALUES('Thưởng',1)");
        db.execSQL("INSERT INTO Category(name,type) VALUES('Ăn uống',0)");
        db.execSQL("INSERT INTO Category(name,type) VALUES('Tiền nhà',0)");
        db.execSQL("INSERT INTO Category(name,type) VALUES('Di chuyển',0)");


        db.execSQL("INSERT INTO Account(acc_name,balance) VALUES('Tiền mặt',5000000)");
        db.execSQL("INSERT INTO Account(acc_name,balance) VALUES('Ngân hàng',10000000)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS [Transaction]");
        db.execSQL("DROP TABLE IF EXISTS Account");
        db.execSQL("DROP TABLE IF EXISTS Category");
        onCreate(db);
    }
}
