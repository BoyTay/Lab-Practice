package com.example.food;

import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.io.File;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.UUID;

public class EditMonAnActivity extends AppCompatActivity {

    private static final int PICK_IMAGE_REQUEST = 1;

    EditText editTextTenMonAn, editTextMoTa, editTextGia;
    Button buttonLuu, buttonChonAnh;
    ImageView imageViewHinhAnh;
    MonAn monAn;
    String currentImagePath = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit_mon_an);

        editTextTenMonAn = findViewById(R.id.editTextTenMonAn);
        editTextMoTa = findViewById(R.id.editTextMoTa);
        editTextGia = findViewById(R.id.editTextGia);
        buttonLuu = findViewById(R.id.buttonLuu);
        buttonChonAnh = findViewById(R.id.buttonChonAnh);
        imageViewHinhAnh = findViewById(R.id.imageViewHinhAnh);

        Intent intent = getIntent();
        monAn = (MonAn) intent.getSerializableExtra("monan");

        if (monAn != null) {
            editTextTenMonAn.setText(monAn.getTen());
            editTextMoTa.setText(monAn.getMoTa());
            editTextGia.setText(monAn.getGia());
            currentImagePath = monAn.getHinh();
            if (currentImagePath != null && !currentImagePath.isEmpty()) {
                imageViewHinhAnh.setImageURI(Uri.fromFile(new File(currentImagePath)));
            }
        }

        buttonChonAnh.setOnClickListener(v -> openFileChooser());

        buttonLuu.setOnClickListener(v -> {
            String ten = editTextTenMonAn.getText().toString();
            String moTa = editTextMoTa.getText().toString();
            String gia = editTextGia.getText().toString();

            monAn.setTen(ten);
            monAn.setMoTa(moTa);
            monAn.setGia(gia);
            monAn.setHinh(currentImagePath);

            Intent resultIntent = new Intent();
            resultIntent.putExtra("updatedMonAn", monAn);
            setResult(RESULT_OK, resultIntent);
            finish();
        });
    }

    private void openFileChooser() {
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
        intent.setType("image/*");
        startActivityForResult(intent, PICK_IMAGE_REQUEST);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == PICK_IMAGE_REQUEST && resultCode == RESULT_OK && data != null && data.getData() != null) {
            Uri imageUri = data.getData();
            currentImagePath = saveImageToInternalStorage(imageUri);
            if (currentImagePath != null) {
                imageViewHinhAnh.setImageURI(Uri.fromFile(new File(currentImagePath)));
            }
        }
    }

    private String saveImageToInternalStorage(Uri uri) {
        try {
            InputStream inputStream = getContentResolver().openInputStream(uri);
            if (inputStream == null) return null;

            File directory = getDir("images", Context.MODE_PRIVATE);
            File file = new File(directory, UUID.randomUUID().toString() + ".jpg");

            OutputStream outputStream = new FileOutputStream(file);
            byte[] buffer = new byte[1024];
            int length;
            while ((length = inputStream.read(buffer)) > 0) {
                outputStream.write(buffer, 0, length);
            }

            outputStream.close();
            inputStream.close();

            return file.getAbsolutePath();
        } catch (Exception e) {
            Toast.makeText(this, "Lỗi khi lưu ảnh!", Toast.LENGTH_SHORT).show();
            e.printStackTrace();
            return null;
        }
    }
}
