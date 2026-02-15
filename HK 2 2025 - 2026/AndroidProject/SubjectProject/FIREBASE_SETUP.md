# Hướng dẫn cấu hình Firebase

## Bước 1: Tạo Firebase Project

1. Truy cập [Firebase Console](https://console.firebase.google.com/)
2. Click "Add project" hoặc chọn project có sẵn
3. Điền tên project và làm theo hướng dẫn

## Bước 2: Thêm Android App

1. Trong Firebase Console, click biểu tượng Android
2. Điền thông tin:
   - **Package name**: `com.example.edutask` (kiểm tra trong `app/build.gradle.kts`)
   - **App nickname**: EduTask (tùy chọn)
   - **Debug signing certificate SHA-1**: (tùy chọn, cần cho các tính năng nâng cao)
3. Click "Register app"
4. Tải file `google-services.json`
5. **QUAN TRỌNG**: Đặt file `google-services.json` vào thư mục `app/` (cùng cấp với `build.gradle.kts`)

## Bước 3: Bật Authentication

1. Trong Firebase Console, vào **Authentication**
2. Click "Get started"
3. Vào tab **Sign-in method**
4. Bật **Email/Password**
5. Click "Save"

## Bước 4: Tạo Firestore Database

1. Trong Firebase Console, vào **Firestore Database**
2. Click "Create database"
3. Chọn chế độ:
   - **Production mode** (khuyến nghị cho production)
   - **Test mode** (chỉ dùng cho development)
4. Chọn location (chọn gần nhất với bạn)
5. Click "Enable"

## Bước 5: Cấu hình Firestore Rules

1. Vào tab **Rules** trong Firestore Database
2. Thay thế rules mặc định bằng:

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
        (resource == null || resource.data.userId == request.auth.uid);
      allow create: if request.auth != null && 
        request.resource.data.userId == request.auth.uid;
    }
    
    // Assignments collection
    match /assignments/{assignmentId} {
      allow read, write: if request.auth != null && 
        (resource == null || resource.data.userId == request.auth.uid);
      allow create: if request.auth != null && 
        request.resource.data.userId == request.auth.uid;
    }
    
    // Groups collection
    match /groups/{groupId} {
      allow read: if request.auth != null && 
        (resource == null || request.auth.uid in resource.data.members);
      allow create: if request.auth != null && 
        request.auth.uid in request.resource.data.members;
      allow update, delete: if request.auth != null && 
        request.auth.uid == resource.data.leaderId;
    }
  }
}
```

3. Click "Publish"

## Bước 6: Bật Cloud Messaging (FCM) - Tùy chọn

1. Trong Firebase Console, vào **Cloud Messaging**
2. Bật FCM API (nếu chưa bật)
3. Lưu ý: Cần cấu hình thêm cho push notifications từ server

## Bước 7: Kiểm tra

1. Sync project trong Android Studio
2. Build project: `./gradlew build`
3. Chạy app và thử đăng ký tài khoản mới

## Lưu ý quan trọng

- **KHÔNG** commit file `google-services.json` lên Git nếu project là public
- Thêm `google-services.json` vào `.gitignore` nếu cần
- Đảm bảo package name trong Firebase Console khớp với `applicationId` trong `app/build.gradle.kts`

## Troubleshooting

### Lỗi: "File google-services.json is missing"
- Kiểm tra file `google-services.json` có trong thư mục `app/` không
- Sync project lại trong Android Studio

### Lỗi: "Default FirebaseApp is not initialized"
- Đảm bảo plugin `com.google.gms.google-services` đã được apply trong `app/build.gradle.kts`
- Rebuild project

### Lỗi Authentication
- Kiểm tra Email/Password đã được bật trong Firebase Console
- Kiểm tra Firestore Rules đã được publish
