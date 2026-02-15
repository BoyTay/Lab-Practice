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
import com.example.edutask.adapters.GroupAdapter;
import com.example.edutask.models.Group;
import com.example.edutask.services.FirebaseAuthService;
import com.example.edutask.services.FirestoreService;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.UUID;

public class GroupsFragment extends Fragment {
    private RecyclerView recyclerView;
    private FloatingActionButton fabAdd;
    private GroupAdapter adapter;
    private List<Group> groupList;
    private FirestoreService firestoreService;
    private FirebaseAuthService authService;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_groups, container, false);

        recyclerView = view.findViewById(R.id.recyclerView);
        fabAdd = view.findViewById(R.id.fabAdd);

        firestoreService = new FirestoreService();
        authService = new FirebaseAuthService();

        groupList = new ArrayList<>();
        adapter = new GroupAdapter(groupList, this::showGroupDetails);
        recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));
        recyclerView.setAdapter(adapter);

        fabAdd.setOnClickListener(v -> showCreateGroupDialog());

        loadGroups();

        return view;
    }

    private void loadGroups() {
        FirebaseUser user = authService.getCurrentUser();
        if (user == null) return;

        firestoreService.getGroupsByMember(user.getUid(), task -> {
            if (task.isSuccessful()) {
                groupList.clear();
                for (QueryDocumentSnapshot document : task.getResult()) {
                    Group group = new Group(
                            document.getId(),
                            document.getString("groupName"),
                            (List<String>) document.get("members"),
                            document.getString("leaderId")
                    );
                    groupList.add(group);
                }
                adapter.notifyDataSetChanged();
            }
        });
    }

    private void showCreateGroupDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
        View dialogView = LayoutInflater.from(getContext()).inflate(R.layout.dialog_create_group, null);
        builder.setView(dialogView);

        EditText etGroupName = dialogView.findViewById(R.id.etGroupName);

        builder.setPositiveButton("Tạo", (dialog, which) -> {
            String groupName = etGroupName.getText().toString().trim();

            if (groupName.isEmpty()) {
                Toast.makeText(getContext(), "Vui lòng nhập tên nhóm", Toast.LENGTH_SHORT).show();
                return;
            }

            FirebaseUser user = authService.getCurrentUser();
            if (user == null) return;

            Group group = new Group(
                    UUID.randomUUID().toString(),
                    groupName,
                    Arrays.asList(user.getUid()),
                    user.getUid()
            );

            firestoreService.createGroup(group,
                    documentReference -> {
                        Toast.makeText(getContext(), "Tạo nhóm thành công!", Toast.LENGTH_SHORT).show();
                        loadGroups();
                    },
                    e -> Toast.makeText(getContext(), "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show()
            );
        });

        builder.setNegativeButton("Hủy", null);
        builder.show();
    }

    private void showGroupDetails(Group group) {
        FirebaseUser user = authService.getCurrentUser();
        if (user == null) return;

        AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
        builder.setTitle(group.getGroupName());
        builder.setMessage("Thành viên: " + (group.getMembers() != null ? group.getMembers().size() : 0) + " người");

        if (group.getLeaderId().equals(user.getUid())) {
            // Show invite option for leader
            EditText etEmail = new EditText(getContext());
            etEmail.setHint("Email thành viên");
            builder.setView(etEmail);
            builder.setPositiveButton("Mời", (dialog, which) -> {
                String email = etEmail.getText().toString().trim();
                // In a real app, you would look up user by email and add to group
                Toast.makeText(getContext(), "Tính năng mời thành viên đang được phát triển", Toast.LENGTH_SHORT).show();
            });
        }

        builder.setNegativeButton("Đóng", null);
        builder.show();
    }
}
