# EduTask - Ứng dụng Quản lý Bài tập & Deadline

Ứng dụng Android quản lý bài tập và deadline được xây dựng với Firebase.

## Tính năng chính

### 🔐 1. Xác thực người dùng (Authentication)
- Đăng ký / đăng nhập bằng email – password
- Lưu thông tin người dùng
- Phân quyền: Sinh viên / Giảng viên

### 📚 2. Quản lý môn học
- Thêm / sửa / xóa môn học
- Thông tin: Tên môn, Mã môn, Giảng viên, Học kỳ

### 📝 3. Quản lý bài tập
- Thêm bài tập cho từng môn
- Thông tin bài tập:
  - Tên bài tập
  - Mô tả
  - Deadline
  - Trạng thái (Chưa làm / Đang làm / Hoàn thành)
  - Làm cá nhân / làm nhóm
- Lọc bài tập: Tất cả / Gần deadline / Quá hạn / Hoàn thành

### ⏰ 4. Quản lý deadline & nhắc nhở
- Hiển thị danh sách bài tập theo:
  - Gần deadline
  - Đã quá hạn
- Gửi thông báo nhắc trước deadline:
  - Trước 1 ngày
  - Trước 3 giờ

### 👥 5. Làm việc nhóm
- Tạo nhóm học tập
- Mời thành viên tham gia nhóm (đang phát triển)
- Phân công bài tập cho từng người
- Theo dõi tiến độ từng thành viên

### 📊 6. Thống kê – báo cáo
- Số bài tập:
  - Đã hoàn thành
  - Chưa hoàn thành
  - Quá hạn
  - Đang làm

## Cấu trúc Database Firebase

### Collection: users
```json
{
  "userId": "uid",
  "name": "Nguyễn Văn A",
  "email": "a@gmail.com",
  "role": "student"
}
```

### Collection: subjects
```json
{
  "subjectId": "sub01",
  "userId": "uid",
  "name": "Lập trình Android",
  "code": "AND101",
  "teacher": "Thầy B",
  "semester": "HK1 2025"
}
```

### Collection: assignments
```json
{
  "assignmentId": "bt01",
  "subjectId": "sub01",
  "title": "Bài tập Firebase",
  "description": "Xây dựng app Android",
  "deadline": "2026-01-20",
  "status": "doing",
  "isGroup": true,
  "groupId": "g01",
  "userId": "uid"
}
```

### Collection: groups
```json
{
  "groupId": "g01",
  "groupName": "Nhóm Android",
  "members": ["uid1", "uid2"],
  "leaderId": "uid1"
}
```

## Cài đặt

### 1. Cấu hình Firebase

1. Tạo project mới trên [Firebase Console](https://console.firebase.google.com/)
2. Thêm Android app vào project
3. Tải file `google-services.json` và đặt vào thư mục `app/`
4. Bật các tính năng:
   - Authentication (Email/Password)
   - Cloud Firestore
   - Cloud Messaging (FCM)

### 2. Cấu hình Firestore Rules

```javascript
rules_version = '2';
service cloud.firestore {
  match /databases/{database}/documents {
    // Users collection
    match /users/{userId} {
      allow read, write: if request.auth != null && request.auth.uid == userId;
    }
    
    // Subjects collection
    match /subjects/{subjectId} {
      allow read, write: if request.auth != null && 
        resource.data.userId == request.auth.uid;
    }
    
    // Assignments collection
    match /assignments/{assignmentId} {
      allow read, write: if request.auth != null && 
        resource.data.userId == request.auth.uid;
    }
    
    // Groups collection
    match /groups/{groupId} {
      allow read: if request.auth != null && 
        request.auth.uid in resource.data.members;
      allow write: if request.auth != null && 
        request.auth.uid == resource.data.leaderId;
    }
  }
}
```

### 3. Build và chạy

```bash
./gradlew build
./gradlew installDebug
```

## Cấu trúc Project

```
app/
├── src/main/
│   ├── java/com/example/edutask/
│   │   ├── activities/
│   │   │   ├── LoginActivity.java
│   │   │   ├── RegisterActivity.java
│   │   │   └── MainActivity.java
│   │   ├── fragments/
│   │   │   ├── SubjectsFragment.java
│   │   │   ├── AssignmentsFragment.java
│   │   │   ├── GroupsFragment.java
│   │   │   └── StatisticsFragment.java
│   │   ├── adapters/
│   │   │   ├── SubjectAdapter.java
│   │   │   ├── AssignmentAdapter.java
│   │   │   └── GroupAdapter.java
│   │   ├── models/
│   │   │   ├── User.java
│   │   │   ├── Subject.java
│   │   │   ├── Assignment.java
│   │   │   └── Group.java
│   │   ├── services/
│   │   │   ├── FirebaseAuthService.java
│   │   │   ├── FirestoreService.java
│   │   │   └── NotificationService.java
│   │   └── receivers/
│   │       └── DeadlineReminderReceiver.java
│   └── res/
│       ├── layout/
│       └── menu/
└── google-services.json (cần thêm từ Firebase Console)
```

## Lưu ý

- Cần thêm file `google-services.json` từ Firebase Console vào thư mục `app/`
- Cần cấu hình Firestore Rules như trên
- Cần bật Email/Password authentication trong Firebase Console
- Cần cấp quyền POST_NOTIFICATIONS cho Android 13+

## Phát triển tiếp

- [ ] Hoàn thiện tính năng mời thành viên vào nhóm
- [ ] Thêm biểu đồ tiến độ học tập
- [ ] Thêm tính năng upload file bài tập
- [ ] Thêm chat trong nhóm
- [ ] Thêm tính năng nhắc nhở tùy chỉnh
