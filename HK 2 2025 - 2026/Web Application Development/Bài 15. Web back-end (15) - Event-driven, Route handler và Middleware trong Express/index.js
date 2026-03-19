'use strict'

const express = require('express')

const app = express();

const port = process.env.PORT || 9000

 

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