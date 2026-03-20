package com.example.quickcall;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.FrameLayout;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;

import java.util.Random;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {
    private Random random = new Random();
    private int[] animations = {
            R.anim.alpha,
            R.anim.scale,
            R.anim.translate,
            R.anim.rotate
    };
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initView();
    }

    private void initView() {
        findViewById(R.id.fr_mom).setOnClickListener(this);
        findViewById(R.id.fr_dad).setOnClickListener(this);
        findViewById(R.id.fr_crush).setOnClickListener(this);
        findViewById(R.id.fr_best_friend).setOnClickListener(this);
        findViewById(R.id.iv_dialer).setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        if (v instanceof FrameLayout) {
            int randomAnim = animations[random.nextInt(animations.length)];
            Animation anim = AnimationUtils.loadAnimation(this, randomAnim);
            anim.setAnimationListener(new Animation.AnimationListener() {
                @Override
                public void onAnimationStart(Animation animation) {}

                @Override
                public void onAnimationEnd(Animation animation) {
                    // Gọi điện sau khi animation kết thúc
                    processCall((String) v.getTag());
                }

                @Override
                public void onAnimationRepeat(Animation animation) {}
            });

            v.startAnimation(anim);

        } else {
            gotoDialPad();
        }
    }

    private void gotoDialPad() {
        Intent intent = new Intent(Intent.ACTION_DIAL);
        startActivity(intent);
    }

    private void processCall(String phone) {
        // Kiểm tra quyền CALL_PHONE
        if (checkSelfPermission(Manifest.permission.CALL_PHONE)
                != PackageManager.PERMISSION_GRANTED) {
            requestPermissions(new String[]{Manifest.permission.CALL_PHONE}, 101);
            Toast.makeText(this, "Hãy thực hiện lại sau khi cấp quyền!", Toast.LENGTH_SHORT).show();
            return;
        }
        // Thực hiện cuộc gọi
        Intent intent = new Intent(Intent.ACTION_CALL);
        intent.setData(Uri.parse("tel:" + phone));
        startActivity(intent);
    }
}