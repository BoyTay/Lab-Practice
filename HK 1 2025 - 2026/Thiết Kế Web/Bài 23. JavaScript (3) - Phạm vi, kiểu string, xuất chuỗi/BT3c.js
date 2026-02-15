const email = 'teonv@gmail.com';

    let avg = 0, splitted = '', part1 = '', part2 = '';

    splitted = email.split("@");

    part1 = splitted[0];

    avg = part1.length / 2;

    part1 = part1.slice(0, (part1.length - avg));

    part2 = splitted[1];

    console.log(part1 + "...@" + part2);