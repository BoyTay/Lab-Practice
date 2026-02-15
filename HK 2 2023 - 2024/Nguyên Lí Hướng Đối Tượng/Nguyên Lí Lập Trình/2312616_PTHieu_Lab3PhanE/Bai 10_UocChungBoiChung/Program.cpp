//Khai bao thu vien
#include <iostream>
using namespace std;

//Khai bao nguyen mau ham
void UocChung(int n, int m);
int TinhUCLN(int m, int n);
int TimBCNN(int m, int n);
//Ham main
int main()
{
	int m, n;
	cout << "Nhap m :";
	cin >> m;
	cout << "Nhap n:";
	cin >> n;
	cout << "\nUoc chung cua " << m << " va " << n << " la:"; UocChung(n, m);
	cout << "\nUoc chung lon nhat cua " << m << " va " << n << " la:" << TinhUCLN(m, n);
	cout << "\nBoi chung nho nhat cua " << m << " va " << n << " la:" << TimBCNN(m, n);
}
//Dinh nghia ham
void UocChung(int n,int m)
{
	if (m>n)
	{
		for (int i = 1; i <=n; i++)
		{
			if (m % i == 0 && n % i == 0)
				cout << " " << i;
		}
	}
	else if (m==n)
	{
		for (int i = 1; i <= n; i++)
		{
			if (m % i == 0 && n % i == 0)
				cout << " " << i;
		}
	}
	else  
	{
		for (int i = 1; i <= m; i++)
		{
			if (m % i == 0 && n % i == 0)
				cout << " " << i;
		}
	}
}

int TinhUCLN(int m, int n)
{
	while (m != n)
	{
		if (m > n)
			m = m - n;
		else
			n = n - m;
	}
	return m;
}
int TimBCNN(int m, int n)
{
	int BCNN;
	BCNN = m * n / TinhUCLN(m, n);
	return BCNN;
}