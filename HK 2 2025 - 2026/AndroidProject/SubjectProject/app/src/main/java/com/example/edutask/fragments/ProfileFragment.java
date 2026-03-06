package com.example.edutask.fragments;

import android.content.ClipData;
import android.content.ClipboardManager;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.example.edutask.R;
import com.example.edutask.activities.LoginActivity;
import com.example.edutask.services.FirebaseAuthService;
import com.google.firebase.auth.FirebaseUser;

public class ProfileFragment extends Fragment {

    private FirebaseAuthService authService;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_profile, container, false);

        authService = new FirebaseAuthService();

        // Setup Setting Items
        View itemEditProfile = view.findViewById(R.id.itemEditProfile);
        setupSettingItem(itemEditProfile, R.drawable.ic_person_24, "Chỉnh sửa hồ sơ", v -> Toast.makeText(getContext(), "Chỉnh sửa hồ sơ", Toast.LENGTH_SHORT).show());

        View itemLinkAccount = view.findViewById(R.id.itemLinkAccount);
        setupSettingItem(itemLinkAccount, R.drawable.ic_link_24, "Liên kết tài khoản", v -> Toast.makeText(getContext(), "Liên kết tài khoản", Toast.LENGTH_SHORT).show());

        View itemNotifications = view.findViewById(R.id.itemNotifications);
        setupSettingItem(itemNotifications, R.drawable.ic_notifications_24, "Cài đặt thông báo", v -> Toast.makeText(getContext(), "Cài đặt thông báo", Toast.LENGTH_SHORT).show());

        View itemHelp = view.findViewById(R.id.itemHelp);
        setupSettingItem(itemHelp, R.drawable.ic_help_outline_24, "Trợ giúp & Phản hồi", v -> Toast.makeText(getContext(), "Trợ giúp & Phản hồi", Toast.LENGTH_SHORT).show());

        // User Info
        TextView tvUserName = view.findViewById(R.id.tvUserName);
        TextView tvUserEduId = view.findViewById(R.id.tvUserEduId);
        FirebaseUser currentUser = authService.getCurrentUser();
        if (currentUser != null) {
            tvUserName.setText(currentUser.getDisplayName() != null && !currentUser.getDisplayName().isEmpty() ? currentUser.getDisplayName() : "Tên người dùng");
            tvUserEduId.setText("EDU-" + currentUser.getUid().substring(0, 8).toUpperCase());
        }

        // Button Click Listeners
        Button btnCopyId = view.findViewById(R.id.btnCopyId);
        btnCopyId.setOnClickListener(v -> {
            ClipboardManager clipboard = (ClipboardManager) getContext().getSystemService(Context.CLIPBOARD_SERVICE);
            ClipData clip = ClipData.newPlainText("EduID", tvUserEduId.getText().toString());
            clipboard.setPrimaryClip(clip);
            Toast.makeText(getContext(), "Đã sao chép ID", Toast.LENGTH_SHORT).show();
        });

        Button btnLogout = view.findViewById(R.id.btnLogout);
        btnLogout.setOnClickListener(v -> {
            authService.logout();
            Intent intent = new Intent(getActivity(), LoginActivity.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(intent);
        });

        return view;
    }

    private void setupSettingItem(View itemView, int iconResId, String title, View.OnClickListener listener) {
        ImageView icon = itemView.findViewById(R.id.ivIcon);
        TextView tvTitle = itemView.findViewById(R.id.tvTitle);
        icon.setImageResource(iconResId);
        tvTitle.setText(title);
        itemView.setOnClickListener(listener);
    }
}
