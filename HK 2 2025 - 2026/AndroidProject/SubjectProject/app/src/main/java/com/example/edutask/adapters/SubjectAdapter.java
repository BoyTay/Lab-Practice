package com.example.edutask.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.edutask.R;
import com.example.edutask.models.Subject;

import java.util.List;

public class SubjectAdapter extends RecyclerView.Adapter<SubjectAdapter.SubjectViewHolder> {
    private List<Subject> subjectList;
    private OnSubjectClickListener clickListener;
    private OnSubjectDeleteListener deleteListener;

    public interface OnSubjectClickListener {
        void onSubjectClick(Subject subject);
    }

    public interface OnSubjectDeleteListener {
        void onSubjectDelete(Subject subject);
    }

    public SubjectAdapter(List<Subject> subjectList, OnSubjectClickListener clickListener, OnSubjectDeleteListener deleteListener) {
        this.subjectList = subjectList;
        this.clickListener = clickListener;
        this.deleteListener = deleteListener;
    }

    @NonNull
    @Override
    public SubjectViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_subject, parent, false);
        return new SubjectViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull SubjectViewHolder holder, int position) {
        Subject subject = subjectList.get(position);
        holder.tvName.setText(subject.getName());
        holder.tvCode.setText("Mã: " + subject.getCode());
        holder.tvTeacher.setText("GV: " + subject.getTeacher());
        holder.tvSemester.setText("HK: " + subject.getSemester());

        holder.itemView.setOnClickListener(v -> clickListener.onSubjectClick(subject));
        holder.itemView.setOnLongClickListener(v -> {
            deleteListener.onSubjectDelete(subject);
            return true;
        });
    }

    @Override
    public int getItemCount() {
        return subjectList.size();
    }

    static class SubjectViewHolder extends RecyclerView.ViewHolder {
        TextView tvName, tvCode, tvTeacher, tvSemester;

        SubjectViewHolder(@NonNull View itemView) {
            super(itemView);
            tvName = itemView.findViewById(R.id.tvName);
            tvCode = itemView.findViewById(R.id.tvCode);
            tvTeacher = itemView.findViewById(R.id.tvTeacher);
            tvSemester = itemView.findViewById(R.id.tvSemester);
        }
    }
}
