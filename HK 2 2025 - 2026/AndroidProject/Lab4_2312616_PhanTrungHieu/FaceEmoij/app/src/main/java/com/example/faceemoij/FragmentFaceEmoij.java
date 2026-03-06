package com.example.faceemoij;

import android.content.Context;
import android.graphics.drawable.Drawable;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import java.util.Random;

public class FragmentFaceEmoij extends Fragment implements View.OnClickListener {
    private static final int[] ids = {R.id.iv_face1, R.id.iv_face2, R.id.iv_face3, R.id.iv_face4,
            R.id.iv_face5, R.id.iv_face6, R.id.iv_face7, R.id.iv_face8, R.id.iv_face9};

    private static final int[] icons = {
            R.drawable.ic_angry,
            R.drawable.ic_cry,
            R.drawable.ic_cute,
            R.drawable.ic_laugh,
            R.drawable.ic_sad,
            R.drawable.ic_sick,
            R.drawable.ic_sleep,
            R.drawable.ic_smile,
            R.drawable.ic_wow
    };

    private ImageView[] imageViews;
    private Context mContext;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.m001_frg_face_emoij, container, false);
        initViews(rootView);
        return rootView;
    }

    @Override
    public void onAttach(Context context) {
        mContext = context;
        super.onAttach(context);
    }

    private void initViews(View v) {
        imageViews = new ImageView[ids.length];
        for (int i = 0; i < ids.length; i++) {
            imageViews[i] = v.findViewById(ids[i]);
            imageViews[i].setOnClickListener(this);
        }

        Button btnRandom = v.findViewById(R.id.btn_random);
        btnRandom.setOnClickListener(view -> randomizeIcons());
    }

    private void randomizeIcons() {
        Random random = new Random();
        for (ImageView iv : imageViews) {
            int randomIndex = random.nextInt(icons.length);
            iv.setImageResource(icons[randomIndex]);
        }
    }

    @Override
    public void onClick(View v) {
        ImageView ivFace = (ImageView) v;
        showToast(ivFace.getDrawable());
    }

    private void showToast(Drawable drawable) {
        Toast toast = new Toast(mContext);
        ImageView ivEmoij = new ImageView(mContext);
        ivEmoij.setImageDrawable(drawable);
        toast.setView(ivEmoij);
        toast.show();
    }
}



