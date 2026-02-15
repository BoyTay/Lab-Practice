//Them thu vien
#include <iostream>
using namespace std;
#include<math.h>
//Khai bao nguyen ham
float DoLanhCuaGio(float t, float v);

//Ham main
int main()
{
	float t, v, w;
	cout << "\nNhap nhiet do:";
	cin >> t;
	cout << "\nNhap van toc gio:";
	cin >> v;
	w = DoLanhCuaGio(t, v);
	cout << "\nDo lanh cua gio la:" << w;
	return 1;



}

//Dinh nghia ham
float DoLanhCuaGio(float t, float v)
{
	float w;
	w = 35.74 + 0.6215 * t + (0.4275 * t - 35.75) * v * 0.16;
	return w;


}