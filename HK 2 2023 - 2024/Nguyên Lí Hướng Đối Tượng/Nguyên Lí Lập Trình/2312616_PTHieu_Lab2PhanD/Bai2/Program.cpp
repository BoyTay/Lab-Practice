//Them thu vien
#include <iostream>
#include<conio.h>
using namespace std;

//Dinh nghia hang
#define MAX 3600
#define SIXTY 60
//Khai bao nguyen mau
void DoiThoiGian(int n);
//Ham main
int main()
{
	int n;
	cout << "\nNhap so n la:";
	cin >> n;
	DoiThoiGian(n);
	return 0;
}
//Dinh nghia ham
void DoiThoiGian(int n)
{
	int gio, phut, giay;
	gio = n / MAX;
	phut = (n % MAX) / SIXTY;
	giay = (n % MAX) % SIXTY;
	cout << gio << ":" << phut << ":" << giay;
	return;

}