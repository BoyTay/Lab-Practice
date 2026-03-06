package com.example.account;

import android.content.Context;
import android.graphics.drawable.Drawable;
import android.graphics.drawable.GradientDrawable;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.ColorRes;
import androidx.annotation.DrawableRes;
import androidx.core.content.ContextCompat;

public final class CustomToast {

    public enum ToastType {
        INFO,
        SUCCESS,
        ERROR
    }

    private CustomToast() {
    }

    public static void show(Context context, String message, ToastType type) {
        if (context == null) {
            return;
        }

        View layout = LayoutInflater.from(context).inflate(R.layout.view_custom_toast, null);
        LinearLayout root = layout.findViewById(R.id.toast_root);
        ImageView icon = layout.findViewById(R.id.toast_icon);
        TextView text = layout.findViewById(R.id.toast_text);

        ToastStyle style = mapStyle(type);
        text.setText(message);
        icon.setImageResource(style.iconRes);
        icon.setColorFilter(ContextCompat.getColor(context, R.color.white));
        tintBackground(root, style.bgColorRes, context);

        Toast toast = new Toast(context.getApplicationContext());
        toast.setView(layout);
        toast.setDuration(Toast.LENGTH_SHORT);
        int yOffset = context.getResources().getDimensionPixelOffset(R.dimen.toast_bottom_offset);
        toast.setGravity(Gravity.BOTTOM | Gravity.CENTER_HORIZONTAL, 0, yOffset);
        toast.show();
    }

    private static ToastStyle mapStyle(ToastType type) {
        if (type == ToastType.SUCCESS) {
            return new ToastStyle(R.color.toast_success_bg, R.drawable.ic_toast_success);
        }
        if (type == ToastType.ERROR) {
            return new ToastStyle(R.color.toast_error_bg, R.drawable.ic_toast_error);
        }
        return new ToastStyle(R.color.toast_info_bg, R.drawable.ic_toast_warning);
    }

    private static void tintBackground(View root, @ColorRes int colorRes, Context context) {
        Drawable background = root.getBackground();
        if (background instanceof GradientDrawable) {
            ((GradientDrawable) background.mutate()).setColor(ContextCompat.getColor(context, colorRes));
        } else {
            root.setBackgroundColor(ContextCompat.getColor(context, colorRes));
        }
    }

    private static class ToastStyle {
        final @ColorRes int bgColorRes;
        final @DrawableRes int iconRes;

        ToastStyle(@ColorRes int bgColorRes, @DrawableRes int iconRes) {
            this.bgColorRes = bgColorRes;
            this.iconRes = iconRes;
        }
    }
}

