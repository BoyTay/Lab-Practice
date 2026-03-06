package com.example.edutask.fragments;

import android.app.AlertDialog;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.edutask.R;
import com.example.edutask.adapters.AssignmentAdapter;
import com.example.edutask.models.Assignment;
import com.example.edutask.services.FirebaseAuthService;
import com.example.edutask.services.FirestoreService;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

public class AssignmentsFragment extends Fragment {
    private static final String TAG = "AssignmentsFragment";
    private RecyclerView recyclerView;
    private ImageView ivFilter;
    private AssignmentAdapter adapter;
    private List<Assignment> assignmentList;
    private FirestoreService firestoreService;
    private FirebaseAuthService authService;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_assignments, container, false);

        Toolbar toolbar = view.findViewById(R.id.toolbar);
        recyclerView = view.findViewById(R.id.recyclerView);
        ivFilter = view.findViewById(R.id.ivFilter);

        firestoreService = new FirestoreService();
        authService = new FirebaseAuthService();

        assignmentList = new ArrayList<>();
        adapter = new AssignmentAdapter(assignmentList, this::updateAssignmentStatus, this::deleteAssignment);
        recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));
        recyclerView.setAdapter(adapter);

        ivFilter.setOnClickListener(v -> showFilterDialog());

        loadAssignments();

        return view;
    }

    private void showFilterDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
        builder.setTitle("Lọc bài tập");
        String[] filterOptions = {"Tất cả", "Gần deadline", "Quá hạn", "Hoàn thành"};
        builder.setItems(filterOptions, (dialog, which) -> {
            loadAssignmentsByFilter(which);
        });
        builder.show();
    }

    private void loadAssignmentsByFilter(int filterPosition) {
        FirebaseUser user = authService.getCurrentUser();
        if (user == null) {
            Log.e(TAG, "Current user is null. Cannot load assignments.");
            return;
        }

        String userId = user.getUid();

        if (filterPosition == 1) { // Gần deadline
            Calendar calendar = Calendar.getInstance();
            calendar.add(Calendar.DAY_OF_MONTH, 7);
            firestoreService.getUpcomingAssignments(userId, calendar.getTime(), this::processAssignments);
        } else if (filterPosition == 2) { // Quá hạn
            firestoreService.getOverdueAssignments(userId, this::processAssignments);
        } else if (filterPosition == 3) { // Hoàn thành
            firestoreService.getAssignmentsByUserAndStatus(userId, Assignment.STATUS_COMPLETED, this::processAssignments);
        } else { // Tất cả
            firestoreService.getAssignmentsByUser(userId, this::processAssignments);
        }
    }

    private void loadAssignments() {
        loadAssignmentsByFilter(0); // Load "Tất cả" by default
    }

    private void processAssignments(Task<QuerySnapshot> task) {
        if (task.isSuccessful()) {
            assignmentList.clear();
            for (QueryDocumentSnapshot document : task.getResult()) {
                assignmentList.add(createAssignmentFromDocument(document));
            }
            adapter.notifyDataSetChanged();
        } else {
            Log.e(TAG, "Error getting documents: ", task.getException());
            Toast.makeText(getContext(), "Failed to load assignments.", Toast.LENGTH_SHORT).show();
        }
    }

    private Assignment createAssignmentFromDocument(QueryDocumentSnapshot document) {
        Assignment assignment = new Assignment();
        assignment.setAssignmentId(document.getId());
        assignment.setSubjectId(document.getString("subjectId"));
        assignment.setTitle(document.getString("title"));
        assignment.setDescription(document.getString("description"));

        Object deadlineObj = document.get("deadline");
        if (deadlineObj instanceof com.google.firebase.Timestamp) {
            assignment.setDeadline(((com.google.firebase.Timestamp) deadlineObj).toDate());
        } else if (deadlineObj instanceof Date) {
            assignment.setDeadline((Date) deadlineObj);
        }

        assignment.setStatus(document.getString("status"));
        assignment.setGroup(document.getBoolean("isGroup") != null && document.getBoolean("isGroup"));
        assignment.setGroupId(document.getString("groupId"));
        assignment.setUserId(document.getString("userId"));
        return assignment;
    }

    private void updateAssignmentStatus(Assignment assignment, String newStatus) {
        firestoreService.updateAssignmentStatus(assignment.getAssignmentId(), newStatus,
                aVoid -> {
                    Toast.makeText(getContext(), "Cập nhật thành công!", Toast.LENGTH_SHORT).show();
                    loadAssignments();
                },
                e -> Toast.makeText(getContext(), "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show()
        );
    }

    private void deleteAssignment(Assignment assignment) {
        new AlertDialog.Builder(getContext())
                .setTitle("Xóa bài tập")
                .setMessage("Bạn có chắc chắn muốn xóa bài tập này?")
                .setPositiveButton("Xóa", (dialog, which) -> {
                    firestoreService.deleteAssignment(assignment.getAssignmentId(),
                            aVoid -> {
                                Toast.makeText(getContext(), "Xóa thành công!", Toast.LENGTH_SHORT).show();
                                loadAssignments();
                            },
                            e -> Toast.makeText(getContext(), "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show()
                    );
                })
                .setNegativeButton("Hủy", null)
                .show();
    }
}
