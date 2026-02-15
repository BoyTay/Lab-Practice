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

public class AddCountryActivity extends AppCompatActivity {

    private EditText editTextCountryName, editTextCountryPopulation;
    private Button buttonSave, buttonSelectImage;
    private ImageView imageViewPreview;
    private DatabaseHelper db;
    private Uri selectedImageUri; // To store the path of the selected image

    // Launcher for the image selection intent
    private final ActivityResultLauncher<Intent> imagePickerLauncher = registerForActivityResult(
            new ActivityResultContracts.StartActivityForResult(),
            result -> {
                if (result.getResultCode() == RESULT_OK && result.getData() != null) {
                    selectedImageUri = result.getData().getData();
                    // Use Glide to load the selected image into the preview
                    Glide.with(this).load(selectedImageUri).into(imageViewPreview);
                }
            });

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_country);

        db = new DatabaseHelper(this);
        editTextCountryName = findViewById(R.id.editTextCountryName);
        editTextCountryPopulation = findViewById(R.id.editTextCountryPopulation);
        buttonSave = findViewById(R.id.buttonSave);
        buttonSelectImage = findViewById(R.id.buttonSelectImage);
        imageViewPreview = findViewById(R.id.imageViewPreview);

        buttonSelectImage.setOnClickListener(v -> openImageChooser());
        buttonSave.setOnClickListener(v -> saveCountry());
    }

    private void openImageChooser() {
        Intent intent = new Intent(Intent.ACTION_PICK);
        intent.setType("image/*");
        imagePickerLauncher.launch(intent);
    }

    private void saveCountry() {
        String name = editTextCountryName.getText().toString();
        String population = editTextCountryPopulation.getText().toString();

        if (name.isEmpty() || population.isEmpty()) {
            Toast.makeText(this, "Please fill all fields", Toast.LENGTH_SHORT).show();
            return;
        }

        // The image is now optional
        String imageUriString = (selectedImageUri != null) ? selectedImageUri.toString() : null;

        Country country = new Country(imageUriString, name, population);
        db.addCountry(country);
        Toast.makeText(this, "Country saved", Toast.LENGTH_SHORT).show();
        finish();
    }
}
