package com.example.customgridview;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

public class ContributorAdapter extends BaseAdapter {

    private Context context;
    private List<Contributor> contributorList;

    public ContributorAdapter(Context context, List<Contributor> contributorList) {
        this.context = context;
        this.contributorList = contributorList;
    }

    @Override
    public int getCount() {
        return contributorList.size();
    }

    @Override
    public Object getItem(int position) {
        return contributorList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if (convertView == null) {
            convertView = LayoutInflater.from(context).inflate(R.layout.item_contributor, parent, false);
        }

        Contributor contributor = contributorList.get(position);

        ImageView imgContributor = convertView.findViewById(R.id.img_contributor);
        TextView tvName = convertView.findViewById(R.id.tv_name);
        TextView tvScore = convertView.findViewById(R.id.tv_score);

        imgContributor.setImageResource(contributor.getImageResId());
        tvName.setText(contributor.getName());
        tvScore.setText(contributor.getScore());

        return convertView;
    }
}
