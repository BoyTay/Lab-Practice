package com.example.edutask.models;

import java.io.Serializable;
import java.util.Date;

public class Assignment implements Serializable {
    public static final String STATUS_NOT_STARTED = "not_started";
    public static final String STATUS_DOING = "doing";
    public static final String STATUS_COMPLETED = "completed";

    private String assignmentId;
    private String subjectId;
    private String title;
    private String description;
    private Date deadline;
    private String status; // "not_started", "doing", "completed"
    private boolean isGroup;
    private String groupId; // null if individual assignment
    private String userId; // owner/creator

    public Assignment() {
        // Default constructor required for Firestore
    }

    public Assignment(String assignmentId, String subjectId, String title, String description, 
                     Date deadline, String status, boolean isGroup, String userId) {
        this.assignmentId = assignmentId;
        this.subjectId = subjectId;
        this.title = title;
        this.description = description;
        this.deadline = deadline;
        this.status = status;
        this.isGroup = isGroup;
        this.userId = userId;
    }

    public String getAssignmentId() {
        return assignmentId;
    }

    public void setAssignmentId(String assignmentId) {
        this.assignmentId = assignmentId;
    }

    public String getSubjectId() {
        return subjectId;
    }

    public void setSubjectId(String subjectId) {
        this.subjectId = subjectId;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Date getDeadline() {
        return deadline;
    }

    public void setDeadline(Date deadline) {
        this.deadline = deadline;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public boolean isGroup() {
        return isGroup;
    }

    public void setGroup(boolean group) {
        isGroup = group;
    }

    public String getGroupId() {
        return groupId;
    }

    public void setGroupId(String groupId) {
        this.groupId = groupId;
    }

    public String getUserId() {
        return userId;
    }

    public void setUserId(String userId) {
        this.userId = userId;
    }

    public boolean isOverdue() {
        if (deadline == null) return false;
        return deadline.before(new Date()) && !status.equals(STATUS_COMPLETED);
    }
}
