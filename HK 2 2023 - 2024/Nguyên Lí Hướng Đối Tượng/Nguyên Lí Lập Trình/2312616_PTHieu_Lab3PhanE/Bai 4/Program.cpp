//Khai bao thu vien
#include <iostream>
using namespace std;
#include <conio.h>
#include <string>
//Khai bao nguyen mau ham
void XuatCacSo(int n);
void SoChiaHet(int n);
void DemSoLuong(int n);
void DaoNguoc(int n);
void TongChuSo(int n);
void ChuSoDauTien(int n);
long long DoiNhiPhan(int n);
bool SoHoanHao(int n);
void XuatSoHC(int n);
int TimM(int n);
//Ham main
int main()
{
	int n;
	cout << "\nNhap n:";
	cin >> n;
	XuatCacSo(n);
	SoChiaHet(n);
	DemSoLuong(n);
	DaoNguoc(n);
	TongChuSo(n);
	ChuSoDauTien(n);
	cout << endl<< "Nhi phan cua N la:" << DoiNhiPhan(n);
	cout<<endl<<"n co phai la so hoan hao khong"<<"  "<<SoHoanHao(n);
	XuatSoHC(n);
	cout <<endl<< "So nguyen m lon nhat cho tong 1+...+m<=n:" << TimM(n);
	_getch();
	return 1;

}
//Dinh nghia ham
void XuatCacSo(int n)
{
	for (int i = 1; i <= n; i++)
	{
		cout << "\t" << i;
		if (i % 10 == 0)
			cout << endl;
	}
}
void SoChiaHet(int n)
{
	int s = 0;
	for (int i = 1; i <= n; i++)
	{
		if ((i % 3 == 0) && (i % 4 != 0))
			s = s + 1;
	}
	cout << endl<<"Co""  " << s << "  " "so chia het cho 3 khong chia het cho 4";
}
void DemSoLuong(int n)
{
	int dem = 0;
	while (n >= 10)
	{
		n = n / 10;
		dem++;
	}
	cout <<endl<< "\nSo luong chu so la:" << dem + 1;
}
void DaoNguoc(int n) {
	cout <<endl<< "So dao nguoc N : ";
	int t = 0;
	while (n >= 1) {
		t = n % 10;
		n = n / 10;

		cout << t;
	}
}
void  TongChuSo(int n) {
	int x = 0;
	while (n >= 1) {
		x = x + n % 10;
		n = n / 10;
	}
	cout << endl<<"Tong cac chu so cua n la:" << x;
}

void ChuSoDauTien(int n) {
	int x = 0;
	while (n >= 1) {
		x = n % 10;
		n = n / 10;
	}
	cout <<endl<< "Chu so dau tien la:" << x;
}
long long DoiNhiPhan(int n) {
	long long x = 0;
	int p = 0;
	while (n > 0)
	{
		x += (n % 2) * pow(10, p);
		++p;
		n /= 2;
	}
	return x;
}



bool SoHoanHao(int n) {
	int x = 0;
	for (int i = 1; i <= n; i++) {
		if (n % i == 0) x = x + i;
	}
	if (x / 2 == n) return true;
	return false;
}

void XuatSoHC(int n) {
	cout <<endl<< "Cac so hoan chinh trong [1...n]: ";
	for (int i = 1; i <= n; i++) {
		if (SoHoanHao(i) == 1) cout << i << " ";
	}
}

int TimM(int n) {
	int x = 0;
	int m = 0;
	while (x <= n) {
		m = m + 1;
		x = x + m;
	}
	return m - 1;
}