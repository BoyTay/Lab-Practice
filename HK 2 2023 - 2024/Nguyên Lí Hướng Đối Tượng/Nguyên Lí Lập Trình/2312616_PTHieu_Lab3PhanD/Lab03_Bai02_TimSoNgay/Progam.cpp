//Khai bao thu vien
#include <iostream>
using namespace std;
//Khai bao nguyen mau ham
int TimSoNgay(int thang, int nam);
int NhapSoTrongMien(int min, int max);
//Ham main
int main()
{
	int soNgay, thang, nam;
	cout << endl << "Nhap mot thang trong nam:";
	thang = NhapSoTrongMien(1, 12);
	cout << endl << "Nhap nam duong lich:";
	nam = NhapSoTrongMien(1, 3000);
	soNgay = TimSoNgay(thang, nam);
	cout << endl << "Thang" << thang
		<<"Nam" << nam
		<<" " << "co" << soNgay << "ngay.";
	return 1;
}
//Dinh nghia ham
int NhapSoTrongMien(int min, int max)
{
	int so;
	do
	{
		cout << endl << "Nhap mot so trong doan[" << min << ".." << max << "]:";
		cin >> so;
	} while (so < min || so > max);
	return so;
}
int TimSoNgay(int thang, int nam)
{
	int soNgay;
	switch (thang)
	{
	  case 1:
	  case 3:
	  case 5:
	  case 7:
	  case 8:
	  case 10:
	  case 12:
		  soNgay = 31;
		  break;
	  case 4:
	  case 6:
	  case 9:
	  case 11:
		  soNgay = 30;
		  break;
	default:
		if ((nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0))
			soNgay = 29;
		else
			soNgay = 28;
		break;
	}
	return soNgay;
}