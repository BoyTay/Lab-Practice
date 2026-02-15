//Khai bao thu vien
#include <iostream>
using namespace std;
#include <conio.h>
//Dinh nghia hang
#define EPSILON 0.0001f

//Khai bao nguyen mau ham
void UocSo(int n);
int DemUocSo(int n);
int TongUocSo(int n);
double CanBacHai(int n);
//Ham main
int main()
{
	int n;
	cout << "Nhap so nguyen n:";
	cin >> n;
	cout << endl << "Cac uoc so cua n la:"; UocSo(n);
	cout << endl << "So luong uoc so cua n la:" << DemUocSo(n);
	cout << endl << "Tong cac uoc so cua n la:" << TongUocSo(n);
	cout << endl << "Can bac hai cua n la:" << CanBacHai(n);

}
//Dinh nghia ham
void UocSo(int n)
{
	for (int i = 1; i <= n; i++)
	{
		if (n % i == 0)
		{
			cout << i << " ";
		}

	}
}
int DemUocSo(int n)
{
	int dem = 0;
	for (int i = 1; i <= n; i++)
	{
		if (n % i == 0)
			dem++;
	}
	return dem;
}
int TongUocSo(int n)
{
	int sum = 0;
	for (int i = 1; i <= n; i++)
	{
		if (n % i == 0)
			sum = sum + i;
	}
	return sum;
}
double CanBacHai(int n)
{
	double result = 1.0f;
	while (fabs(result * result - n) / n >= EPSILON)
		result = (n / result - result) / 2 + result;
	return result;
}
