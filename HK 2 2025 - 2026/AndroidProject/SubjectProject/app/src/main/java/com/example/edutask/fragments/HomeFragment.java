package com.example.edutask.fragments;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.example.edutask.R;
import com.example.edutask.models.User;
import com.example.edutask.services.FirebaseAuthService;
import com.example.edutask.services.FirestoreService;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.firebase.auth.FirebaseUser;

public class HomeFragment extends Fragment {

    private static final String TAG = "HomeFragment";
    private FirebaseAuthService authService;
    private FirestoreService firestoreService;
    private TextView tvGreeting;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_home, container, false);

        authService = new FirebaseAuthService();
        firestoreService = new FirestoreService();

        tvGreeting = view.findViewById(R.id.tvGreeting);

        loadUserInfo();

        // Find and set OnClickListeners for quick access buttons
        LinearLayout btnCreateGroup = view.findViewById(R.id.quick_access_create_group);
        LinearLayout btnFindFriends = view.findViewById(R.id.quick_access_find_friends);

        btnCreateGroup.setOnClickListener(v -> {
            if (getActivity() != null) {
                BottomNavigationView bottomNav = getActivity().findViewById(R.id.bottomNavigationView);
                if (bottomNav != null) {
                    bottomNav.setSelectedItemId(R.id.navigation_group);
                }
            }
        });

        btnFindFriends.setOnClickListener(v -> {
            Toast.makeText(getContext(), "Chức năng Tìm bạn sẽ được triển khai sớm!", Toast.LENGTH_SHORT).show();
        });

        return view;
    }

    private void loadUserInfo() {
        FirebaseUser currentUser = authService.getCurrentUser();
        if (currentUser != null) {
            String userId = currentUser.getUid();
            firestoreService.getUser(userId, task -> {
                if (task.isSuccessful() && task.getResult() != null) {
                    User user = task.getResult().toObject(User.class);
                    if (user != null && user.getName() != null && !user.getName().isEmpty()) {
                        String[] nameParts = user.getName().split(" ");
                        String lastName = nameParts[nameParts.length - 1];
                        tvGreeting.setText("Chào buổi sáng, " + lastName + "! 👋");
                    } else {
                        tvGreeting.setText("Chào buổi sáng! 👋");
                    }
                } else {
                    Log.e(TAG, "Failed to fetch user data from Firestore.");
                    tvGreeting.setText("Chào buổi sáng! 👋");
                }
            });
        }
    }

    public void refreshData() {
        loadUserInfo();
    }
}
