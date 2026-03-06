package com.example.edutask.fragments;

import android.os.Bundle;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.edutask.R;
import com.example.edutask.adapters.MemberSelectionAdapter;
import com.example.edutask.models.Group;
import com.example.edutask.models.User;
import com.example.edutask.services.FirebaseAuthService;
import com.example.edutask.services.FirestoreService;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.QueryDocumentSnapshot;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class CreateGroupFragment extends Fragment {
    private EditText etGroupName, etGroupDesc, etSearchMembers;
    private RecyclerView rvMemberSuggestions;
    private Button btnCreateGroup;
    private TextView tvCancel, tvMemberCount;

    private MemberSelectionAdapter memberAdapter;
    private List<User> allUsers = new ArrayList<>();
    private List<User> selectedMembers = new ArrayList<>();
    private FirestoreService firestoreService;
    private FirebaseAuthService authService;
    private FirebaseUser currentUser;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_create_group, container, false);

        // Initialize views
        etGroupName = view.findViewById(R.id.etGroupName);
        etGroupDesc = view.findViewById(R.id.etGroupDesc);
        etSearchMembers = view.findViewById(R.id.etSearchMembers);
        rvMemberSuggestions = view.findViewById(R.id.rvMemberSuggestions);
        btnCreateGroup = view.findViewById(R.id.btnCreateGroup);
        tvCancel = view.findViewById(R.id.tvCancel);
        tvMemberCount = view.findViewById(R.id.tvMemberCount);

        // Initialize services
        firestoreService = new FirestoreService();
        authService = new FirebaseAuthService();
        currentUser = authService.getCurrentUser();

        if (currentUser == null) {
            Toast.makeText(getContext(), "Bạn cần đăng nhập để tạo nhóm", Toast.LENGTH_SHORT).show();
            dismissFragment();
            return view;
        }

        // Setup RecyclerView for member suggestions
        rvMemberSuggestions.setLayoutManager(new LinearLayoutManager(getContext()));
        memberAdapter = new MemberSelectionAdapter(allUsers, this::onMemberSelected);
        rvMemberSuggestions.setAdapter(memberAdapter);

        // Load all users for member selection
        loadAllUsers();

        // Setup listeners
        tvCancel.setOnClickListener(v -> dismissFragment());
        btnCreateGroup.setOnClickListener(v -> createGroup());

        etSearchMembers.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {}

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                filterMembers(s.toString());
            }

            @Override
            public void afterTextChanged(Editable s) {}
        });

        return view;
    }

    private void loadAllUsers() {
        firestoreService.getAllUsers().addOnCompleteListener(task -> {
            if (task.isSuccessful() && task.getResult() != null) {
                allUsers.clear();
                for (QueryDocumentSnapshot doc : task.getResult()) {
                    User user = doc.toObject(User.class);
                    if (user == null) {
                        continue;
                    }
                    if (TextUtils.isEmpty(user.getUserId())) {
                        user.setUserId(doc.getId());
                    }
                    if (currentUser != null && user.getUserId().equals(currentUser.getUid())) {
                        continue;
                    }
                    allUsers.add(user);
                }
                memberAdapter.updateList(allUsers);
                updateMemberCount();
            } else {
                Toast.makeText(getContext(), "Lỗi tải danh sách thành viên", Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void filterMembers(String query) {
        if (TextUtils.isEmpty(query)) {
            memberAdapter.updateList(allUsers);
        } else {
            List<User> filtered = new ArrayList<>();
            String lowerQuery = query.toLowerCase();
            for (User user : allUsers) {
                String name = user.getName() != null ? user.getName() : "";
                String email = user.getEmail() != null ? user.getEmail() : "";
                if (name.toLowerCase().contains(lowerQuery) || email.toLowerCase().contains(lowerQuery)) {
                    filtered.add(user);
                }
            }
            memberAdapter.updateList(filtered);
        }
    }

    private void onMemberSelected(User user, boolean isSelected) {
        if (user == null || TextUtils.isEmpty(user.getUserId())) {
            return;
        }
        if (isSelected) {
            addSelectedMember(user);
        } else {
            removeSelectedMember(user.getUserId());
        }
        updateMemberCount();
    }

    private void addSelectedMember(User user) {
        for (User member : selectedMembers) {
            if (user.getUserId().equals(member.getUserId())) {
                return;
            }
        }
        selectedMembers.add(user);
    }

    private void removeSelectedMember(String userId) {
        if (TextUtils.isEmpty(userId)) {
            return;
        }
        for (int i = 0; i < selectedMembers.size(); i++) {
            if (userId.equals(selectedMembers.get(i).getUserId())) {
                selectedMembers.remove(i);
                break;
            }
        }
    }

    private void updateMemberCount() {
        tvMemberCount.setText("Đã chọn: " + selectedMembers.size() + " thành viên");
    }

    private void createGroup() {
        String groupName = etGroupName.getText().toString().trim();
        String groupDesc = etGroupDesc.getText().toString().trim();

        if (TextUtils.isEmpty(groupName)) {
            etGroupName.setError("Vui lòng nhập tên nhóm");
            return;
        }

        if (selectedMembers.isEmpty()) {
            Toast.makeText(getContext(), "Vui lòng chọn ít nhất 1 thành viên", Toast.LENGTH_SHORT).show();
            return;
        }

        // Tạo danh sách thành viên bao gồm chính mình
        List<String> memberIds = new ArrayList<>();
        memberIds.add(currentUser.getUid());
        for (User user : selectedMembers) {
            memberIds.add(user.getUserId());
        }

        String groupId = UUID.randomUUID().toString();
        Group newGroup = new Group(groupId, groupName, groupDesc, memberIds, currentUser.getUid());

        btnCreateGroup.setEnabled(false);
        firestoreService.createGroup(newGroup,
            docRef -> {
                Toast.makeText(getContext(), "Tạo nhóm thành công!", Toast.LENGTH_SHORT).show();
                dismissFragment();
            },
            e -> {
                Toast.makeText(getContext(), "Lỗi: " + e.getMessage(), Toast.LENGTH_SHORT).show();
                btnCreateGroup.setEnabled(true);
            });
    }

    private void dismissFragment() {
        if (getActivity() != null) {
            getActivity().getSupportFragmentManager().popBackStack();
        }
    }
}
