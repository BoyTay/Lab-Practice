//Them thu vien
#include <iostream>
using namespace std;
#include <math.h>
//Dinh nghia hang
#define PI 3.14

//Khai bao nguyen mau
double TTKC(double R);
double DTMC(double R);

//Ham main
int main()
{
	double R, v, s;
	cout << "\nNhap ban kinh:";
	cin >> R;
	s = DTMC(R);
	cout << "\nDien tich mat cau(" << R << "):" << s;
	v = TTKC(R);
	cout << "\nThe tich khoi cau(" << R << "):" << v;



}

//Dinh nghia ham
double TTKC(double R)
{
	double v;
	v = (4/3) * PI * pow(R,3);
	return v;


}

double DTMC(double R)
{
	double s;
	s = 4 * PI * pow(R,2);
	return s;

}
