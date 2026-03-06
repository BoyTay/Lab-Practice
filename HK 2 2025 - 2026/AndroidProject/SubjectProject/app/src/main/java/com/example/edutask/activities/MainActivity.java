package com.example.edutask.activities;

import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import com.example.edutask.R;
import com.example.edutask.fragments.CalendarFragment;
import com.example.edutask.fragments.CreateGroupFragment;
import com.example.edutask.fragments.GroupsFragment;
import com.example.edutask.fragments.HomeFragment;
import com.example.edutask.fragments.ProfileFragment;
import com.example.edutask.models.Assignment;
import com.example.edutask.models.Subject;
import com.example.edutask.services.FirebaseAuthService;
import com.example.edutask.services.FirestoreService;
import com.example.edutask.services.NotificationService;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.QueryDocumentSnapshot;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
import java.util.Locale;
import java.util.UUID;

public class MainActivity extends AppCompatActivity {

    private FirebaseAuthService authService;
    private FirestoreService firestoreService;
    private NotificationService notificationService;
    private List<Subject> subjectList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        authService = new FirebaseAuthService();
        firestoreService = new FirestoreService();
        notificationService = new NotificationService(this);
        subjectList = new ArrayList<>();

        if (!authService.isLoggedIn()) {
            startActivity(new Intent(this, LoginActivity.class));
            finish();
            return;
        }

        BottomNavigationView bottomNavigationView = findViewById(R.id.bottomNavigationView);
        FloatingActionButton fab = findViewById(R.id.fab);

        bottomNavigationView.setBackground(null);
        bottomNavigationView.getMenu().getItem(2).setEnabled(false);

        fab.setOnClickListener(v -> {
            Fragment currentFragment = getSupportFragmentManager().findFragmentById(R.id.fragment_container);
            if (currentFragment instanceof GroupsFragment) {
                getSupportFragmentManager().beginTransaction()
                        .replace(R.id.fragment_container, new CreateGroupFragment())
                        .addToBackStack(null)
                        .commit();
            } else {
                showAddAssignmentDialog();
            }
        });

        bottomNavigationView.setOnItemSelectedListener(item -> {
            Fragment selectedFragment = null;
            int itemId = item.getItemId();

            if (itemId == R.id.navigation_home) {
                selectedFragment = new HomeFragment();
            } else if (itemId == R.id.navigation_group) {
                selectedFragment = new GroupsFragment();
            } else if (itemId == R.id.navigation_calendar) {
                selectedFragment = new CalendarFragment();
            } else if (itemId == R.id.navigation_profile) {
                selectedFragment = new ProfileFragment();
            }

            if (selectedFragment != null) {
                getSupportFragmentManager().beginTransaction().replace(R.id.fragment_container, selectedFragment).commit();
                return true;
            }
            return false;
        });

        if (savedInstanceState == null) {
            bottomNavigationView.setSelectedItemId(R.id.navigation_home);
        }
        
        loadSubjects();
    }

    private void loadSubjects() {
        FirebaseUser user = authService.getCurrentUser();
        if (user == null) return;

        firestoreService.getSubjectsByUser(user.getUid(), task -> {
            if (task.isSuccessful()) {
                subjectList.clear();
                for (QueryDocumentSnapshot document : task.getResult()) {
                    subjectList.add(document.toObject(Subject.class));
                }
            }
        });
    }

    private void showAddAssignmentDialog() {
        if (subjectList.isEmpty()) {
            Toast.makeText(this, "Vui lòng thêm môn học trước!", Toast.LENGTH_SHORT).show();
            return;
        }

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        View dialogView = getLayoutInflater().inflate(R.layout.dialog_add_assignment, null);
        builder.setView(dialogView);

        final EditText etTitle = dialogView.findViewById(R.id.etTitle);
        final EditText etDeadline = dialogView.findViewById(R.id.etDeadline);
        final Spinner spinnerSubject = dialogView.findViewById(R.id.spinnerSubject);

        ArrayAdapter<Subject> subjectAdapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, subjectList);
        subjectAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerSubject.setAdapter(subjectAdapter);

        final Calendar calendar = Calendar.getInstance();
        etDeadline.setOnClickListener(v -> {
            new DatePickerDialog(this, (view, year, month, day) -> {
                calendar.set(year, month, day);
                SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());
                etDeadline.setText(sdf.format(calendar.getTime()));
            }, calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH), calendar.get(Calendar.DAY_OF_MONTH)).show();
        });

        builder.setPositiveButton("Thêm", (dialog, which) -> {
            String title = etTitle.getText().toString().trim();
            if (title.isEmpty() || etDeadline.getText().toString().isEmpty()) {
                Toast.makeText(this, "Vui lòng điền đầy đủ thông tin", Toast.LENGTH_SHORT).show();
                return;
            }
            Subject selectedSubject = (Subject) spinnerSubject.getSelectedItem();
            FirebaseUser user = authService.getCurrentUser();
            if (user == null) return;

            Assignment assignment = new Assignment(UUID.randomUUID().toString(), selectedSubject.getSubjectId(), title, "", calendar.getTime(), Assignment.STATUS_NOT_STARTED, false, user.getUid());

            firestoreService.addAssignment(assignment,
                    documentReference -> {
                        Toast.makeText(this, "Thêm bài tập thành công!", Toast.LENGTH_SHORT).show();
                        notificationService.scheduleDeadlineReminders(assignment);
                        Fragment currentFragment = getSupportFragmentManager().findFragmentById(R.id.fragment_container);
                        if (currentFragment instanceof HomeFragment) {
                            ((HomeFragment) currentFragment).refreshData();
                        }
                    },
                    e -> Toast.makeText(this, "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show());
        });
        builder.setNegativeButton("Hủy", null).show();
    }
}
