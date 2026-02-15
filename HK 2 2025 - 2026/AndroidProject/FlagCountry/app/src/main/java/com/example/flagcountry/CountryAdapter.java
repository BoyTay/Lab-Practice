package com.example.flagcountry;

import android.content.Context;
import android.net.Uri;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.bumptech.glide.Glide;

import java.util.ArrayList;
import java.util.List;

public class CountryAdapter extends BaseAdapter {

    private Context context;
    private List<Country> countryList;

    public CountryAdapter(Context context, List<Country> countryList) {
        this.context = context;
        this.countryList = new ArrayList<>(countryList);
    }

    public void updateData(List<Country> newCountryList) {
        countryList.clear();
        countryList.addAll(newCountryList);
        notifyDataSetChanged();
    }

    @Override
    public int getCount() {
        return countryList.size();
    }

    @Override
    public Object getItem(int position) {
        return countryList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return countryList.get(position).getId();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        ViewHolder holder;
        if (convertView == null) {
            convertView = LayoutInflater.from(context).inflate(R.layout.item_country, parent, false);
            holder = new ViewHolder();
            holder.imgFlag = convertView.findViewById(R.id.imgFlag);
            holder.txtName = convertView.findViewById(R.id.txtName);
            holder.txtPopulation = convertView.findViewById(R.id.txtPopulation);
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        Country country = countryList.get(position);

        holder.txtName.setText(country.getName());
        holder.txtPopulation.setText(country.getPopulation());

        // Use Glide to load the image from the URI
        if (country.getImageUri() != null) {
            Glide.with(context)
                    .load(Uri.parse(country.getImageUri()))
                    .placeholder(R.mipmap.ic_launcher) // Optional placeholder
                    .error(R.mipmap.ic_launcher) // Optional error image
                    .into(holder.imgFlag);
        } else {
            // If there is no image URI, show a default image
            holder.imgFlag.setImageResource(R.mipmap.ic_launcher);
        }

        return convertView;
    }

    static class ViewHolder {
        ImageView imgFlag;
        TextView txtName;
        TextView txtPopulation;
    }
}
