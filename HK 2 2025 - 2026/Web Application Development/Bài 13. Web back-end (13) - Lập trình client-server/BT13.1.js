const express = require('express');
const app = express();
const port = 3000;
//http://localhost:3000/thong-tin-sinh-vien?MSSV=11223344&HoTen=Nguyễn Văn Tèo&DiemTrungBinh=7.0
// Định nghĩa route xử lý yêu cầu GET
app.get('/thong-tin-sinh-vien', (req, res) => {
    // 1. Lấy thông tin từ query parameters (URL)
    // Express lưu các tham số sau dấu ? trong req.query
    const mssv = req.query.MSSV;
    const hoTen = req.query.HoTen;
    const dtb = req.query.DiemTrungBinh;

    // 2. Tạo nội dung phản hồi
    // Sử dụng thẻ <br> để xuống dòng trong HTML
    const noiDung = `
        Chào bạn ${hoTen} <br>
        MSSV: ${mssv} <br>
        Điểm trung bình của bạn là: ${dtb} <br>
        Chúc bạn học chăm!
    `;

    // 3. Gửi phản hồi về client
    res.send(noiDung);
});

// Khởi động server
app.listen(port, () => {
    console.log(`Server đang chạy tại http://localhost:${port}`);
});