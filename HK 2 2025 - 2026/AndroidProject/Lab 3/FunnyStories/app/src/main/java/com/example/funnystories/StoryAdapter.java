package com.example.funnystories;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import java.util.List;

public class StoryAdapter extends RecyclerView.Adapter<StoryAdapter.StoryViewHolder> {

    private final List<StoryEntity> storyList;
    private final OnStoryClickListener onStoryClickListener;

    public interface OnStoryClickListener {
        void onStoryClick(StoryEntity story);
    }

    public StoryAdapter(List<StoryEntity> storyList, OnStoryClickListener onStoryClickListener) {
        this.storyList = storyList;
        this.onStoryClickListener = onStoryClickListener;
    }

    @NonNull
    @Override
    public StoryViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.item_story, parent, false);
        return new StoryViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull StoryViewHolder holder, int position) {
        StoryEntity story = storyList.get(position);
        holder.bind(story, onStoryClickListener);
    }

    @Override
    public int getItemCount() {
        return storyList.size();
    }

    static class StoryViewHolder extends RecyclerView.ViewHolder {
        private final TextView tvStoryName;

        public StoryViewHolder(@NonNull View itemView) {
            super(itemView);
            tvStoryName = itemView.findViewById(R.id.tv_story_name);
        }

        public void bind(final StoryEntity story, final OnStoryClickListener listener) {
            tvStoryName.setText(story.title);
            itemView.setOnClickListener(v -> listener.onStoryClick(story));
        }
    }
}
