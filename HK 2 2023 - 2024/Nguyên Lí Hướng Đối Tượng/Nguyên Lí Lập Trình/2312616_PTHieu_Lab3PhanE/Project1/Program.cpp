//Them thu vien
#include<iostream>
using namespace std;
//Khai bao nguyen mau
double TinhBieuThuc(double x, double y, char k);

//Ham main
int main()
{
	double x, y;
	char k;
	cout << "\nNhap x:";
	cin >> x;
	cout << "\nNhap y:";
	cin >> y;
	cout << "Chon phep tinh + - * / :";
	cin >> k;
	cout << "\nKet qua la:" << TinhBieuThuc(x, y, k);
	return 1;
}
//Dinh nghia ham
double TinhBieuThuc(double x, double y, char k)
{
	switch (k)
	{
	case'+':
		return x + y;

	case'-':
		return x - y;

	case'*':
		return x * y;

	case'/':
		return x / y;

		cout << "\nSai ";
		return 0;
		break;
	}

}