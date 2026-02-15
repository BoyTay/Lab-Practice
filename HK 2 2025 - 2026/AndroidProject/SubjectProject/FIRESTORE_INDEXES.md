# Firestore Indexes

Khi chạy ứng dụng, Firebase có thể yêu cầu tạo các composite indexes cho các queries phức tạp. Firebase sẽ tự động tạo link để bạn tạo index trong console.

## Indexes cần thiết

### 1. Assignments Collection

**Index cho getUpcomingAssignments:**
- Collection: `assignments`
- Fields:
  - `userId` (Ascending)
  - `deadline` (Ascending)
  - `status` (Ascending)

**Index cho getOverdueAssignments:**
- Collection: `assignments`
- Fields:
  - `userId` (Ascending)
  - `deadline` (Ascending)
  - `status` (Ascending)

**Index cho getAssignmentsByUser:**
- Collection: `assignments`
- Fields:
  - `userId` (Ascending)
  - `deadline` (Ascending)

## Cách tạo Index

1. Khi chạy app, nếu thiếu index, Firebase sẽ hiển thị link trong Logcat
2. Click vào link hoặc vào Firebase Console > Firestore Database > Indexes
3. Click "Create Index"
4. Điền thông tin theo các index ở trên
5. Chờ index được tạo (có thể mất vài phút)

## Lưu ý

- Indexes chỉ cần tạo một lần
- Firebase có thể tự động đề xuất index khi query lỗi
- Có thể export indexes vào file `firestore.indexes.json` để version control
