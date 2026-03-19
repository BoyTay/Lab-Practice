'use strict'

const express = require('express')

const app = express();

const port = process.env.PORT || 9000

 

// Middleware: ghi log mỗi khi có GET request

app.use((req, res, next) =>
{

    console.log(`[${new Date().toISOString()}] nhận GET request tại ${req.url}`)

    // Chuyển tiếp sự kiện đến route handler

    next();

});

 

// Express lắng nghe sự kiện GET request, tại route /

// nếu có sự kiện, gọi hàm callback (route handler) tương ứng

app.get('/', (req, res) =>
{

    const name = req.query.name;

    res.send(`Web server chào bạn ${name}`);

});

 

// khoi dong web server

app.listen(port, () => {

    console.log(`server dang chay tren cong ${port}`);

});