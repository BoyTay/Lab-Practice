//Nap thu vien
#include <iostream>
#include <conio.h>
#include <iomanip>
#include <math.h>
using namespace std;
//Dinh nghia hang so

//Khai bao nguyen mau ham
float NhapMotSoKhacKhong();
void GiaiPhuongTrinhBacHai(float a, float b, float c);
//Ham main
int main()
{
	float a, b, c;
	a = NhapMotSoKhacKhong();
	cout << endl << "Nhap he so b:";
	cin >> b;
	cout << endl <<"Nhap he so c:";
	cin >> c;
	GiaiPhuongTrinhBacHai(a, b, c);
	_getch();
	return 1;

}
//Dinh nghia ham
float NhapMotSoKhacKhong()
{
	float so;
	do
	{
		cout << endl << "Nhap mot so thuc (khac 0):";
		cin >> so;
	} while (so == 0);
	return so;
}
void GiaiPhuongTrinhBacHai(float a, float b, float c)
{
	double delta, x;
	delta = b * b - 4 * a * c;
	if (delta < 0)
	{
		cout << endl << "Phuong trinh vo nghiem";
	}
	else
		if (delta == 0)
		{
			x = -b / (2 * a);
			cout << endl << "Phuong trinh co nghiem kep x=" << x;
		}
		else
		{
			cout << endl << "Phuong trinh co 2 nghiem phan biet";
			x = (-b + sqrt(delta)) / (2 * a);
			cout <<endl<< "x1=" << setprecision(5) << x;
			x = (-b - sqrt(delta)) / (2 * a);
			cout <<endl<< "x2=" << setprecision(5) << x;


		}

}