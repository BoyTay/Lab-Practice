//Them thu vien
#include<iostream>
#include<math.h>
using namespace std;

//Khai bao nguyen mau
double TinhDoCao(double phi, double delta, double h);
double TinhPhuongVi(double phi, double delta, double h, double altitude);
//Ham main
int main()
{
	double phi, delta, h, altitude, azimuth;
	cout << "\nNhap phi:";
	cin >> phi;
	cout << "\nNhap delta:";
	cin >> delta;
	cout << "\nNhap h:";
	cin >> h;
	altitude = TinhDoCao(phi, delta, h);
	cout << "\nDo cao la:" << altitude;
	azimuth = TinhPhuongVi(phi, delta, h, altitude);
	cout << "\nPhuong vi la:" << azimuth;

	return 1;
}
//Dinh nghia ham
double TinhDoCao(double phi, double delta, double h)
{
	double altitude;
	altitude = asin(sin(phi) * sin(delta) + cos(phi) * cos(delta) * cos(h));
	return altitude;
}
double TinhPhuongVi(double phi, double delta, double h, double altitude)
{
	double  azimuth;
	azimuth = acos((cos(phi) * sin(delta) - sin(phi) * cos(delta) * cos(h)));
	return azimuth;

}
