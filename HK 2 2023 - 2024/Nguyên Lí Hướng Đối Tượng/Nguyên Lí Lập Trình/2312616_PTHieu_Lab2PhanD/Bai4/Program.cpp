//Them thu vien
#include <iostream>
using namespace std;
#include<math.h>
//Dinh nghia hang
#define PI 3.1415926
//Khai bao nguyen mau
float ChuViHT(float R);
float DienTichHT(float R);
float DTXQ(float R, float h);
float DTTP(float R, float h);
float TheTichHTT(float R, float h);
//Ham main
int main()
{
	float R, h,c,s,V,Stp,Sxq;
	cout << "\nNhap ban kinh:";
	cin >> R;
	cout << "\nNhap chieu cao:";
	cin >> h;
	c = ChuViHT(R);
	cout << "\nChu vi hinh tron(" << R << "):" << c;
	s = DienTichHT(R);
	cout << "\nDien tich hinh tron(" << R << "):" << s;
	Sxq = DTXQ(R, h);
	cout << "\nDien tich xung quanh hinh tru tron(" << R << "," << h << "):" << Sxq;
	Stp = DTTP(R, h);
	cout << "\nDien tich toan phan hinh tru tron(" << R << "," << h << "):" << Stp;
	V = TheTichHTT(R, h);
	cout << "\nThe tich hinh tru tron(" << R << "," << h << "):" << V;

	return 1;

}
//Dinh nghia ham
float ChuViHT(float R)
{
	float c;
	c = 2 * PI * R;
	return c;
}

float DienTichHT(float R)
{
	float s;
	s = PI * R * R;
	return s;
}

float DTXQ(float R, float h)
{
	float Sxq;
	Sxq = 2 * PI * R * h;
	return Sxq;
}

float DTTP(float R, float h)
{
	float Stp;
	Stp = 2 * PI * R * h + 2 * PI * R * R;
	return Stp;
}

float TheTichHTT(float R, float h)
{
	float V;
	V = 4 * PI * R * R * h;
	return V;
}