const str = '     Nguyen Thi Van Teo     ';

 

    // bỏ khoảng trắng dư ở đầu và đuôi

    const temp = str.trim();

    // tìm khoảng trắng đầu tiên

    const firstSpace = temp.indexOf(' ');

    // tim khoảng trắng sau cùng

    const lastSpace = temp.lastIndexOf(' ');

 

    const ho = temp.slice(0, firstSpace);

    const tenLot = temp.slice(firstSpace + 1, lastSpace);

    const ten = temp.slice(lastSpace + 1, temp.length + 1);

    console.log(ho, tenLot, ten);