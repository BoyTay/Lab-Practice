package com.example.edutask.fragments;

import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.edutask.R;
import com.example.edutask.adapters.AssignmentAdapter;
import com.example.edutask.models.Assignment;
import com.example.edutask.models.Subject;
import com.example.edutask.services.FirebaseAuthService;
import com.example.edutask.services.FirestoreService;
import com.example.edutask.services.NotificationService;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.UUID;

public class AssignmentsFragment extends Fragment {
    private RecyclerView recyclerView;
    private FloatingActionButton fabAdd;
    private AssignmentAdapter adapter;
    private List<Assignment> assignmentList;
    private List<Subject> subjectList;
    private FirestoreService firestoreService;
    private FirebaseAuthService authService;
    private NotificationService notificationService;
    private Spinner spinnerFilter;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_assignments, container, false);

        recyclerView = view.findViewById(R.id.recyclerView);
        fabAdd = view.findViewById(R.id.fabAdd);
        spinnerFilter = view.findViewById(R.id.spinnerFilter);

        firestoreService = new FirestoreService();
        authService = new FirebaseAuthService();
        notificationService = new NotificationService(getContext());

        assignmentList = new ArrayList<>();
        subjectList = new ArrayList<>();
        adapter = new AssignmentAdapter(assignmentList, this::updateAssignmentStatus, this::deleteAssignment);
        recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));
        recyclerView.setAdapter(adapter);

        // Setup filter spinner
        ArrayAdapter<String> filterAdapter = new ArrayAdapter<>(getContext(),
                android.R.layout.simple_spinner_item,
                new String[]{"Tất cả", "Gần deadline", "Quá hạn", "Hoàn thành"});
        filterAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerFilter.setAdapter(filterAdapter);
        spinnerFilter.setOnItemSelectedListener(new android.widget.AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(android.widget.AdapterView<?> parent, View view, int position, long id) {
                loadAssignments();
            }

            @Override
            public void onNothingSelected(android.widget.AdapterView<?> parent) {
            }
        });

        fabAdd.setOnClickListener(v -> showAddDialog());

        loadSubjects();
        loadAssignments();

        return view;
    }

    private void loadSubjects() {
        FirebaseUser user = authService.getCurrentUser();
        if (user == null) return;

        firestoreService.getSubjectsByUser(user.getUid(), task -> {
            if (task.isSuccessful()) {
                subjectList.clear();
                for (QueryDocumentSnapshot document : task.getResult()) {
                    Subject subject = new Subject(
                            document.getString("subjectId"),
                            document.getString("userId"),
                            document.getString("name"),
                            document.getString("code"),
                            document.getString("teacher"),
                            document.getString("semester")
                    );
                    subjectList.add(subject);
                }
            }
        });
    }

    private void loadAssignments() {
        FirebaseUser user = authService.getCurrentUser();
        if (user == null) return;

        int filterPosition = spinnerFilter.getSelectedItemPosition();

        if (filterPosition == 1) { // Gần deadline
            Calendar calendar = Calendar.getInstance();
            calendar.add(Calendar.DAY_OF_MONTH, 7);
            firestoreService.getUpcomingAssignments(user.getUid(), calendar.getTime(), task -> {
                processAssignments(task);
            });
        } else if (filterPosition == 2) { // Quá hạn
            firestoreService.getOverdueAssignments(user.getUid(), task -> {
                processAssignments(task);
            });
        } else if (filterPosition == 3) { // Hoàn thành
            firestoreService.getAssignmentsByUser(user.getUid(), task -> {
                if (task.isSuccessful()) {
                    assignmentList.clear();
                    for (QueryDocumentSnapshot document : task.getResult()) {
                        if (Assignment.STATUS_COMPLETED.equals(document.getString("status"))) {
                            assignmentList.add(createAssignmentFromDocument(document));
                        }
                    }
                    adapter.notifyDataSetChanged();
                }
            });
        } else { // Tất cả
            firestoreService.getAssignmentsByUser(user.getUid(), task -> {
                processAssignments(task);
            });
        }
    }

    private void processAssignments(Task<QuerySnapshot> task) {
        if (task.isSuccessful()) {
            assignmentList.clear();
            for (QueryDocumentSnapshot document : task.getResult()) {
                assignmentList.add(createAssignmentFromDocument(document));
            }
            adapter.notifyDataSetChanged();
        }
    }

    private Assignment createAssignmentFromDocument(QueryDocumentSnapshot document) {
        Assignment assignment = new Assignment();
        assignment.setAssignmentId(document.getId());
        assignment.setSubjectId(document.getString("subjectId"));
        assignment.setTitle(document.getString("title"));
        assignment.setDescription(document.getString("description"));
        
        // Handle deadline
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

    private void showAddDialog() {
        if (subjectList.isEmpty()) {
            Toast.makeText(getContext(), "Vui lòng thêm môn học trước!", Toast.LENGTH_SHORT).show();
            return;
        }

        AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
        View dialogView = LayoutInflater.from(getContext()).inflate(R.layout.dialog_add_assignment, null);
        builder.setView(dialogView);

        EditText etTitle = dialogView.findViewById(R.id.etTitle);
        EditText etDescription = dialogView.findViewById(R.id.etDescription);
        EditText etDeadline = dialogView.findViewById(R.id.etDeadline);
        Spinner spinnerSubject = dialogView.findViewById(R.id.spinnerSubject);
        Spinner spinnerStatus = dialogView.findViewById(R.id.spinnerStatus);
        CheckBox cbIsGroup = dialogView.findViewById(R.id.cbIsGroup);

        // Setup subject spinner
        ArrayAdapter<Subject> subjectAdapter = new ArrayAdapter<>(getContext(),
                android.R.layout.simple_spinner_item, subjectList);
        subjectAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerSubject.setAdapter(subjectAdapter);

        // Setup status spinner
        ArrayAdapter<String> statusAdapter = new ArrayAdapter<>(getContext(),
                android.R.layout.simple_spinner_item,
                new String[]{Assignment.STATUS_NOT_STARTED, Assignment.STATUS_DOING, Assignment.STATUS_COMPLETED});
        statusAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerStatus.setAdapter(statusAdapter);

        // Date picker
        Calendar calendar = Calendar.getInstance();
        etDeadline.setOnClickListener(v -> {
            DatePickerDialog datePickerDialog = new DatePickerDialog(getContext(),
                    (view, year, month, dayOfMonth) -> {
                        calendar.set(year, month, dayOfMonth);
                        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());
                        etDeadline.setText(sdf.format(calendar.getTime()));
                    },
                    calendar.get(Calendar.YEAR),
                    calendar.get(Calendar.MONTH),
                    calendar.get(Calendar.DAY_OF_MONTH));
            datePickerDialog.show();
        });

        builder.setPositiveButton("Thêm", (dialog, which) -> {
            String title = etTitle.getText().toString().trim();
            String description = etDescription.getText().toString().trim();
            String deadlineStr = etDeadline.getText().toString().trim();

            if (title.isEmpty() || deadlineStr.isEmpty()) {
                Toast.makeText(getContext(), "Vui lòng điền đầy đủ thông tin", Toast.LENGTH_SHORT).show();
                return;
            }

            Subject selectedSubject = (Subject) spinnerSubject.getSelectedItem();
            String status = (String) spinnerStatus.getSelectedItem();
            boolean isGroup = cbIsGroup.isChecked();

            FirebaseUser user = authService.getCurrentUser();
            if (user == null) return;

            Assignment assignment = new Assignment(
                    UUID.randomUUID().toString(),
                    selectedSubject.getSubjectId(),
                    title,
                    description,
                    calendar.getTime(),
                    status,
                    isGroup,
                    user.getUid()
            );

            firestoreService.addAssignment(assignment,
                    documentReference -> {
                        Toast.makeText(getContext(), "Thêm bài tập thành công!", Toast.LENGTH_SHORT).show();
                        notificationService.scheduleDeadlineReminders(assignment);
                        loadAssignments();
                    },
                    e -> Toast.makeText(getContext(), "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show()
            );
        });

        builder.setNegativeButton("Hủy", null);
        builder.show();
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
                                notificationService.cancelReminders(assignment.getAssignmentId());
                                loadAssignments();
                            },
                            e -> Toast.makeText(getContext(), "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show()
                    );
                })
                .setNegativeButton("Hủy", null)
                .show();
    }
}
