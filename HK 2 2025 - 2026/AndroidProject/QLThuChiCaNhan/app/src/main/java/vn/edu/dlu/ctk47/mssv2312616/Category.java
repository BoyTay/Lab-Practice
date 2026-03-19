package vn.edu.dlu.ctk47.mssv2312616;

public class Category {
     int cat_id;
     String name;
     int type;

    public Category(int cat_id, String name, int type) {
        this.cat_id = cat_id;
        this.name = name;
        this.type = type;
    }

    public int getId() {
        return cat_id;
    }
    public void setId(int cat_id) {
        this.cat_id = cat_id;
    }

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }

    public int getType() {
        return type;
    }
    public void setType(int type) {
        this.type = type;
    }
}
