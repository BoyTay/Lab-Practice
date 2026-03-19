package vn.edu.dlu.ctk47.mssv2312616;

public class Account {
    int acc_id;
    String acc_name;
    double balance;

    public Account(int acc_id, String acc_name, double balance) {
        this.acc_id = acc_id;
        this.acc_name = acc_name;
        this.balance = balance;
    }

    public int getId() {
        return acc_id;
    }
    public void setId(int acc_id) {
        this.acc_id = acc_id;
    }

    public String getName() {
        return acc_name;
    }
    public void setName(String acc_name) {
        this.acc_name = acc_name;
    }

    public double getBalance() {
        return balance;
    }
    public void setBalance(double balance) {
        this.balance = balance;
    }
}
