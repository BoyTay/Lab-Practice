package com.example.edutask.fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.example.edutask.R;
import com.example.edutask.models.Assignment;
import com.example.edutask.services.FirebaseAuthService;
import com.example.edutask.services.FirestoreService;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.Date;

public class StatisticsFragment extends Fragment {
    private TextView tvCompleted, tvInProgress, tvNotStarted, tvOverdue;
    private FirestoreService firestoreService;
    private FirebaseAuthService authService;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_statistics, container, false);

        tvCompleted = view.findViewById(R.id.tvCompleted);
        tvInProgress = view.findViewById(R.id.tvInProgress);
        tvNotStarted = view.findViewById(R.id.tvNotStarted);
        tvOverdue = view.findViewById(R.id.tvOverdue);

        firestoreService = new FirestoreService();
        authService = new FirebaseAuthService();

        loadStatistics();

        return view;
    }

    private void loadStatistics() {
        FirebaseUser user = authService.getCurrentUser();
        if (user == null) return;

        firestoreService.getAssignmentStats(user.getUid(), task -> {
            if (task.isSuccessful()) {
                int completed = 0;
                int inProgress = 0;
                int notStarted = 0;
                int overdue = 0;

                Date now = new Date();

                for (QueryDocumentSnapshot document : task.getResult()) {
                    String status = document.getString("status");
                    Object deadlineObj = document.get("deadline");
                    if (deadlineObj == null) continue;
                    
                    Date deadline;
                    if (deadlineObj instanceof com.google.firebase.Timestamp) {
                        deadline = ((com.google.firebase.Timestamp) deadlineObj).toDate();
                    } else if (deadlineObj instanceof Date) {
                        deadline = (Date) deadlineObj;
                    } else {
                        continue;
                    }

                    if (Assignment.STATUS_COMPLETED.equals(status)) {
                        completed++;
                    } else if (Assignment.STATUS_DOING.equals(status)) {
                        inProgress++;
                    } else if (Assignment.STATUS_NOT_STARTED.equals(status)) {
                        notStarted++;
                    }

                    if (deadline.before(now) && !Assignment.STATUS_COMPLETED.equals(status)) {
                        overdue++;
                    }
                }

                tvCompleted.setText("Hoàn thành: " + completed);
                tvInProgress.setText("Đang làm: " + inProgress);
                tvNotStarted.setText("Chưa làm: " + notStarted);
                tvOverdue.setText("Quá hạn: " + overdue);
            }
        });
    }
}
