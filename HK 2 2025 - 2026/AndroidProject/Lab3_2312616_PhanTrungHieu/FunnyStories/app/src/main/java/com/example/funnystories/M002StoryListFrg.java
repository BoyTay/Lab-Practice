package com.example.funnystories;

import android.content.res.AssetManager;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

public class M002StoryListFrg extends Fragment implements StoryAdapter.OnStoryClickListener {

    private final String topicName;
    private List<StoryEntity> storyList;

    public M002StoryListFrg(String topicName) {
        this.topicName = topicName;
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.m002_frg_story_list, container, false);
        initViews(view);
        return view;
    }

    private void initViews(View view) {
        Toolbar toolbar = view.findViewById(R.id.toolbar_story_list);
        toolbar.setTitle(topicName);
        toolbar.setNavigationOnClickListener(v -> ((MainActivity) requireActivity()).backToM001Screen());

        RecyclerView rvStories = view.findViewById(R.id.rv_stories);
        rvStories.setLayoutManager(new LinearLayoutManager(getContext()));

        storyList = readStoriesFromAsset();
        StoryAdapter adapter = new StoryAdapter(storyList, this);
        rvStories.setAdapter(adapter);
    }

    private List<StoryEntity> readStoriesFromAsset() {
        List<StoryEntity> stories = new ArrayList<>();
        AssetManager assetManager = requireContext().getAssets();
        try {
            InputStream is = assetManager.open("story/" + topicName + ".txt");
            BufferedReader reader = new BufferedReader(new InputStreamReader(is, StandardCharsets.UTF_8));

            StringBuilder content = new StringBuilder();
            String line;
            while ((line = reader.readLine()) != null) {
                content.append(line).append("\n");
            }
            reader.close();

            // Corrected split pattern
            String[] storyParts = content.toString().split("\n','0'\\);\\n");

            for (String part : storyParts) {
                if (part.trim().isEmpty()) continue;

                String[] lines = part.trim().split("\n", 2);
                if (lines.length > 0 && !lines[0].trim().isEmpty()) {
                    String title = lines[0].trim();
                    String storyContent = (lines.length > 1) ? lines[1].trim() : "";
                    stories.add(new StoryEntity(title, storyContent));
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return stories;
    }

    @Override
    public void onStoryClick(StoryEntity story) {
        ((MainActivity) requireActivity()).gotoM003Screen(story);
    }
}
