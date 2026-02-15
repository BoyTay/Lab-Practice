package com.example.food;

import java.io.Serializable;

public class MonAn implements Serializable {
    private int id;
    private String ten;
    private String moTa;
    private String gia;
    private String hinh; // Đổi từ int sang String

    // Constructor để tạo món ăn mới (chưa có ID từ DB)
    public MonAn(String ten, String moTa, String gia, String hinh) {
        this.ten = ten;
        this.moTa = moTa;
        this.gia = gia;
        this.hinh = hinh;
    }

    // Constructor để tạo món ăn từ dữ liệu DB (đã có ID)
    public MonAn(int id, String ten, String moTa, String gia, String hinh) {
        this.id = id;
        this.ten = ten;
        this.moTa = moTa;
        this.gia = gia;
        this.hinh = hinh;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTen() {
        return ten;
    }

    public void setTen(String ten) {
        this.ten = ten;
    }

    public String getMoTa() {
        return moTa;
    }

    public void setMoTa(String moTa) {
        this.moTa = moTa;
    }

    public String getGia() {
        return gia;
    }

    public void setGia(String gia) {
        this.gia = gia;
    }

    public String getHinh() {
        return hinh;
    }

    public void setHinh(String hinh) {
        this.hinh = hinh;
    }
}
