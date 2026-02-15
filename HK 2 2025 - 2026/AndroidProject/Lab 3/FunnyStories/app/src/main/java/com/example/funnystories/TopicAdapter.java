package com.example.funnystories;

import android.content.Context;
import android.graphics.BitmapFactory;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;

public class TopicAdapter extends RecyclerView.Adapter<TopicAdapter.TopicViewHolder> {

    private final List<Topic> topicList;
    private final OnTopicClickListener onTopicClickListener;
    private final Context context;

    public interface OnTopicClickListener {
        void onTopicClick(Topic topic);
    }

    public TopicAdapter(Context context, List<Topic> topicList, OnTopicClickListener onTopicClickListener) {
        this.context = context;
        this.topicList = topicList;
        this.onTopicClickListener = onTopicClickListener;
    }

    @NonNull
    @Override
    public TopicViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.item_story_topic, parent, false);
        return new TopicViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull TopicViewHolder holder, int position) {
        Topic topic = topicList.get(position);
        holder.bind(context, topic, onTopicClickListener);
    }

    @Override
    public int getItemCount() {
        return topicList.size();
    }

    static class TopicViewHolder extends RecyclerView.ViewHolder {
        private final ImageView ivTopicIcon;
        private final TextView tvTopicName;

        public TopicViewHolder(@NonNull View itemView) {
            super(itemView);
            ivTopicIcon = itemView.findViewById(R.id.iv_topic_icon);
            tvTopicName = itemView.findViewById(R.id.tv_topic_name);
        }

        public void bind(final Context context, final Topic topic, final OnTopicClickListener listener) {
            tvTopicName.setText(topic.getName());
            try {
                InputStream ims = context.getAssets().open(topic.getIconPath());
                ivTopicIcon.setImageBitmap(BitmapFactory.decodeStream(ims));
            } catch (IOException e) {
                e.printStackTrace();
                // Optionally set a default image in case of error
                ivTopicIcon.setImageResource(R.drawable.ic_splash);
            }
            itemView.setOnClickListener(v -> listener.onTopicClick(topic));
        }
    }
}
