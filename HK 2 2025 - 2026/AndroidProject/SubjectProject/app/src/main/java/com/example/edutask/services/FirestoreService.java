package com.example.edutask.services;

import android.util.Log;

import com.example.edutask.models.Assignment;
import com.example.edutask.models.Group;
import com.example.edutask.models.Subject;
import com.example.edutask.models.User;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.Timestamp;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.Query;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;
import com.google.firebase.firestore.SetOptions;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import androidx.annotation.NonNull;

public class FirestoreService {
    private static final String TAG = "FirestoreService";
    private FirebaseFirestore db;

    public FirestoreService() {
        db = FirebaseFirestore.getInstance();
    }

    // User operations
    public void getUser(String userId, OnCompleteListener<DocumentSnapshot> listener) {
        db.collection("users").document(userId).get().addOnCompleteListener(listener);
    }

    // Subject operations
    public void addSubject(Subject subject, OnSuccessListener<Void> onSuccess, OnFailureListener onFailure) {
        Map<String, Object> subjectMap = new HashMap<>();
        subjectMap.put("subjectId", subject.getSubjectId());
        subjectMap.put("userId", subject.getUserId());
        subjectMap.put("name", subject.getName());
        subjectMap.put("code", subject.getCode());
        subjectMap.put("teacher", subject.getTeacher());
        subjectMap.put("semester", subject.getSemester());

        db.collection("subjects").document(subject.getSubjectId())
                .set(subjectMap)
                .addOnSuccessListener(onSuccess)
                .addOnFailureListener(onFailure);
    }

    public void getSubjectsByUser(String userId, OnCompleteListener<QuerySnapshot> listener) {
        db.collection("subjects")
                .whereEqualTo("userId", userId)
                .get()
                .addOnCompleteListener(listener);
    }

    public void updateSubject(Subject subject, OnSuccessListener<Void> onSuccess, OnFailureListener onFailure) {
        Map<String, Object> subjectMap = new HashMap<>();
        subjectMap.put("name", subject.getName());
        subjectMap.put("code", subject.getCode());
        subjectMap.put("teacher", subject.getTeacher());
        subjectMap.put("semester", subject.getSemester());

        db.collection("subjects").document(subject.getSubjectId())
                .update(subjectMap)
                .addOnSuccessListener(onSuccess)
                .addOnFailureListener(onFailure);
    }

    public void deleteSubject(String subjectId, OnSuccessListener<Void> onSuccess, OnFailureListener onFailure) {
        db.collection("subjects").document(subjectId)
                .delete()
                .addOnSuccessListener(onSuccess)
                .addOnFailureListener(onFailure);
    }

    // Assignment operations
    public void addAssignment(Assignment assignment, OnSuccessListener<DocumentReference> onSuccess, OnFailureListener onFailure) {
        Map<String, Object> assignmentMap = new HashMap<>();
        assignmentMap.put("assignmentId", assignment.getAssignmentId());
        assignmentMap.put("subjectId", assignment.getSubjectId());
        assignmentMap.put("title", assignment.getTitle());
        assignmentMap.put("description", assignment.getDescription());
        assignmentMap.put("deadline", assignment.getDeadline() != null ? 
                new Timestamp(assignment.getDeadline()) : null);
        assignmentMap.put("status", assignment.getStatus());
        assignmentMap.put("isGroup", assignment.isGroup());
        assignmentMap.put("groupId", assignment.getGroupId());
        assignmentMap.put("userId", assignment.getUserId());

        db.collection("assignments")
                .add(assignmentMap)
                .addOnSuccessListener(onSuccess)
                .addOnFailureListener(onFailure);
    }

    public void getAssignmentsBySubject(String subjectId, OnCompleteListener<QuerySnapshot> listener) {
        db.collection("assignments")
                .whereEqualTo("subjectId", subjectId)
                .orderBy("deadline", Query.Direction.ASCENDING)
                .get()
                .addOnCompleteListener(listener);
    }

    public void getAssignmentsByUser(String userId, OnCompleteListener<QuerySnapshot> listener) {
        db.collection("assignments")
                .whereEqualTo("userId", userId)
                .orderBy("deadline", Query.Direction.ASCENDING)
                .get()
                .addOnCompleteListener(listener);
    }

    public void getAssignmentsByGroup(String groupId, OnCompleteListener<QuerySnapshot> listener) {
        db.collection("assignments")
                .whereEqualTo("groupId", groupId)
                .orderBy("deadline", Query.Direction.ASCENDING)
                .get()
                .addOnCompleteListener(listener);
    }

    public void getUpcomingAssignments(String userId, Date beforeDate, OnCompleteListener<QuerySnapshot> listener) {
        db.collection("assignments")
                .whereEqualTo("userId", userId)
                .whereLessThan("deadline", new Timestamp(beforeDate))
                .whereNotEqualTo("status", Assignment.STATUS_COMPLETED)
                .orderBy("deadline", Query.Direction.ASCENDING)
                .get()
                .addOnCompleteListener(listener);
    }

    public void getOverdueAssignments(String userId, OnCompleteListener<QuerySnapshot> listener) {
        Date now = new Date();
        db.collection("assignments")
                .whereEqualTo("userId", userId)
                .whereLessThan("deadline", new Timestamp(now))
                .whereNotEqualTo("status", Assignment.STATUS_COMPLETED)
                .orderBy("deadline", Query.Direction.ASCENDING)
                .get()
                .addOnCompleteListener(listener);
    }

    public void updateAssignmentStatus(String assignmentId, String status, OnSuccessListener<Void> onSuccess, OnFailureListener onFailure) {
        db.collection("assignments").document(assignmentId)
                .update("status", status)
                .addOnSuccessListener(onSuccess)
                .addOnFailureListener(onFailure);
    }

    public void deleteAssignment(String assignmentId, OnSuccessListener<Void> onSuccess, OnFailureListener onFailure) {
        db.collection("assignments").document(assignmentId)
                .delete()
                .addOnSuccessListener(onSuccess)
                .addOnFailureListener(onFailure);
    }

    // Group operations
    public void createGroup(Group group, OnSuccessListener<DocumentReference> onSuccess, OnFailureListener onFailure) {
        Map<String, Object> groupMap = new HashMap<>();
        groupMap.put("groupId", group.getGroupId());
        groupMap.put("groupName", group.getGroupName());
        groupMap.put("members", group.getMembers());
        groupMap.put("leaderId", group.getLeaderId());

        db.collection("groups")
                .add(groupMap)
                .addOnSuccessListener(onSuccess)
                .addOnFailureListener(onFailure);
    }

    public void getGroupsByMember(String userId, OnCompleteListener<QuerySnapshot> listener) {
        db.collection("groups")
                .whereArrayContains("members", userId)
                .get()
                .addOnCompleteListener(listener);
    }

    public void addMemberToGroup(String groupId, String userId, OnSuccessListener<Void> onSuccess, OnFailureListener onFailure) {
        db.collection("groups").document(groupId)
                .update("members", com.google.firebase.firestore.FieldValue.arrayUnion(userId))
                .addOnSuccessListener(onSuccess)
                .addOnFailureListener(onFailure);
    }

    public void removeMemberFromGroup(String groupId, String userId, OnSuccessListener<Void> onSuccess, OnFailureListener onFailure) {
        db.collection("groups").document(groupId)
                .update("members", com.google.firebase.firestore.FieldValue.arrayRemove(userId))
                .addOnSuccessListener(onSuccess)
                .addOnFailureListener(onFailure);
    }

    // Statistics
    public void getAssignmentStats(String userId, OnCompleteListener<QuerySnapshot> listener) {
        db.collection("assignments")
                .whereEqualTo("userId", userId)
                .get()
                .addOnCompleteListener(listener);
    }
}
