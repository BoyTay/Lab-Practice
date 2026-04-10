package com.example.customgridview;

import android.os.Bundle;
import android.widget.GridView;

import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        GridView gvContributors = findViewById(R.id.gv_contributors);

        List<Contributor> contributorList = new ArrayList<>();
        // Note: Using ic_launcher as placeholder images. You should add your own images to res/drawable.
        contributorList.add(new Contributor("Maboo", "283,297", R.drawable.iphone));
        contributorList.add(new Contributor("SameOldShawn", "252,433", R.drawable.huawei));
        contributorList.add(new Contributor("Magnitude901", "164,935", R.drawable.ipad));
        contributorList.add(new Contributor("Brandon", "100,466", R.drawable.macbook));
        contributorList.add(new Contributor("Clement_RGF", "93,932", R.drawable.samsung));
        contributorList.add(new Contributor("Nebja", "84,187", R.drawable.xiaomi));
        contributorList.add(new Contributor("BBDS", "81,762", R.drawable.window_phone));
        ContributorAdapter adapter = new ContributorAdapter(this, contributorList);
        gvContributors.setAdapter(adapter);
    }
}
