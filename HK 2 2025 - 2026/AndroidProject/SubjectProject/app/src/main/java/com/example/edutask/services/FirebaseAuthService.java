package com.example.edutask.services;

import android.app.Activity;
import android.util.Log;

import com.example.edutask.models.User;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.FirebaseFirestore;

import androidx.annotation.NonNull;

public class FirebaseAuthService {
    private static final String TAG = "FirebaseAuthService";
    private FirebaseAuth mAuth;
    private FirebaseFirestore db;

    public FirebaseAuthService() {
        mAuth = FirebaseAuth.getInstance();
        db = FirebaseFirestore.getInstance();
    }

    public interface AuthCallback {
        void onSuccess(FirebaseUser user);
        void onFailure(String error);
    }

    public void register(String email, String password, String name, String role, AuthCallback callback) {
        mAuth.createUserWithEmailAndPassword(email, password)
                .addOnCompleteListener(task -> {
                    if (task.isSuccessful()) {
                        FirebaseUser firebaseUser = mAuth.getCurrentUser();
                        if (firebaseUser != null) {
                            // Create user document in Firestore
                            User user = new User(firebaseUser.getUid(), name, email, role);
                            db.collection("users")
                                    .document(firebaseUser.getUid())
                                    .set(user)
                                    .addOnSuccessListener(aVoid -> {
                                        Log.d(TAG, "User document created");
                                        callback.onSuccess(firebaseUser);
                                    })
                                    .addOnFailureListener(e -> {
                                        Log.e(TAG, "Error creating user document", e);
                                        callback.onFailure(e.getMessage());
                                    });
                        }
                    } else {
                        Log.e(TAG, "Registration failed", task.getException());
                        callback.onFailure(task.getException() != null ? 
                                task.getException().getMessage() : "Registration failed");
                    }
                });
    }

    public void login(String email, String password, AuthCallback callback) {
        mAuth.signInWithEmailAndPassword(email, password)
                .addOnCompleteListener(task -> {
                    if (task.isSuccessful()) {
                        FirebaseUser user = mAuth.getCurrentUser();
                        if (user != null) {
                            callback.onSuccess(user);
                        } else {
                            callback.onFailure("User is null");
                        }
                    } else {
                        Log.e(TAG, "Login failed", task.getException());
                        callback.onFailure(task.getException() != null ? 
                                task.getException().getMessage() : "Login failed");
                    }
                });
    }

    public void logout() {
        mAuth.signOut();
    }

    public FirebaseUser getCurrentUser() {
        return mAuth.getCurrentUser();
    }

    public boolean isLoggedIn() {
        return mAuth.getCurrentUser() != null;
    }
}
