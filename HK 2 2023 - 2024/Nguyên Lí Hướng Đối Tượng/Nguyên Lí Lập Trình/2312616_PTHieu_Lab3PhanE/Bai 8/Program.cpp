//Khai bao thu vien
#include <iostream>
using namespace std;
#include <conio.h>
//Khai bao nguyen mau ham
float Hn1(int n);
float Hn2(int n);
float Hn3(int n);
float Sn1(int n);
float Sn2(int n);
float Sn3(int n);
float Tn1(int n);
float Tn2(int n);
float Tn3(int n);
float Un1(int n);
float Un2(int n);
float Un3(int n);
float Fn1(int n);
float Fn2(int n);
float Fn3(int n);
//Ham main
int main()
{
	int n;
	cout << "Nhap n:";
	cin >> n;
	if (n < 1) cout << "n phai lon hoac bang 1(n>=1).Hay nhap lai";
	cout << endl << "Tong 1+1/2+1/3+...+1/n la:" << Hn1(n);
	cout << endl << "Tong 1+1/2+1/3+...+1/n la:" << Hn2(n);
	cout << endl << "Tong 1+1/2+1/3+...+1/n la:" << Hn3(n);
	cout << endl << "Tong 2+3/4+4/9+...+(n+1)/n^2 la :" << Sn1(n);
	cout << endl << "Tong 2+3/4+4/9+...+(n+1)/n^2 la :" << Sn2(n);
	cout << endl << "Tong 2+3/4+4/9+...+(n+1)/n^2 la :" << Sn3(n);
	cout << endl << "Tong -1/2+2/3-3/4+...+(-1)^n*n/n+1 la :" << Tn1(n);
	cout << endl << "Tong -1/2+2/3-3/4+...+(-1)^n*n/n+1 la :" << Tn2(n);
	cout << endl << "Tong -1/2+2/3-3/4+...+(-1)^n*n/n+1 la :" << Tn3(n);
	cout << endl << "Tong 1/1*2+1/2*3+1/3*4+...+1/n*(n+1) la:" << Un1(n);
	cout << endl << "Tong 1/1*2+1/2*3+1/3*4+...+1/n*(n+1) la:" << Un2(n);
	cout << endl << "Tong 1/1*2+1/2*3+1/3*4+...+1/n*(n+1) la:" << Un3(n);
	cout << endl << "Tong 1!+2!+3!+...+n! la : " << Fn1(n);
	cout << endl << "Tong 1!+2!+3!+...+n! la : " << Fn2(n);
	cout << endl << "Tong 1!+2!+3!+...+n! la : " << Fn3(n);
	return 1;
}
float Hn1(int n)
{
	float S = 0;
	for (int i = 1; i <=n; i++)
	{
		S = S + 1.0 / i; 
	}
	return S;
}
float Hn2(int n)
{
	int i = 1;
	float S = 0;
	while (i <=n)
	{
		S = S + 1.0 / i;
		i++;
	}
	return S;

}
float Hn3(int n)
{
	int i = 1;
	float S = 0;
	do
	{
		S = S + 1.0 / i;
		i++;
	} while (i<=n);

	return S;

}
float Sn1(int n)
{
	float S = 0;
	for (int i = 1; i <=n; i++)
	{
		S = S + ((i + 1.0) / (i * i));
	}
	return S;
}
float Sn2(int n)
{
	int i = 1;
	float S = 0;
	while (i<=n)
	{
		S = S + ((i + 1.0) / (i * i));
		i++;
	}
	return S;
}
float Sn3(int n)
{
	int i = 1;
	float S = 0;
	do
	{
		S = S + ((i + 1.0) / (i * i));
		i++;
	} while (i<=n);
	return S;
}
float Tn1(int n)
{
	float S = 0;
	for (int i = 1; i <=n; i++)
	{
		S = S + ((pow(-1.0, i) * i) / (i + 1));
	}
	return S;
}
float Tn2(int n)
{
	float S = 0;
	int i = 1;
	while (i<=n)
	{
		S = S + ((pow(-1.0, i) * i) / (i + 1));
		i++;
	}
	return S;
}
float Tn3(int n)
{
	float S = 0;
	int i = 1;
	do
	{
		S = S + ((pow(-1.0, i) * i) / (i + 1));
		i++;
	} while (i<=n);
	return S;
}
float Un1(int n)
{
	float S = 0;
	for (int i = 1; i <=n; i++)
	{
		S = S + (1.0 / (i * (i + 1.0)));
	}
	return S;
}
float Un2(int n)
{
	float S = 0;
	int i = 1;
	while (i<=n)
	{
		S = S + (1.0 / (i * (i + 1.0)));
		i++;
	}
	return S;
}
float Un3(int n)
{
	float S = 0;
	int i = 1;
	do
	{
		S = S + (1.0 / (i * (i + 1.0)));
		i++;
	} while (i<=n);
	return S;
}
float Fn1(int n)
{
	float S = 0;
	int gt = 1;
	for (int i = 1; i <=n; i++)
	{
		gt *= i;
		S = S + gt;
	}
	return S;
}
float Fn2(int n)
{
	float S = 0;
	int i = 1;
	int gt = 1;
	while (i<=n)
	{
		gt *= i;
		S = S + gt;
		i++;
	}
	return S;

}
float Fn3(int n)
{
	float S = 0;
	int i = 1;
	int gt = 1;
	do
	{
		gt *= i;
		S = S + gt;
		i++;
	} while (i<=n);
	return S;
}