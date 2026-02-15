package com.example.funnystories;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.Fragment;

public class M003StoryDetailFrg extends Fragment {

    private static final String ARG_STORY = "story";
    private StoryEntity story;

    public static M003StoryDetailFrg newInstance(StoryEntity story) {
        M003StoryDetailFrg fragment = new M003StoryDetailFrg();
        Bundle args = new Bundle();
        args.putParcelable(ARG_STORY, story);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            story = getArguments().getParcelable(ARG_STORY);
        }
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.m003_frg_story_detail, container, false);
        initViews(view);
        return view;
    }

    private void initViews(View view) {
        Toolbar toolbar = view.findViewById(R.id.toolbar_story_detail);
        TextView tvTitle = view.findViewById(R.id.tv_story_title_detail);
        TextView tvContent = view.findViewById(R.id.tv_story_content);

        if (story != null) {
            toolbar.setTitle("Con gái"); // Assuming a static topic for now
            tvTitle.setText(story.title);
            tvContent.setText(story.content);
        }

        toolbar.setNavigationOnClickListener(v -> getParentFragmentManager().popBackStack());
    }
}
