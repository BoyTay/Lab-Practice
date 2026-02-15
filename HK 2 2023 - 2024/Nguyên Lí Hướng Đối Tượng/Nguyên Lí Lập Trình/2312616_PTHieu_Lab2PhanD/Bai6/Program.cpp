//Them thu vien
#include<iostream>
using namespace std;
 
//Khai bao nguyen mau
double TinhChiSoBMI(double khoiLuong, double chieuCao);

//Ham main
int main()
{
	double w, h,BMI;
	cout << "\nKhoi luong co the:";
	cin >> w;
	cout << "\nChieu cao co the:";
	cin >> h;
	BMI = TinhChiSoBMI(w, h);
	cout << "\nChi so khoi co the(" << w << "," << h << "):" << BMI;
	return 1;




}

//Dinh nghia ham
double TinhChiSoBMI(double khoiLuong, double chieuCao)
{
	double BMI;
	BMI = khoiLuong / pow(chieuCao, 2);
	return BMI;


}