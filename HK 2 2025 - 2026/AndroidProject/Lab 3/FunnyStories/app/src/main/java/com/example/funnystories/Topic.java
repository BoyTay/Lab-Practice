package com.example.funnystories;

public class Topic {
    private final String name;
    private final String iconPath; // Changed from int to String

    public Topic(String name, String iconPath) {
        this.name = name;
        this.iconPath = iconPath;
    }

    public String getName() {
        return name;
    }

    public String getIconPath() {
        return iconPath;
    }
}
