#pragma once

//Dinh nghia cac hang so va cac kieu du lieu moi

//Khai bao nguyen mau cac ham xu ly
void Xuat(int so);
unsigned int TimLuyThua(unsigned int n, unsigned int b);
void DoiCoSo(unsigned int n, unsigned int b);
//Dinh nghia cac ham xu ly
void Xuat(int so)
{
	if ((so >= 0) && (so <= 9))
		cout << so;
	else
	{
		switch (so)
		{
		case 10:cout << "A";
		case 11:cout << "B";
		case 12:cout << "C";
		case 13:cout << "D";
		case 14:cout << "E";
		case 15:cout << "F";
		}
	}
	return;
}
unsigned int TimLuyThua(unsigned int n, unsigned int b)
{
	int v = b, i = 1;
	while (v <= n)
	{
		for (int j = 1; j <= i; j++)
			v = v * b;
	}
	if (v > n)
		v = v / b;
	return v;
}
void DoiCoSo(unsigned int n, unsigned int b)
{
	int v, so;
	v = TimLuyThua(n, b);
	while (v > 0)
	{
		if (n < v)
			Xuat(0);
		else
		{
			so = n / v;
			Xuat(so);
			n = n - so * v;
		}
		v = v / b;
	}
}
