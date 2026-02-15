//Khai bao thu vien
#include  <iostream>
using namespace std;
#include <iomanip>
//Khai bao nguyen mau ham
float TinhChiSoCoThe(float w, float h);
void LoiKhuyen(float BMI,int t);
//Ham main
int main()
{
	float w, h, BMI;
	int t;
	cout << "\nNhap khoi luong co the (kg): ";
	cin >> w;
	cout << "\nNhap chieu cao (cm): ";
	cin >> h;
	cout << "\nNhap tuoi: ";
	cin >> t;
	BMI = TinhChiSoCoThe(w, h);
	LoiKhuyen(BMI, t);
	cout << "\nChi so khoi co the cua nguoi do la: " << BMI;
	return 1;
}
//Dinh nghia ham
float TinhChiSoCoThe(float w, float h)
{
	float BMI;
	BMI = w / pow(h, 2);
	return BMI;
}
void LoiKhuyen(float BMI, int t)
	{
	if (BMI < 15)
		cout << "\nDoi khat";
	else if (BMI < 17.5)
		cout << "\nBieng an";
	else if (BMI < 18.5)
		cout << "\nThieu can";
	else if ((BMI >= 18.5) && (BMI < 25))
		cout << "\nLy tuong";
	else if ((BMI >= 25) && (BMI < 30))
		cout << "\nThua can";
	else if ((BMI >= 30) && (BMI < 40))
		cout << "\nBeo phi";
	else
		cout << "\nTre em bi beo phi";
	}