//Them thu vien
#include<iostream>
#include<math.h>
using namespace std;
//Khai bao nguyen mau
double TinhCanhBen(int dayLon, int dayBe, int chieuCao);
double TinhChuVi(int dayLon, int dayBe, double canhBen);
double TinhDienTich(int dayLon, int dayBe, int chieuCao);
//Ham main
int   main()
{
	int a, b, h;
	double canhBen, chuVi, dienTich;
	cout << "\nNhap day lon la:";
	cin >> a;
	cout << "\nNhap day be la:";
	cin >> b;
	cout << "\nNhap chieu cao la:";
	cin >> h;
	canhBen = TinhCanhBen(a, b, h);
	chuVi = TinhChuVi(a, b, canhBen);
	cout << "\nChu Vi HTC(" << a << "," << b << ","<<canhBen<<"):" << chuVi;
	dienTich = TinhDienTich(a, b, h);
	cout << "\nDien Tich HTC(" << a << "," << b << "," << h << "):" << dienTich;
	return 1;

}
//Dinh nghia ham
double TinhCanhBen(int dayLon, int dayBe, int chieuCao)
{
	double canhBen;
	canhBen = sqrt(((double)dayLon-dayBe)/2*(dayLon-dayBe)/2 + chieuCao * chieuCao);
	return canhBen;
}

double TinhChuVi(int dayLon, int dayBe, double canhBen)
{
	double chuVi;
	chuVi = dayLon + dayBe + 2 * canhBen;
	return  chuVi;
}
double TinhDienTich(int dayLon, int dayBe, int chieuCao)
{
	double dienTich;
	dienTich = (((double)dayLon + dayBe) * chieuCao) / 2;
	return dienTich;
}

