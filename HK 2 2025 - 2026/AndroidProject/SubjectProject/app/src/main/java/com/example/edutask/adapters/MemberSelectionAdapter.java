package com.example.edutask.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.edutask.R;
import com.example.edutask.models.User;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class MemberSelectionAdapter extends RecyclerView.Adapter<MemberSelectionAdapter.MemberViewHolder> {
    private List<User> userList;
    private Set<String> selectedUserIds = new HashSet<>();
    private OnMemberSelectedListener listener;

    public interface OnMemberSelectedListener {
        void onMemberSelected(User user, boolean isSelected);
    }

    public MemberSelectionAdapter(List<User> userList, OnMemberSelectedListener listener) {
        this.userList = new ArrayList<>(userList);
        this.listener = listener;
    }

    @NonNull
    @Override
    public MemberViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_member_selection, parent, false);
        return new MemberViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull MemberViewHolder holder, int position) {
        User user = userList.get(position);
        boolean isSelected = selectedUserIds.contains(user.getUserId());

        holder.checkBox.setOnCheckedChangeListener(null);
        holder.checkBox.setChecked(isSelected);
        holder.tvUserName.setText(user.getName());
        holder.tvUserEmail.setText(user.getEmail());

        holder.checkBox.setOnCheckedChangeListener((buttonView, checked) -> {
            if (checked) {
                selectedUserIds.add(user.getUserId());
            } else {
                selectedUserIds.remove(user.getUserId());
            }
            listener.onMemberSelected(user, checked);
        });

        holder.itemView.setOnClickListener(v -> holder.checkBox.performClick());
    }

    @Override
    public int getItemCount() {
        return userList.size();
    }

    public void updateList(List<User> newList) {
        userList.clear();
        userList.addAll(newList);
        notifyDataSetChanged();
    }

    static class MemberViewHolder extends RecyclerView.ViewHolder {
        TextView tvUserName, tvUserEmail;
        CheckBox checkBox;

        MemberViewHolder(@NonNull View itemView) {
            super(itemView);
            tvUserName = itemView.findViewById(R.id.tvUserName);
            tvUserEmail = itemView.findViewById(R.id.tvUserEmail);
            checkBox = itemView.findViewById(R.id.checkBox);
        }
    }
}
