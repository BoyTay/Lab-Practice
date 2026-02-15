package com.example.employee;
import java.io.Serializable;

public class Employee implements Serializable {
    // Serializable để truyền object giữa các Activity
    private int id;
    private String code;
    private String name;
    private int age;

    // Constructor cho việc thêm mới (không cần id)
    public Employee(String code, String name, int age) {
        this.code = code;
        this.name = name;
        this.age = age;
    }

    // Constructor cho việc đọc từ CSDL (có id)
    public Employee(int id, String code, String name, int age) {
        this.id = id;
        this.code = code;
        this.name = name;
        this.age = age;
    }

    // Getters and Setters
    public int getId() { return id; }
    public void setId(int id) { this.id = id; }
    public String getCode() { return code; }
    public void setCode(String code) { this.code = code; }
    public String getName() { return name; }
    public void setName(String name) { this.name = name; }
    public int getAge() { return age; }
    public void setAge(int age) { this.age = age; }

    @Override
    public String toString() {
        // Hiển thị tên trong ListView
        return this.name;
    }
}

