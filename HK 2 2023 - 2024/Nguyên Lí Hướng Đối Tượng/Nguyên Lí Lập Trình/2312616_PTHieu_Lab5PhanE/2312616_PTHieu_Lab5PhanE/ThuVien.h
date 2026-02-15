//Dinh nghia cac hang so va cac kieu du lieu moi
#define MAX 100
typedef int DaySo[MAX];
//Khai bao nguyen mau ham
void NhapMang(DaySo a, int n);
void XuatMang(DaySo a, int n);
int ChuaX(DaySo a, int n,int x);
bool KiemTraNT(int n);
int SNTCuoiCung(DaySo a, int &n);
void PhanTuNhieuNhat(DaySo a, int &n);
int GTNN(DaySo a, int n);
bool SoHoanChinh(int n);
void XuatSoHC(DaySo a, int n);
void SoAmLonNhat(DaySo a, int n);
void SoDuongNhoNhat(DaySo a, int n);
int GTGanNhat(DaySo a, int n, int x);
//Dinh nghia ham xu li
void NhapMang(DaySo a, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << "a[" << i << "]=";
		cin >> a[i];
	}
}
void XuatMang(DaySo a, int n)
{
	cout << endl << "Cac phan tu cua mang la:";
	for (int i = 0; i < n; i++)
	{
		cout << a[i] << " ";
	}
}
int ChuaX(DaySo a, int n, int x) 
{
	int vt = -1;
	for (int i = 0; i < n; i++)
	{
		if (a[i] == x)
		{
			if (vt == -1)
				vt = i;
		}
	}
	return vt;
}
bool KiemTraNT(int n)
{
	if (n <= 1)
		return false;
	for (int i = 2; i < n; i++)
	{
		if (n % i == 0)
			return false;
	}
	return true;
}
int SNTCuoiCung(DaySo a, int &n)
{
	int vt=-1;
	for (int i = n-1; i >=0; i--)
	{
		if (KiemTraNT(a[i]) == 1)
		{
			return i;
		}
	}
	return -1;
}
void PhanTuNhieuNhat(DaySo a, int &n)
{
	int solan = 0;
	int max = a[0];
	for (int i = 0; i < n; i++)
	{
		int dem = 0;
		for (int j = 0; j < n; j++)
		{	
			if (a[i] == a[j])
			{
				dem++;
			}
		}
		if (dem > solan)
		{
			solan =dem;
			max = a[i];
		}
	}
	
	cout << endl << "Phan tu xuat hien nhieu nhat la: " << max;
	cout << endl << "Va xuat hien " << solan << " lan";
}
int GTNN(DaySo a, int n)
{
	int min = a[0];
	for (int i = 0; i < n; i++)
	{
		if (a[i] < min)
			min = a[i];
	}
	return min;
}
bool SoHoanChinh(int n)
{
	int sum = 1;
	for (int i = 2; i * i <= n; i++)
	{
		if (n % i == 0) 
		{
			sum = sum + i;
			if (i * i != n)
			{
				sum = sum + n / i;
			}
		}
	}
	return sum == n;
}

void XuatSoHC(DaySo a, int n)
{
	for (int i = 1; i < n; i++)
	{
		if (SoHoanChinh(a[i]))
		{
			cout << a[i] << " ";
		}
	}
}
void SoAmLonNhat(DaySo a, int n)
{
	int maxNegative = a[0];
	int vt = 0;
	for (int i = 1; i < n; i++)
	{
		if ((a[i]<0)  && (a[i]>maxNegative))
		{
			maxNegative = a[i];
			vt = i;
		}
	}
	cout << endl << "So am lon nhat la: " << maxNegative << ",vi tri cua no la: " << vt << "";
}
void SoDuongNhoNhat(DaySo a, int n)
{
	int minPositive = a[0];
	int vt = 0;
	for (int i = 1; i < n; i++)
	{
		if ((a[i] > 0) && a[i] < minPositive)
		{
			minPositive = a[i];
			vt = i;

		}
	}
	cout << endl << "So duong nho nhat la: " << minPositive << ",vi tri cua no la:" << vt << "";

}
int GTGanNhat(DaySo a, int n,int x)
{
	if (a[0] == x)
	{
		return a[0];
	}

	int nearest = a[0];
	for (int i = 1; i < n; i++)
	{
		if (abs(a[i] - x) < abs(nearest - x)) 
		{
			nearest = a[i];
		}
	}

	return nearest;
}


