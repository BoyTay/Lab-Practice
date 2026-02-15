package com.example.edutask.fragments;

import android.app.AlertDialog;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.edutask.R;
import com.example.edutask.adapters.SubjectAdapter;
import com.example.edutask.models.Subject;
import com.example.edutask.services.FirebaseAuthService;
import com.example.edutask.services.FirestoreService;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class SubjectsFragment extends Fragment {
    private RecyclerView recyclerView;
    private FloatingActionButton fabAdd;
    private SubjectAdapter adapter;
    private List<Subject> subjectList;
    private FirestoreService firestoreService;
    private FirebaseAuthService authService;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_subjects, container, false);

        recyclerView = view.findViewById(R.id.recyclerView);
        fabAdd = view.findViewById(R.id.fabAdd);

        firestoreService = new FirestoreService();
        authService = new FirebaseAuthService();

        subjectList = new ArrayList<>();
        adapter = new SubjectAdapter(subjectList, this::showEditDialog, this::deleteSubject);
        recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));
        recyclerView.setAdapter(adapter);

        fabAdd.setOnClickListener(v -> showAddDialog());

        loadSubjects();

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
                adapter.notifyDataSetChanged();
            }
        });
    }

    private void showAddDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
        View dialogView = LayoutInflater.from(getContext()).inflate(R.layout.dialog_add_subject, null);
        builder.setView(dialogView);

        EditText etName = dialogView.findViewById(R.id.etName);
        EditText etCode = dialogView.findViewById(R.id.etCode);
        EditText etTeacher = dialogView.findViewById(R.id.etTeacher);
        EditText etSemester = dialogView.findViewById(R.id.etSemester);

        builder.setPositiveButton("Thêm", (dialog, which) -> {
            String name = etName.getText().toString().trim();
            String code = etCode.getText().toString().trim();
            String teacher = etTeacher.getText().toString().trim();
            String semester = etSemester.getText().toString().trim();

            if (name.isEmpty() || code.isEmpty()) {
                Toast.makeText(getContext(), "Vui lòng điền đầy đủ thông tin", Toast.LENGTH_SHORT).show();
                return;
            }

            FirebaseUser user = authService.getCurrentUser();
            if (user == null) return;

            Subject subject = new Subject(
                    UUID.randomUUID().toString(),
                    user.getUid(),
                    name,
                    code,
                    teacher,
                    semester
            );

            firestoreService.addSubject(subject,
                    aVoid -> {
                        Toast.makeText(getContext(), "Thêm môn học thành công!", Toast.LENGTH_SHORT).show();
                        loadSubjects();
                    },
                    e -> Toast.makeText(getContext(), "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show()
            );
        });

        builder.setNegativeButton("Hủy", null);
        builder.show();
    }

    private void showEditDialog(Subject subject) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
        View dialogView = LayoutInflater.from(getContext()).inflate(R.layout.dialog_add_subject, null);
        builder.setView(dialogView);

        EditText etName = dialogView.findViewById(R.id.etName);
        EditText etCode = dialogView.findViewById(R.id.etCode);
        EditText etTeacher = dialogView.findViewById(R.id.etTeacher);
        EditText etSemester = dialogView.findViewById(R.id.etSemester);

        etName.setText(subject.getName());
        etCode.setText(subject.getCode());
        etTeacher.setText(subject.getTeacher());
        etSemester.setText(subject.getSemester());

        builder.setTitle("Sửa môn học");
        builder.setPositiveButton("Lưu", (dialog, which) -> {
            subject.setName(etName.getText().toString().trim());
            subject.setCode(etCode.getText().toString().trim());
            subject.setTeacher(etTeacher.getText().toString().trim());
            subject.setSemester(etSemester.getText().toString().trim());

            firestoreService.updateSubject(subject,
                    aVoid -> {
                        Toast.makeText(getContext(), "Cập nhật thành công!", Toast.LENGTH_SHORT).show();
                        loadSubjects();
                    },
                    e -> Toast.makeText(getContext(), "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show()
            );
        });

        builder.setNegativeButton("Hủy", null);
        builder.show();
    }

    private void deleteSubject(Subject subject) {
        new AlertDialog.Builder(getContext())
                .setTitle("Xóa môn học")
                .setMessage("Bạn có chắc chắn muốn xóa môn học này?")
                .setPositiveButton("Xóa", (dialog, which) -> {
                    firestoreService.deleteSubject(subject.getSubjectId(),
                            aVoid -> {
                                Toast.makeText(getContext(), "Xóa thành công!", Toast.LENGTH_SHORT).show();
                                loadSubjects();
                            },
                            e -> Toast.makeText(getContext(), "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show()
                    );
                })
                .setNegativeButton("Hủy", null)
                .show();
    }
}
