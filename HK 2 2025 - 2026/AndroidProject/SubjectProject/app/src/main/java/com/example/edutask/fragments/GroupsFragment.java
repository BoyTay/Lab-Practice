package com.example.edutask.fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
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
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.QueryDocumentSnapshot;

import java.util.ArrayList;
import java.util.List;

public class GroupsFragment extends Fragment {

    private RecyclerView recyclerView;
    private GroupAdapter adapter;
    private List<Group> groupList;
    private FirestoreService firestoreService;
    private FirebaseAuthService authService;
    private View emptyStateView;
    private FloatingActionButton fabCreateGroup;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_groups, container, false);

        // Initialize views and services
        recyclerView = view.findViewById(R.id.recyclerView);
        emptyStateView = view.findViewById(R.id.layoutEmptyState);
        fabCreateGroup = view.findViewById(R.id.fabCreateGroup);
        firestoreService = new FirestoreService();
        authService = new FirebaseAuthService();

        // Setup RecyclerView
        groupList = new ArrayList<>();
        adapter = new GroupAdapter(groupList, this::showGroupDetails);
        recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));
        recyclerView.setAdapter(adapter);

        fabCreateGroup.setOnClickListener(v -> openCreateGroupScreen());

        // Load groups from Firestore
        loadGroups();

        return view;
    }

    private void loadGroups() {
        FirebaseUser user = authService.getCurrentUser();
        if (user == null) {
            updateEmptyState();
            return;
        }

        firestoreService.getGroupsByMember(user.getUid(), task -> {
            if (task.isSuccessful()) {
                groupList.clear();
                for (QueryDocumentSnapshot document : task.getResult()) {
                    Group group = document.toObject(Group.class);
                    group.setGroupId(document.getId());
                    groupList.add(group);
                }
                adapter.notifyDataSetChanged();
                updateEmptyState();
            } else {
                Toast.makeText(getContext(), "Không thể tải danh sách nhóm", Toast.LENGTH_SHORT).show();
                updateEmptyState();
            }
        });
    }

    private void updateEmptyState() {
        if (emptyStateView == null || recyclerView == null) return;
        boolean isEmpty = groupList == null || groupList.isEmpty();
        emptyStateView.setVisibility(isEmpty ? View.VISIBLE : View.GONE);
        recyclerView.setVisibility(isEmpty ? View.GONE : View.VISIBLE);
    }

    private void openCreateGroupScreen() {
        if (getActivity() == null) return;
        getActivity().getSupportFragmentManager()
                .beginTransaction()
                .replace(R.id.fragment_container, new CreateGroupFragment())
                .addToBackStack(null)
                .commit();
    }

    private void showGroupDetails(Group group) {
        // In a real app, you would navigate to a new fragment to show group details.
        Toast.makeText(getContext(), "Xem chi tiết nhóm: " + group.getGroupName(), Toast.LENGTH_SHORT).show();
    }
}
