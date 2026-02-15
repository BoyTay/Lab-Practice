//Khai bao thu vien
#include<iostream>
#include<conio.h>
using namespace std;
//Dinh nghia hang so va cac kieu du lieu moi
#define TAB '\t'
//Khai bao nguyen  mau ham
int KiemTraNT(float n);

//Ham main
int main()
{
	cout << "\nChuong trinh xuat n so nguyen to dau tien :";
	_getch();
	return 1;
}
//Dinh nghia ham
/*Kiem tra so n la so nguyen to hay khong?
 Buoc 1 
  input :n-->int
  output:
  1: n la so nguyen to
  0: n khong phai la so nguyen to
  Buoc 2: Mo ta thuat toan
  B2.1: kq=1;
  B2.2: i:2--> n-1
   if(n%i==0)
   kq=0;
   break;
  B2.3: Tra ve ket qua;


*/
int KiemTraNT(float n)
{
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