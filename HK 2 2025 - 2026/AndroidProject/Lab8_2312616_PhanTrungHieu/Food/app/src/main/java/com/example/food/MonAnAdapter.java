package com.example.food;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.io.File;
import java.util.List;

public class MonAnAdapter extends BaseAdapter {

    private final Context context;
    private final int layout;
    private final List<MonAn> monAnList;

    public MonAnAdapter(Context context, int layout, List<MonAn> monAnList) {
        this.context = context;
        this.layout = layout;
        this.monAnList = monAnList;
    }

    @Override
    public int getCount() {
        return monAnList.size();
    }

    @Override
    public Object getItem(int position) {
        return monAnList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return monAnList.get(position).getId();
    }

    private static class ViewHolder {
        TextView txtTen, txtMoTa, txtGia;
        ImageView imgHinh, imgDelete, imgEdit;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder holder;

        if (convertView == null) {
            holder = new ViewHolder();
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(layout, null);

            holder.txtTen = convertView.findViewById(R.id.textViewTen);
            holder.txtMoTa = convertView.findViewById(R.id.textViewMoTa);
            holder.txtGia = convertView.findViewById(R.id.textViewGia);
            holder.imgHinh = convertView.findViewById(R.id.imageViewHinh);
            holder.imgEdit = convertView.findViewById(R.id.imageViewEdit);
            holder.imgDelete = convertView.findViewById(R.id.imageViewDelete);

            convertView.setTag(holder);

        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        final MonAn monAn = monAnList.get(position);

        holder.txtTen.setText(monAn.getTen());
        holder.txtMoTa.setText(monAn.getMoTa());
        holder.txtGia.setText(monAn.getGia());

        // Hiển thị ảnh từ đường dẫn nội bộ
        if (monAn.getHinh() != null && !monAn.getHinh().isEmpty()) {
            holder.imgHinh.setImageURI(Uri.fromFile(new File(monAn.getHinh())));
        } else {
            holder.imgHinh.setImageResource(R.mipmap.ic_launcher);
        }

        holder.imgEdit.setOnClickListener(v -> {
            Intent intent = new Intent(context, EditMonAnActivity.class);
            intent.putExtra("monan", monAn);
            ((Activity) context).startActivityForResult(intent, MainActivity.EDIT_MONAN_REQUEST);
        });

        holder.imgDelete.setOnClickListener(v -> {
            if (context instanceof MainActivity) {
                ((MainActivity) context).deleteMonAn(monAn.getId());
            }
        });

        return convertView;
    }
}
