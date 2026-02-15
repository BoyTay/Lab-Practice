#pragma once

//Dinh nghia cac hang so va kieu du lieu moi


//Khai bao nguyen mau cac ham xu ly
double GiaiThua(double n);
double TinhEx();
double TinhSin();
double TinhCos();
//Dinh nghia cac ham xu ly
double GiaiThua(double n)
{
    double e = 1;
    for (int i = 1; i <= n; i++)
    {
        e = e * i;
    }
    return e;
}
double TinhEx()
{
    double sum, sum_old;
    sum = 1;
    double x;
    double n = 1;
    cout << endl << "Nhap x:";
    cin >> x;
    do
    {
        sum_old = sum;
        sum = sum + pow(x, n) / GiaiThua(n);
        n++;
    } while ((sum - sum_old) > 0.00001);
    return sum;
}

double TinhSin()
{

    double x, sin = 0;
    double n = 0;
    cout << endl << "Nhap x:";
    cin >> x;
    while (abs(pow(-1, n) * (pow(x, 2 * n + 1) / GiaiThua(2 * n + 1))) > 0.00001)
    {
        sin = sin + pow(-1, n) * (pow(x, 2 * n + 1) / GiaiThua(2 * n + 1));
        n++;
    }
    return sin;
}
double TinhCos()
{
    double x;
    cout << endl << "Nhap x:";
    cin >> x;
    return sqrt(1 - sin(x) * sin(x));
}