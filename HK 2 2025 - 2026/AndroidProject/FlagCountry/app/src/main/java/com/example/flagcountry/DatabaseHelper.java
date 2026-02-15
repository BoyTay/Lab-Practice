package com.example.flagcountry;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.util.ArrayList;
import java.util.List;

public class DatabaseHelper extends SQLiteOpenHelper {

    private static final String DATABASE_NAME = "countries.db";
    // DATABASE_VERSION is incremented to 3 to trigger the onUpgrade method for the new schema
    private static final int DATABASE_VERSION = 3;

    private static final String TABLE_COUNTRIES = "countries";
    private static final String COLUMN_ID = "id";
    private static final String COLUMN_NAME = "name";
    private static final String COLUMN_POPULATION = "population";
    // Renamed column for clarity and changed type to TEXT
    private static final String COLUMN_IMAGE_URI = "image_uri";

    public DatabaseHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String CREATE_COUNTRIES_TABLE = "CREATE TABLE " + TABLE_COUNTRIES + "("
                + COLUMN_ID + " INTEGER PRIMARY KEY AUTOINCREMENT,"
                + COLUMN_NAME + " TEXT,"
                + COLUMN_POPULATION + " TEXT,"
                + COLUMN_IMAGE_URI + " TEXT" + ")"; // Changed to TEXT
        db.execSQL(CREATE_COUNTRIES_TABLE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_COUNTRIES);
        onCreate(db);
    }

    public void addCountry(Country country) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(COLUMN_NAME, country.getName());
        values.put(COLUMN_POPULATION, country.getPopulation());
        values.put(COLUMN_IMAGE_URI, country.getImageUri()); // Use new column and getter
        db.insert(TABLE_COUNTRIES, null, values);
    }

    private Country cursorToCountry(Cursor cursor) {
        long id = cursor.getLong(cursor.getColumnIndexOrThrow(COLUMN_ID));
        String imageUri = cursor.getString(cursor.getColumnIndexOrThrow(COLUMN_IMAGE_URI)); // Use new column
        String name = cursor.getString(cursor.getColumnIndexOrThrow(COLUMN_NAME));
        String population = cursor.getString(cursor.getColumnIndexOrThrow(COLUMN_POPULATION));
        return new Country(id, imageUri, name, population);
    }

    public List<Country> getAllCountries() {
        List<Country> countryList = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery("SELECT * FROM " + TABLE_COUNTRIES, null);

        if (cursor.moveToFirst()) {
            do {
                countryList.add(cursorToCountry(cursor));
            } while (cursor.moveToNext());
        }
        cursor.close();
        return countryList;
    }

    public Country getCountry(long id) {
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.query(TABLE_COUNTRIES, null, COLUMN_ID + " = ?",
                new String[]{String.valueOf(id)}, null, null, null);

        if (cursor != null && cursor.moveToFirst()) {
            Country country = cursorToCountry(cursor);
            cursor.close();
            return country;
        }
        return null;
    }

    public void updateCountry(Country country) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(COLUMN_NAME, country.getName());
        values.put(COLUMN_POPULATION, country.getPopulation());
        values.put(COLUMN_IMAGE_URI, country.getImageUri()); // Use new column and getter
        db.update(TABLE_COUNTRIES, values, COLUMN_ID + " = ?",
                new String[]{String.valueOf(country.getId())});
    }

    public void deleteCountry(Country country) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_COUNTRIES, COLUMN_ID + " = ?",
                new String[]{String.valueOf(country.getId())});
    }

    public List<Country> searchCountry(String name) {
        List<Country> countryList = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.query(TABLE_COUNTRIES, null, COLUMN_NAME + " LIKE ?",
                new String[]{"%" + name + "%"}, null, null, null);

        if (cursor.moveToFirst()) {
            do {
                countryList.add(cursorToCountry(cursor));
            } while (cursor.moveToNext());
        }
        cursor.close();
        return countryList;
    }
}
