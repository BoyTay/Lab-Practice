//Dinh nghia hang so va kieu du lieu moi
#define MAX 100
typedef int DaySo[MAX];
//Khai bao nguyen mau ham
void NhapMang(DaySo a, int& n);
void XuatMang(DaySo a, int& n);
void SoLe(DaySo a, int& n);
int SoChiaHet(DaySo a, int n);



//Dinh nghia ham
void NhapMang(DaySo a, int& n)
{
	for (int i = 0; i < n; i++)
	{
		cout << "a[" << i << "]=";
		cin >> a[i];
	}
}
void XuatMang(DaySo a, int& n)
{
	cout << "Cac phan tu cua mang la :";
	for (int i = 0; i < n; i++)
	{
		
		cout << a[i] << " ";
	}
}
void SoLe(DaySo a, int& n)
{
	int dem = 0;
	for (int i = 0; i < n; i++)
	{
		if (a[i] % n != 0)
		{
			dem++;

		}
	}
	cout << endl << "Co " << dem << " so le trong mang";
}
int SoChiaHet(DaySo a, int n)
{
	int dem = 0;
	for (int i = 0; i < n; i++)
	{
		
		if ((a[i] % 3 == 0) && (a[i] % 4 != 0))
		{
			dem++;
		}
	}
	return dem;
}
void XuatSoChiaHet(DaySo a,int &n)
{
	for (int i = 0; i < n; i++)
	{
		if ((a[i] % 3 == 0) && (a[i] % 4 != 0))
		{
			cout << a[i] << " ";
		}
	}
	
}
int ViTriLe(DaySo a, int& n, int x)
{
	int dem = 0;
	for (int i = 0; i < n; i++)
	{
		if (i % 2 != 1 && a[i] == x)
		{

			dem++;
		}
	}
	return dem;
}