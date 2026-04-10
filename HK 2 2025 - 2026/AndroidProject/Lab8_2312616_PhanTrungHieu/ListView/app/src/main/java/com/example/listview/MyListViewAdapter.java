package com.example.listview;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

public class MyListViewAdapter extends BaseAdapter {
    ArrayList<Product> list;

    public MyListViewAdapter(ArrayList<Product> list) {
        this.list = list;
    }

    @Override
    public int getCount() { return list.size(); } // [cite: 101, 102]

    @Override
    public Object getItem(int position) { return list.get(position); } // [cite: 106]

    @Override
    public long getItemId(int position) { return position; }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // Nạp layout row.xml [cite: 113, 114]
        if (convertView == null) {
            convertView = LayoutInflater.from(parent.getContext()).inflate(R.layout.row, parent, false);
        }

        Product product = list.get(position);

        ImageView img = convertView.findViewById(R.id.imgRow); // [cite: 115]
        TextView txtTitle = convertView.findViewById(R.id.txtTitle); // [cite: 117]
        TextView txtContent = convertView.findViewById(R.id.txtContent); // [cite: 119]

        img.setImageResource(product.image); // [cite: 116]
        txtTitle.setText(product.title); // [cite: 118]
        txtContent.setText(product.content); // [cite: 119]

        return convertView;
    }
}
