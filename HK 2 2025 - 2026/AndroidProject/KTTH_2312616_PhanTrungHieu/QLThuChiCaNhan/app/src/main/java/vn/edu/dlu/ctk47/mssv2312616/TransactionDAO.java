package vn.edu.dlu.ctk47.mssv2312616;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import java.util.ArrayList;
import java.util.List;

public class TransactionDAO {
    private SQLiteDatabase db;
    private DatabaseHelper dbHelper;

    public TransactionDAO(Context context) {
        dbHelper = new DatabaseHelper(context);
        db = dbHelper.getWritableDatabase();
    }

    public List<Account> getAllAccounts() {
        List<Account> list = new ArrayList<>();
        Cursor cursor = db.query("Account", null, null, null, null, null, null);
        if (cursor != null && cursor.moveToFirst()) {
            do {
                int id = cursor.getInt(cursor.getColumnIndexOrThrow("acc_id"));
                String name = cursor.getString(cursor.getColumnIndexOrThrow("acc_name"));
                double balance = cursor.getDouble(cursor.getColumnIndexOrThrow("balance"));
                list.add(new Account(id, name, balance));
            } while (cursor.moveToNext());
            cursor.close();
        }
        return list;
    }

    public List<Category> getAllCategories() {
        List<Category> list = new ArrayList<>();
        Cursor cursor = db.query("Category", null, null, null, null, null, null);
        if (cursor != null && cursor.moveToFirst()) {
            do {
                int id = cursor.getInt(cursor.getColumnIndexOrThrow("cat_id"));
                String name = cursor.getString(cursor.getColumnIndexOrThrow("name"));
                int type = cursor.getInt(cursor.getColumnIndexOrThrow("type"));
                list.add(new Category(id, name, type));
            } while (cursor.moveToNext());
            cursor.close();
        }
        return list;
    }

    public List<Transaction> getAllTransactions() {
        List<Transaction> list = new ArrayList<>();
        Cursor cursor = db.query("[Transaction]", null, null, null, null, null, "date DESC");
        if (cursor != null && cursor.moveToFirst()) {
            do {
                int id = cursor.getInt(cursor.getColumnIndexOrThrow("trans_id"));
                double amount = cursor.getDouble(cursor.getColumnIndexOrThrow("amount"));
                String date = cursor.getString(cursor.getColumnIndexOrThrow("date"));
                int catId = cursor.getInt(cursor.getColumnIndexOrThrow("cat_id"));
                int accId = cursor.getInt(cursor.getColumnIndexOrThrow("acc_id"));
                list.add(new Transaction(id, amount, date, catId, accId));
            } while (cursor.moveToNext());
            cursor.close();
        }
        return list;
    }

    private int getCategoryType(int catId) {
        Cursor c = db.query("Category", new String[]{"type"}, "cat_id=?", new String[]{String.valueOf(catId)}, null, null, null);
        int type = 0;
        if (c.moveToFirst()) type = c.getInt(0);
        c.close();
        return type;
    }

    private void updateAccountBalance(int accId, double amount, boolean isAddition) {
        String operator = isAddition ? "+" : "-";
        db.execSQL("UPDATE Account SET balance = balance " + operator + " " + amount + " WHERE acc_id = " + accId);
    }

    public long insertTransaction(Transaction t) {
        db.beginTransaction();
        try {
            ContentValues values = new ContentValues();
            values.put("amount", t.getAmount());
            values.put("date", t.getDate());
            values.put("cat_id", t.getCat_id());
            values.put("acc_id", t.getAcc_id());
            long res = db.insert("[Transaction]", null, values);

            if (res > 0) {
                int type = getCategoryType(t.getCat_id());
                updateAccountBalance(t.getAcc_id(), t.getAmount(), type == 1);
                db.setTransactionSuccessful();
            }
            return res;
        } finally {
            db.endTransaction();
        }
    }

    public int deleteTransaction(Transaction t) {
        db.beginTransaction();
        try {
            int res = db.delete("[Transaction]", "trans_id = ?", new String[]{String.valueOf(t.getTrans_id())});
            if (res > 0) {
                int type = getCategoryType(t.getCat_id());
                // Undo: if it was income (+), subtract. if it was expense (-), add back.
                updateAccountBalance(t.getAcc_id(), t.getAmount(), type != 1);
                db.setTransactionSuccessful();
            }
            return res;
        } finally {
            db.endTransaction();
        }
    }

    public int updateTransaction(Transaction oldT, Transaction newT) {
        db.beginTransaction();
        try {
            // 1. Undo old transaction balance
            int oldType = getCategoryType(oldT.getCat_id());
            updateAccountBalance(oldT.getAcc_id(), oldT.getAmount(), oldType != 1);

            // 2. Apply new transaction balance
            int newType = getCategoryType(newT.getCat_id());
            updateAccountBalance(newT.getAcc_id(), newT.getAmount(), newType == 1);

            // 3. Update database record
            ContentValues values = new ContentValues();
            values.put("amount", newT.getAmount());
            values.put("date", newT.getDate());
            values.put("cat_id", newT.getCat_id());
            values.put("acc_id", newT.getAcc_id());
            
            int res = db.update("[Transaction]", values, "trans_id = ?", new String[]{String.valueOf(oldT.getTrans_id())});
            if (res > 0) {
                db.setTransactionSuccessful();
            }
            return res;
        } finally {
            db.endTransaction();
        }
    }
}
