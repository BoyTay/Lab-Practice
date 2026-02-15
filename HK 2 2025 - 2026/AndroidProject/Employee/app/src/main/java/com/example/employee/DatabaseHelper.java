package com.example.employee;

import android.content.Context;
import android.content.ContentValues;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.database.Cursor;

import java.util.ArrayList;
import java.util.List;

public class DatabaseHelper extends SQLiteOpenHelper {
    // Thông tin cơ sở dữ liệu
    private static final String DATABASE_NAME = "employee_manager";
    private static final int DATABASE_VERSION = 1;

    // Thông tin bảng
    private static final String TABLE_EMPLOYEES = "employees";
    private static final String KEY_ID = "id";
    private static final String KEY_CODE = "code";
    private static final String KEY_NAME = "name";
    private static final String KEY_AGE = "age";

    public DatabaseHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    // Tạo bảng
    @Override
    public void onCreate(SQLiteDatabase db) {
        String CREATE_EMPLOYEES_TABLE = "CREATE TABLE " + TABLE_EMPLOYEES + "("
                + KEY_ID + " INTEGER PRIMARY KEY AUTOINCREMENT,"
                + KEY_CODE + " TEXT,"
                + KEY_NAME + " TEXT,"
                + KEY_AGE + " INTEGER" + ")";
        db.execSQL(CREATE_EMPLOYEES_TABLE);

        // Thêm dữ liệu mẫu
        addInitialData(db);
    }

    // Nâng cấp cơ sở dữ liệu
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_EMPLOYEES);
        onCreate(db);
    }

    // Thêm dữ liệu mẫu vào bảng
    private void addInitialData(SQLiteDatabase db) {
        addEmployee(db, new Employee("NV-111", "Nguyễn Đại Nhân", 28));
        addEmployee(db, new Employee("NV-112", "Trần Đại Nghĩa", 32));
        addEmployee(db, new Employee("NV-113", "Hoàng Đại Lễ", 35));
        addEmployee(db, new Employee("NV-114", "Phạm Đại Trí", 25));
        addEmployee(db, new Employee("NV-115", "Trương Đại Tín", 30));
        addEmployee(db, new Employee("NV-116", "Hồ Đại Đức", 40));
    }

    // Phương thức hỗ trợ thêm nhân viên
    private void addEmployee(SQLiteDatabase db, Employee employee) {
        ContentValues values = new ContentValues();
        values.put(KEY_CODE, employee.getCode());
        values.put(KEY_NAME, employee.getName());
        values.put(KEY_AGE, employee.getAge());
        db.insert(TABLE_EMPLOYEES, null, values);
    }

    // Lấy tất cả nhân viên
    public List<Employee> getAllEmployees() {
        List<Employee> employeeList = new ArrayList<>();
        String selectQuery = "SELECT * FROM " + TABLE_EMPLOYEES;

        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);

        if (cursor.moveToFirst()) {
            do {
                int id = cursor.getInt(cursor.getColumnIndexOrThrow(KEY_ID));
                String code = cursor.getString(cursor.getColumnIndexOrThrow(KEY_CODE));
                String name = cursor.getString(cursor.getColumnIndexOrThrow(KEY_NAME));
                int age = cursor.getInt(cursor.getColumnIndexOrThrow(KEY_AGE));

                Employee employee = new Employee(id, code, name, age);
                employeeList.add(employee);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return employeeList;
    }

    // Xóa một nhân viên
    public void deleteEmployee(Employee employee) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_EMPLOYEES, KEY_ID + " = ?",
                new String[]{String.valueOf(employee.getId())});
        db.close();
    }
}

