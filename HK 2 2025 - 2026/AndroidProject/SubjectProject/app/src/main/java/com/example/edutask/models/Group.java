package com.example.edutask.models;

import java.io.Serializable;
import java.util.List;

public class Group implements Serializable {
    private String groupId;
    private String groupName;
    private String groupDesc;
    private List<String> members; // List of user IDs
    private String leaderId; // Group leader/creator

    public Group() {
        // Default constructor required for Firestore
    }

    public Group(String groupId, String groupName, String groupDesc, List<String> members, String leaderId) {
        this.groupId = groupId;
        this.groupName = groupName;
        this.groupDesc = groupDesc;
        this.members = members;
        this.leaderId = leaderId;
    }

    public String getGroupId() {
        return groupId;
    }

    public void setGroupId(String groupId) {
        this.groupId = groupId;
    }

    public String getGroupName() {
        return groupName;
    }

    public void setGroupName(String groupName) {
        this.groupName = groupName;
    }

    public String getGroupDesc() {
        return groupDesc;
    }

    public void setGroupDesc(String groupDesc) {
        this.groupDesc = groupDesc;
    }

    public List<String> getMembers() {
        return members;
    }

    public void setMembers(List<String> members) {
        this.members = members;
    }

    public String getLeaderId() {
        return leaderId;
    }

    public void setLeaderId(String leaderId) {
        this.leaderId = leaderId;
    }

    public boolean isMember(String userId) {
        return members != null && members.contains(userId);
    }
}
