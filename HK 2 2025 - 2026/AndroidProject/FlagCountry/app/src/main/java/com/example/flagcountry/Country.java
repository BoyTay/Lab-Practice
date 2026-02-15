package com.example.flagcountry;

public class Country {
    private long id;
    private String imageUri; // Changed from int to String
    private String name;
    private String population;

    // Constructor for creating new countries
    public Country(String imageUri, String name, String population) {
        this.imageUri = imageUri;
        this.name = name;
        this.population = population;
    }

    // Constructor for countries retrieved from database
    public Country(long id, String imageUri, String name, String population) {
        this.id = id;
        this.imageUri = imageUri;
        this.name = name;
        this.population = population;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getImageUri() {
        return imageUri;
    }

    public void setImageUri(String imageUri) {
        this.imageUri = imageUri;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPopulation() {
        return population;
    }

    public void setPopulation(String population) {
        this.population = population;
    }
}
