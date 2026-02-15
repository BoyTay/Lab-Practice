#pragma once

//Dinh nghia cac hang so va kieu du lieu moi


//Khai bao nguyen mau cac ham xu ly
int KiemTraNT(int n);
void XuatNSoNT(int n);
int DemSoNguyenTo(int n);
int TongUocSNT(int n);
void PhanTichSNT(int n);
//Dinh nghia cac ham xu ly
int KiemTraNT(int n)
{
	if (n <= 1)
		return 0;

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
	if (KiemTraNT(1)) cout << n << " la so nguyen to" << endl;
	else cout << n << " khong phai la so nguyen to" << endl;
}




void XuatNSoNT(int n)
{
	int d = 0, i;
	i = 2;
	while (1)
	{
		if (KiemTraNT(i))
		{
			cout << i << "\t";
			d++;
			if (d % 5 == 0) cout << "\n";
		}

		if (d == n)
			break;
		i++;
	}
	return;
}

int DemSoNguyenTo(int n) {
	int x = 0;
	for (int i = 2; i < n; i++) {

		if (KiemTraNT(i)) {
			x++;
		}
	}
	return x;
}

int TongUocSNT(int n) {
	int x = 0;
	for (int i = 2; i <= n; i++) {
		if (n % i == 0) {
			if (KiemTraNT(i)) x = x + i;
		}
	}
	return x;
}

void PhanTichSNT(int n) {
	int x = n;
	while (x > 1) {
		if (KiemTraNT(x)) {
			cout << x;
			break;
		}
		for (int j = 2; j <= x; j++) {
			if (x % j == 0) {
				if (KiemTraNT(j))
				{
					x = x / j;
					cout << j << " * ";
					break;
				}
			}
		}
	}
}