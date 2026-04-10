package com.example.customgridview;

public class Contributor {
    private String name;
    private String score;
    private int imageResId;

    public Contributor(String name, String score, int imageResId) {
        this.name = name;
        this.score = score;
        this.imageResId = imageResId;
    }

    public String getName() {
        return name;
    }

    public String getScore() {
        return score;
    }

    public int getImageResId() {
        return imageResId;
    }
}
