package com.example.funnystories;
import android.os.Bundle;
import android.os.Handler;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import androidx.fragment.app.Fragment;

public class M000SplashFrg extends Fragment {
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.m000_frg_splash, container, false);
        initViews(view);
        return view;
    }

    private void initViews(View view) {
        // Chuyển màn sau 2s
        new Handler().postDelayed(this::gotoM001Screen, 2000);
    }

    private void gotoM001Screen() {
        if (getActivity() != null) {
            ((MainActivity) getActivity()).gotoM001Screen();
        }
    }
}
