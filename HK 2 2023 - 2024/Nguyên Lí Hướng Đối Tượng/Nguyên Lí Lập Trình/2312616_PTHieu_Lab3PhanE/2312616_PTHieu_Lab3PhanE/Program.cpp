//Them thu vien
#include <iostream>
using namespace std;
//Khai bao nguyen ham
void GiaiPTBacNhat(double a, double b);
//Ham main
int main()
{
	double a, b;
	cout << "\nNhap a:";
	cin >> a;
	cout << "\nNhap b:";
	cin >> b;
	GiaiPTBacNhat(a, b);
	return 1;
}
void GiaiPTBacNhat(double a, double b)
{
	if (a != 0)
		cout << "\nNghiem cua phuong trinh la:" << -b / a;
	else
	{
		if ((a == 0) && (b != 0))
			cout << "\nPhuong trinh vo nghiem";
		if ((a == 0) && (b == 0))
			cout << "\nPhuong trinh vo so nghiem";
	}
	return;

}