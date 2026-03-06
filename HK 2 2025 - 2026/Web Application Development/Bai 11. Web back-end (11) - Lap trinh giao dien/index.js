'use strict'

const express = require('express')

const app = express();

const port =
process.env.PORT || 9000

// xu ly khi nguoi dung gui request toi web server

app.use(express.static(__dirname + '/Cental'));

app.listen(port, () => {

    console.log(`server dang chay tren cong ${port}`);

})
