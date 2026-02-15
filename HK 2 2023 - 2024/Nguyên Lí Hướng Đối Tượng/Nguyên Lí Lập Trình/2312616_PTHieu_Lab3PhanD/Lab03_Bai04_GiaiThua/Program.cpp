
//Khai bao thu vien
#include <iostream>
#include <conio.h>

using namespace std;

//Dinh nghia hang so

//Khai bao nguyen mau ham
long TinhGiaiThua(unsigned int n);
long TinhTong(unsigned int n);

//Ham main
int main()
{
    unsigned int n;
    cout << endl << "Nhap mot so nguyen khong am : ";
    cin >> n;
    long ketQua;
    ketQua = TinhGiaiThua(n);
    cout << endl << n << "! = " << ketQua;
    ketQua = TinheeTong(n);
    cout << endl << "1 + 2 +... + n = " << ketQua;
}
//Dinh nghia ham    
long TinhGiaiThua(unsigned int n)
{
    if (n < 2)
        return 1;
    else
    {
        long kq = 1;
        for (int i = 2; i <= n; i++)
            kq *= i;
        return kq;
    }
}

long TinhTong(unsigned int n)
{
    long sum = 0;
    for (int i = 1; i <= n; i++)
        sum += i;
    return sum;
}

