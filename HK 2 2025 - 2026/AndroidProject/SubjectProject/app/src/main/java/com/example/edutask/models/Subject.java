package com.example.edutask.models;

import java.io.Serializable;

public class Subject implements Serializable {
    private String subjectId;
    private String userId;
    private String name;
    private String code;
    private String teacher;
    private String semester;

    public Subject() {
        // Default constructor required for Firestore
    }

    public Subject(String subjectId, String userId, String name, String code, String teacher, String semester) {
        this.subjectId = subjectId;
        this.userId = userId;
        this.name = name;
        this.code = code;
        this.teacher = teacher;
        this.semester = semester;
    }

    public String getSubjectId() {
        return subjectId;
    }

    public void setSubjectId(String subjectId) {
        this.subjectId = subjectId;
    }

    public String getUserId() {
        return userId;
    }

    public void setUserId(String userId) {
        this.userId = userId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getCode() {
        return code;
    }

    public void setCode(String code) {
        this.code = code;
    }

    public String getTeacher() {
        return teacher;
    }

    public void setTeacher(String teacher) {
        this.teacher = teacher;
    }

    public String getSemester() {
        return semester;
    }

    public void setSemester(String semester) {
        this.semester = semester;
    }
}
