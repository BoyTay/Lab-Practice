//Them thu vien
#include <iostream>
using namespace std;
#include <math.h>
//Khai bao nguyen mau
double TinhKhoangCach(double xa, double ya, double xb, double yb);

//Ham main
int main()
{
	double xa, xb, ya, yb, d;
	cout << "\nNhap toa do xa:"; cin >> xa;
	cout << "\nNhap toa do ya:"; cin >> ya;
	cout << "\nNhap toa do xb:"; cin >> xb;
	cout << "\nNhap toa do yb:"; cin >> yb;
	d = TinhKhoangCach(xa, ya, xb, yb);
	cout << "\nKhoang cach giua hai diem:" << d;
	return 1;
}
//Dinh nghia ham
double TinhKhoangCach(double xa, double ya, double xb, double yb)
{
	double  d;
	d = sqrt(pow(xb - xa, 2) + pow(yb - ya, 2));
	return d;


}