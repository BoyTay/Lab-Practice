package com.example.flagcountry;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;

import com.bumptech.glide.Glide;

public class CountryDetailActivity extends AppCompatActivity {

    private EditText editTextNameDetail, editTextPopulationDetail;
    private ImageView imageViewDetail;
    private Button buttonUpdate, buttonDelete, buttonSelectImageDetail;
    private DatabaseHelper db;
    private Country country;
    private Uri selectedImageUri;

    private final ActivityResultLauncher<Intent> imagePickerLauncher = registerForActivityResult(
            new ActivityResultContracts.StartActivityForResult(),
            result -> {
                if (result.getResultCode() == RESULT_OK && result.getData() != null) {
                    selectedImageUri = result.getData().getData();
                    Glide.with(this).load(selectedImageUri).into(imageViewDetail);
                }
            });

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_country_detail);

        db = new DatabaseHelper(this);
        editTextNameDetail = findViewById(R.id.editTextNameDetail);
        editTextPopulationDetail = findViewById(R.id.editTextPopulationDetail);
        imageViewDetail = findViewById(R.id.imageViewDetail);
        buttonUpdate = findViewById(R.id.buttonUpdate);
        buttonDelete = findViewById(R.id.buttonDelete);
        buttonSelectImageDetail = findViewById(R.id.buttonSelectImageDetail);

        long countryId = getIntent().getLongExtra("country_id", -1);

        if (countryId == -1) {
            Toast.makeText(this, "Error: Country not found", Toast.LENGTH_SHORT).show();
            finish();
            return;
        }

        country = db.getCountry(countryId);

        if (country == null) {
            Toast.makeText(this, "Error: Country not found in database", Toast.LENGTH_SHORT).show();
            finish();
            return;
        }

        loadCountryData();

        buttonSelectImageDetail.setOnClickListener(v -> openImageChooser());
        buttonUpdate.setOnClickListener(v -> updateCountry());
        buttonDelete.setOnClickListener(v -> deleteCountry());
    }

    private void loadCountryData() {
        editTextNameDetail.setText(country.getName());
        editTextPopulationDetail.setText(country.getPopulation());

        if (country.getImageUri() != null) {
            selectedImageUri = Uri.parse(country.getImageUri());
            Glide.with(this).load(selectedImageUri).into(imageViewDetail);
        }
    }

    private void openImageChooser() {
        Intent intent = new Intent(Intent.ACTION_PICK);
        intent.setType("image/*");
        imagePickerLauncher.launch(intent);
    }

    private void updateCountry() {
        String name = editTextNameDetail.getText().toString();
        String population = editTextPopulationDetail.getText().toString();

        if (name.isEmpty() || population.isEmpty()) {
            Toast.makeText(this, "Please fill all fields", Toast.LENGTH_SHORT).show();
            return;
        }

        country.setName(name);
        country.setPopulation(population);
        if (selectedImageUri != null) {
            country.setImageUri(selectedImageUri.toString());
        }

        db.updateCountry(country);
        Toast.makeText(this, "Country updated", Toast.LENGTH_SHORT).show();
        finish();
    }

    private void deleteCountry() {
        db.deleteCountry(country);
        Toast.makeText(this, "Country deleted", Toast.LENGTH_SHORT).show();
        finish();
    }
}
