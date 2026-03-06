'use strict'

const express = require('express')

const app = express();

const port = process.env.PORT || 9000

// gọi module events

const events = require('events');

// tạo ra một EventEmitter

const eventEmitter = new events.EventEmitter();
eventEmitter.on('vaoLop', xuLyVaoLop);

// định nghĩa hàm xuLyVaoLop

function xuLyVaoLop(tb) {

    console.log(tb);
}
setTimeout(()=> {

    eventEmitter.emit('vaoLop','Đã đến giờ học')

}, 5000);

// khoi dong web server

app.listen(port, () => {

    console.log(`server dang chay tren cong ${port}`);

});

