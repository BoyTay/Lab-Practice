
// Nap thu vien
#include<iostream>
#include<conio.h>
#include <cmath>
using namespace std;
// Khai bao nguyen mau ham
int KiemTraNT(int n);
void XuatNSoNT(int n);
int DemSoNguyenTo(int n);
int TongUocSNT(int n);
void PhanTichSNT(int n);
 //Ham main
int main() {
	int n;
	cout << "\nChuong trinh xuat n so nguyen to dau tien";
	cout << "\nNhap n:";
	cin >> n;
	if (KiemTraNT(n)) cout << n << " la so nguyen to" << endl;
	else cout << n << " khong phai la so nguyen to" << endl;
	cout << "\n" << n << " So nguyen to dau tien la:\n";
	XuatNSoNT(n);
	cout << endl;
	cout << "So luong cac so nguyen to nho hon n: " << DemSoNguyenTo(n) << endl;
	cout << "Tong uoc so SNT: " << TongUocSNT(n) << endl;
	PhanTichSNT(n);
	_getch();
	return 1;
}

// Dinh nghia ham

int KiemTraNT(int n)
{
	if (n <= 1)
		return 0;

	int kq = 1;
	for (int i = 2; i < n; i++)
	{
		if (n % i == 0)
		{
			kq = 0;
			break;
		}
	}
	return kq;
}

void XuatNSoNT(int n)
{
	int d = 0, i;
	i = 2;
	while (1)
	{
		if (KiemTraNT(i))
		{
			cout << i << "\t";
			d++;
			if (d % 5 == 0) cout << "\n";
		}

		if (d == n)
			break;
		i++;
	}
	return;
}

int DemSoNguyenTo(int n) {
	int x = 0;
	for (int i = 2; i < n; i++) {

		if (KiemTraNT(i)) {
			x++;
		}
	}
	return x;
}

int TongUocSNT(int n) {
	int x = 0;
	for (int i = 2; i <= n; i++) {
		if (n % i == 0) {
			if (KiemTraNT(i)) x = x + i;
		}
	}
	return x;
}

void PhanTichSNT(int n) {
	int x = n;
	while (x > 1) {
		if (KiemTraNT(x)) {
			cout << x;
			break;
		}
		for (int j = 2; j <= x; j++) {
			if (x % j == 0) {
				if (KiemTraNT(j))
				{
					x = x / j;
					cout << j << " * ";
					break;
				}
			}
		}
	}
}

