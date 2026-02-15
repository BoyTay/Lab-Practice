package com.example.funnystories;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.fragment.app.Fragment;

import java.util.ArrayList;

public class M002StoryDetailFrg extends Fragment {

    ArrayList<StoryEntity> list;
    int index;

    public M002StoryDetailFrg(ArrayList<StoryEntity> list, int index) {
        this.list = list;
        this.index = index;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.m002_story_detail, container, false);
        TextView txt = view.findViewById(R.id.txt_content);

        txt.setText(list.get(index).content);

        return view;
    }
}

