package com.example.englishlearning;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.List;

public class VocabularyAdapter extends ArrayAdapter<String> {

    private final LayoutInflater inflater;
    private final List<String> items;

    public VocabularyAdapter(Context context, List<String> items) {
        super(context, R.layout.item_vocabulary, items);
        this.inflater = LayoutInflater.from(context);
        this.items = items;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder holder;
        if (convertView == null) {
            convertView = inflater.inflate(R.layout.item_vocabulary, parent, false);
            holder = new ViewHolder();
            holder.tvNumber = convertView.findViewById(R.id.tv_number);
            holder.tvEnglish = convertView.findViewById(R.id.tv_english);
            holder.tvVietnamese = convertView.findViewById(R.id.tv_vietnamese);
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        String word = items.get(position);
        // Tách "English - Tiếng Việt"
        String[] parts = word.split(" - ", 2);
        holder.tvNumber.setText(String.valueOf(position + 1));
        holder.tvEnglish.setText(parts[0].trim());
        holder.tvVietnamese.setText(parts.length > 1 ? parts[1].trim() : "");

        return convertView;
    }

    static class ViewHolder {
        TextView tvNumber;
        TextView tvEnglish;
        TextView tvVietnamese;
    }
}

