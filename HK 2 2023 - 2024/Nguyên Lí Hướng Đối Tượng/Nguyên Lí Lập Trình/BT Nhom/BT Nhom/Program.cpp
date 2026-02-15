//Nap thu vien
#include <iostream>
#include<conio.h>
using namespace std;
#include "Thuvien.h"
#include "Menu.h"
//Ham main
int main()
{
	DaySo a;
	int n ;
	cout << "\nChuong trinh thao tac mang 1 chieu";
	n = NhapSoPT();
	NhapMang(a, n);
	cout << "Mang vua nhap la:";
	XuatMang(a, n);
	ChayChuongTrinh(a,n);
	return 0;

}
