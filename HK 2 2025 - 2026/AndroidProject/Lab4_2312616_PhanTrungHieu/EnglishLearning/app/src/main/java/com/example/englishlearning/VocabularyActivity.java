package com.example.englishlearning;

import android.os.Bundle;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.util.Arrays;
import java.util.List;

public class VocabularyActivity extends AppCompatActivity {

    public static final String EXTRA_TOPIC_INDEX = "topic_index";
    public static final String EXTRA_TOPIC_NAME  = "topic_name";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_vocabulary);

        int topicIndex = getIntent().getIntExtra(EXTRA_TOPIC_INDEX, 0);
        String topicName = getIntent().getStringExtra(EXTRA_TOPIC_NAME);

        // Toolbar
        TextView tvTitle = findViewById(R.id.tv_title);
        tvTitle.setText(topicName);

        ImageButton btnBack = findViewById(R.id.btn_back);
        btnBack.setOnClickListener(v -> finish());

        // ListView
        String[] vocabulary = VocabularyData.getVocabulary(topicIndex);
        List<String> wordList = Arrays.asList(vocabulary);

        VocabularyAdapter adapter = new VocabularyAdapter(this, wordList);
        ListView listView = findViewById(R.id.lv_vocabulary);
        listView.setAdapter(adapter);

        // Click vào từng từ hiển thị Toast
        listView.setOnItemClickListener((parent, view, position, id) -> {
            String word = wordList.get(position);
            Toast.makeText(this, word, Toast.LENGTH_SHORT).show();
        });
    }
}

