#define MAX 100
//Cau truc sinh vien
struct ThietBi
{
	string maTB;
	string tenTB;
	int namNhap;
	int thoiGianBaoHanh;
	float giaTien;
};
typedef ThietBi DanhSachTB[MAX];

void HamCoDinh(DanhSachTB dstb,int &n);
void Nhap1TB(ThietBi  &tb);
void Xuat1TB(ThietBi tb);
void NhapDSTB(DanhSachTB dstb, int n);
void XuatDSTB(DanhSachTB dstb, int n);
void XuatTieuDe();
float TinhTongGiaTien(DanhSachTB dstb,int n,int x,int y);
int TimVTTheoMS(DanhSachTB dstb, int n);
void HoanVi(ThietBi& tb1, ThietBi& tb2);
void SapXep(DanhSachTB dstb, int n);
//Dinh nghia ham
void HamCoDinh(DanhSachTB dstb,int&n)
{
	
	{
	dstb[0] ={ "TB001", "Dien Thoai", 2020, 1, 20.5 };
	dstb[1]={"TB002", "May Tinh", 2021, 3, 50};
	dstb[2]={"TB003", "Tu Lanh", 2020, 6, 75.7};
	dstb[3]={"TB004", "May Lanh", 2023, 3, 48.9};
	dstb[4]={"TB005", "May Say", 2022, 6, 12.5};

	};
	n = 5;
}
void NhapDSTB(DanhSachTB dstb, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << "\nNhap thong tin thiet bi:" << i +1;
        Nhap1TB(dstb[i]);
	}
}
void XuatDSTB(DanhSachTB dstb, int n)
{
	XuatTieuDe();

	for (int i = 0; i < n; i++)
	{
		Xuat1TB(dstb[i]);
	}
}
void Nhap1TB(ThietBi& tb)
{
	cout << "\nNhap ma so thiet bi:";
	cin >> tb.maTB;

	cout << "\nNhap ten thiet bi:";
	cin.ignore();
	getline(cin, tb.tenTB);

	cout << "\nNhap nam nhap:";
	cin >> tb.namNhap;
	

	cout << "\nNhap thoi gian bao hanh:";
	cin >> tb.thoiGianBaoHanh;

	cout << "\nNhap gia tien:";
	cin >> tb.giaTien;
}
void Xuat1TB(ThietBi tb)
{
	cout << "\n" << setiosflags(ios::left)
		<< setw(10) << tb.maTB
		<< setw(25) << tb.tenTB
		<< setw(15) << tb.namNhap
		<< setw(15) << tb.thoiGianBaoHanh
		<< setw(15) << tb.giaTien;
}
void XuatTieuDe()
{
	cout << "\n" << setiosflags(ios::left)
		<< setw(10) << "Ma TB"
		<< setw(25) << "Ten TB"
		<< setw(15) << "Nam nhap"
		<< setw(15) << "TG bao hanh"
		<< setw(15) << "Gia tien";
}
float TinhTongGiaTien(DanhSachTB dstb,int n,int x,int y )
{
	float TongGiaTien = 0;
	for (int i = 0; i < n;i++ )
	{
		if (dstb[i].namNhap >= x && dstb[i].namNhap <= y)
		{
			TongGiaTien += dstb[i].giaTien;
		}
	}
	return TongGiaTien;
}
int TimVTTheoMS(DanhSachTB dstb, int n,string MaX)
{
	int vt = -1;
	for (int  i = 0; i < n; i++)
	{
		if (dstb[i].maTB.compare(MaX) == 0)
			vt = i;
		break;
	}
	return vt;
}
void HoanVi(ThietBi& tb1, ThietBi& tb2)
{
	ThietBi tb;
	tb = tb1;
	tb1 = tb2;
	tb2 = tb;
}
void SapXep(DanhSachTB dstb, int n)
{
	for (int i = 0; i < n - 1; i++)
		for (int j = i+1; j < n; j++) 
		{
			if (dstb[i].namNhap < dstb[j].namNhap || dstb[i].namNhap == dstb[j].namNhap && (dstb[i].tenTB.compare(dstb[j].tenTB) == 1))
			{
				HoanVi(dstb[i], dstb[j]);
			}
		}
}

