package com.example.amigo;

public class Amigo {
    public int recID;
    public String name;
    public String phone;
    // Constructor mặc định không có tham số
    public Amigo(){

    }
    public Amigo(int recID, String name, String phone){
        this.recID = recID;
        this.name = name;
        this.phone = phone;
    }
}
