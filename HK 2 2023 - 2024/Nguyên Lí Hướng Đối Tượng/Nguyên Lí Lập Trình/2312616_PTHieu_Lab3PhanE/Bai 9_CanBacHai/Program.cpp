//Khai bao thu vien
#include <iostream>
#include <conio.h>
#include <math.h>
using namespace std;
//Dinh nghia hang
#define SAISO pow(10,-15)
//Khai bao nguyen mau ham
double canbachai(unsigned int n);
//Ham main
int main() {
	unsigned int n;
	cout << "hay nhap vao so n: "; cin >> n;
	cout << "can bac hai cua " << n << " la: " << canbachai(n);
	_getch();
	return 0;
}
//Dinh nghia ham
double canbachai(unsigned int n) {
	double kq;
	kq = (double)n / 2;
	while ((kq * kq - n) / n >= SAISO) {
		kq = (kq + n / kq) / 2;
	}
	return kq;
}