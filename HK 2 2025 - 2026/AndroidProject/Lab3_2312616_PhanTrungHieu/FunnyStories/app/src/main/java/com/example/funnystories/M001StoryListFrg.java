package com.example.funnystories;

import android.content.res.AssetManager;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class M001StoryListFrg extends Fragment implements TopicAdapter.OnTopicClickListener {

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.m001_frg_story_list, container, false);
        initViews(view);
        return view;
    }

    private void initViews(View view) {
        RecyclerView rvStoryTopics = view.findViewById(R.id.rv_story_topics);
        rvStoryTopics.setLayoutManager(new LinearLayoutManager(getContext()));

        List<Topic> topicList = getTopicsFromAssets();
        TopicAdapter adapter = new TopicAdapter(getContext(), topicList, this);
        rvStoryTopics.setAdapter(adapter);
    }

    private List<Topic> getTopicsFromAssets() {
        List<Topic> topics = new ArrayList<>();
        AssetManager assetManager = requireContext().getAssets();
        try {
            String[] storyFiles = assetManager.list("story");
            if (storyFiles != null) {
                for (String fileName : storyFiles) {
                    if (fileName.endsWith(".txt")) {
                        String topicName = fileName.replace(".txt", "");
                        String iconPath = "photo/" + topicName + ".png";
                        topics.add(new Topic(topicName, iconPath));
                    }
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return topics;
    }

    @Override
    public void onTopicClick(Topic topic) {
        ((MainActivity) requireActivity()).gotoM002Screen(topic.getName());
    }
}
