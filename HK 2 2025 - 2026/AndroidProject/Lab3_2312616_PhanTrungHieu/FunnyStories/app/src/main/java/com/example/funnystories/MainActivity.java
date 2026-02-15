package com.example.funnystories;

import android.os.Bundle;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        showFrg(new M000SplashFrg());
    }

    private void showFrg(Fragment frg) {
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.ln_main, frg, null)
                .addToBackStack(null)
                .commit();
    }

    public void gotoM001Screen() {
        getSupportFragmentManager().popBackStack(); // Clear back stack before going to main screen
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.ln_main, new M001StoryListFrg(), null)
                .commit();
    }

    public void gotoM002Screen(String topicName) {
        showFrg(new M002StoryListFrg(topicName));
    }

    public void backToM001Screen() {
        getSupportFragmentManager().popBackStack();
    }

    public void gotoM003Screen(StoryEntity story) {
        showFrg(M003StoryDetailFrg.newInstance(story));
    }
}
