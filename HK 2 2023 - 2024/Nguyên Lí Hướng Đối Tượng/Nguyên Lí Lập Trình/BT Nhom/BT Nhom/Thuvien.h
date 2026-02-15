//Dinh nghia hang so va cac kieu du lieu moi
#define MAX 100
typedef int DaySo[MAX];
//Khai bao nguyen mau ham
int NhapSoPT();
void NhapMang(DaySo a, int n);
void XuatMang(DaySo a, int n);
void TimSoLanXuatHien(DaySo a, int n);

//Dinh nghia ham
int NhapSoPT()
{
     int n;
     for (;;)
     {
	   cout << "\nNhap n>0:";
	   cin >> n;
	   if (n > 0)
	   break;
      }
    return n;
}

void NhapMang(DaySo a, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << "a[i]=";
		cin >> a[i];
	}

}
void XuatMang(DaySo a, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << a[i];
	}
}


void TimSoLanXuatHien(DaySo a, int n)
{
	int max = a[0];
	int solan = 1;
	
	for (int i = 1; i < n; i++)
	{
		int dem = 0;
		for (int j = 0; j < n; j++)
		{
			if (a[i] == a[j])
				dem++;
		}
		if (dem > solan)
		{
			solan = dem;
			max = a[i];
		}
	}
	cout << "\nPhan tu xuat hien nhieu nhat la:" << max;
	cout << "\nSo lan la :"<<solan;
	
}
