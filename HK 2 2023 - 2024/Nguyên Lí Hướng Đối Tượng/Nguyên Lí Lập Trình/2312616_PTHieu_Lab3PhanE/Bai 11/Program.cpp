//Khai bao thu vien
#include <iostream>
#include <ctime>
#include <conio.h>
using namespace std;
//Khai bao nguyen mau ham
int SinhSo();
void DoanSo(int k);
//Ham main
int main()
{
	srand(time(NULL));
	SinhSo();
	DoanSo();
	_getch();
	return 0;
}
int SinhSo()
{
	int k;
	k = rand() % 100 + 1;
	return k;
}
void DoanSo()
{
	int k = SinhSo();
	int so;
	int i = 1;
	while (i<=10)
	{
	
		cout << "\nNhap so cua ban[0..100]:";
		cin >> so;
		i++;
		if (so == k)
		{
			cout << " Ban da chien thang";
			break;
		}
		 if (so < k)
		{
			cout << " So can doan lon hon";
		}
		else 
		{
			cout << " So can doan nho hon";
		}
		if ( i>10) cout << "Ban da thua cuoc!";
	}
}