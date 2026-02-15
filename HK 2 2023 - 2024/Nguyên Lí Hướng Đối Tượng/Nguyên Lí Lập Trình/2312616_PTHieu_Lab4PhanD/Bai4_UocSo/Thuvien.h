#pragma once

//Dinh nghia cac hang so va kieu du lieu moi
#define SAISO 0.0001f


//Khai bao nguyen mau cac ham xu ly
void UocSo(int n);
int DemUocSo(int n);
int TongUocSo(int n);
double CanBacHai(int n);
double TimSo(int n);
//Dinh nghia cac ham xu ly
void UocSo(int n)
{
	for (int i = 1; i <= n; i++)
	{
		if (n % i == 0)
		{
			cout << i << " ";
		}

	}
}
int DemUocSo(int n)
{
	int dem = 0;
	for (int i = 1; i <= n; i++)
	{
		if (n % i == 0)
			dem++;
	}
	return dem;
}
int TongUocSo(int n)
{
	int sum = 0;
	for (int i = 1; i <= n; i++)
	{
		if (n % i == 0)
			sum = sum + i;
	}
	return sum;
}
double CanBacHai(int n)
{
	double kq;
	kq = (double)n / 2;
	while ((kq * kq - n) / n >= SAISO)
	{
		kq = (kq + n / kq) / 2;
	}
	return kq;
}
double TimSo(int n)
{
	int kq = 1;
	while (kq < n)
	{
		kq *= 2;
	}
	return kq / 2;
}
