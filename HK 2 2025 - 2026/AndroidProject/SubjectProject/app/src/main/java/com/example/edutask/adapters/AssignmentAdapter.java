package com.example.edutask.adapters;

import android.content.Context;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.core.content.ContextCompat;
import androidx.recyclerview.widget.RecyclerView;

import com.example.edutask.R;
import com.example.edutask.models.Assignment;
import com.google.android.material.chip.Chip;

import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Locale;

public class AssignmentAdapter extends RecyclerView.Adapter<AssignmentAdapter.AssignmentViewHolder> {
    private List<Assignment> assignmentList;
    private OnStatusChangeListener statusChangeListener;
    private OnAssignmentDeleteListener deleteListener;

    public interface OnStatusChangeListener {
        void onStatusChange(Assignment assignment, String newStatus);
    }

    public interface OnAssignmentDeleteListener {
        void onAssignmentDelete(Assignment assignment);
    }

    public AssignmentAdapter(List<Assignment> assignmentList, OnStatusChangeListener statusChangeListener, OnAssignmentDeleteListener deleteListener) {
        this.assignmentList = assignmentList;
        this.statusChangeListener = statusChangeListener;
        this.deleteListener = deleteListener;
    }

    @NonNull
    @Override
    public AssignmentViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_assignment, parent, false);
        return new AssignmentViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull AssignmentViewHolder holder, int position) {
        Assignment assignment = assignmentList.get(position);
        Context context = holder.itemView.getContext();

        holder.tvTitle.setText(assignment.getTitle());
        holder.tvDescription.setText(assignment.getDescription());

        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy HH:mm", Locale.getDefault());
        if (assignment.getDeadline() != null) {
            holder.tvDeadline.setText("Deadline: " + sdf.format(assignment.getDeadline()));
        }

        // Status display
        String statusText;
        int statusColorRes;
        switch (assignment.getStatus()) {
            case Assignment.STATUS_COMPLETED:
                statusText = "Hoàn thành";
                statusColorRes = R.color.status_completed;
                break;
            case Assignment.STATUS_DOING:
                statusText = "Đang làm";
                statusColorRes = R.color.status_in_progress;
                break;
            default:
                statusText = "Chưa làm";
                statusColorRes = R.color.status_not_started;
                break;
        }
        holder.chipStatus.setText(statusText);
        holder.chipStatus.setChipBackgroundColor(ColorStateList.valueOf(ContextCompat.getColor(context, statusColorRes)));

        // Overdue indicator
        if (assignment.isOverdue()) {
            holder.tvDeadline.setTextColor(ContextCompat.getColor(context, R.color.status_overdue));
            holder.tvDeadline.setText(holder.tvDeadline.getText() + " (QUÁ HẠN)");
            holder.ivCalendar.setImageTintList(ColorStateList.valueOf(ContextCompat.getColor(context, R.color.status_overdue)));
        } else {
            holder.tvDeadline.setTextColor(Color.GRAY);
            holder.ivCalendar.setImageTintList(ColorStateList.valueOf(Color.GRAY));
        }

        holder.chipType.setText(assignment.isGroup() ? "Nhóm" : "Cá nhân");

        // Status change buttons
        holder.itemView.setOnClickListener(v -> {
            String currentStatus = assignment.getStatus();
            String newStatus;
            if (currentStatus.equals(Assignment.STATUS_NOT_STARTED)) {
                newStatus = Assignment.STATUS_DOING;
            } else if (currentStatus.equals(Assignment.STATUS_DOING)) {
                newStatus = Assignment.STATUS_COMPLETED;
            } else {
                newStatus = Assignment.STATUS_NOT_STARTED;
            }
            statusChangeListener.onStatusChange(assignment, newStatus);
        });

        holder.itemView.setOnLongClickListener(v -> {
            deleteListener.onAssignmentDelete(assignment);
            return true;
        });
    }

    @Override
    public int getItemCount() {
        return assignmentList.size();
    }

    static class AssignmentViewHolder extends RecyclerView.ViewHolder {
        TextView tvTitle, tvDescription, tvDeadline;
        Chip chipStatus, chipType;
        ImageView ivCalendar;

        AssignmentViewHolder(@NonNull View itemView) {
            super(itemView);
            tvTitle = itemView.findViewById(R.id.tvTitle);
            tvDescription = itemView.findViewById(R.id.tvDescription);
            tvDeadline = itemView.findViewById(R.id.tvDeadline);
            chipStatus = itemView.findViewById(R.id.chipStatus);
            chipType = itemView.findViewById(R.id.chipType);
            ivCalendar = itemView.findViewById(R.id.ivCalendar);
        }
    }
}
