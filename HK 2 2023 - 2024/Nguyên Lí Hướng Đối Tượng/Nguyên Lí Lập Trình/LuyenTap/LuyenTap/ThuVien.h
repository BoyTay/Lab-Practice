#define MAX 100
struct NgayThangNam
{
	int Ngay;
	int Thang;
	int Nam;
};
struct HVT
{
	string Ho;
	string Ten;
};
struct ThueBao
{
	int MSTB;
	HVT HoTen;
	string DiaChi;
	string SoDT;
	NgayThangNam day;
};
typedef  ThueBao DSThueBao[MAX];
void Nhap1TB(ThueBao& tb);
void NhapDSTB(DSThueBao dstb, int& n);
void Xuat1TB(ThueBao& tb);
void XuatTieuDe();
void XuatDSTB(DSThueBao dstb, int& n);



void DocFile(DSThueBao dstb, int& n, string filename)
{
	ifstream in(filename);
	n = 0;
	if (!in)
	{
		cout << endl << "Loi mo file";
		return;
	}
	ThueBao tb;
	while (!in.eof())
	{
		in >> tb.MSTB;
		in >> tb.HoTen.Ho;
		in >> tb.HoTen.Ten;
		in >> tb.DiaChi;
		in >> tb.SoDT;
		in >> tb.day.Ngay;
		in >> tb.day.Thang;
		in >> tb.day.Nam;
		dstb[n++] = tb;

	}
	in.close();
}
void Nhap1TB(ThueBao& tb)
{
	cout << endl << "Nhap ma so sinh vien : ";
	cin >> tb.MSTB;
	cout << endl << "Nhap ho : ";
	cin.ignore();
	getline(cin, tb.HoTen.Ho);
	cout << endl << "Nhap ten : ";
	getline(cin, tb.HoTen.Ten);
	cout << endl << "Nhap dia chi : ";
	getline(cin, tb.DiaChi);
	cout << endl << "Nhap so dien thoai :";
	getline(cin, tb.SoDT);
}

void NhapDSTB(DSThueBao dstb, int& n)
{
	for (int i = 0; i < n; i++)
	{
		cout << endl << "Nhap thong tin thue bao : " << i + 1;
		Nhap1TB(dstb[i]);
	}
}

void Xuat1TB(ThueBao& tb)
{
	cout << resetiosflags(ios::left)
		<< setw(1) << tb.MSTB
		<< setw(20) << tb.HoTen.Ho
		<< setw(10) << tb.HoTen.Ten
		<< setw(20) << tb.DiaChi
		<< setw(20) << tb.SoDT
		<< setw(4) << tb.day.Ngay
		<< "/"
		<< setw(4) << tb.day.Thang
		<< "/"
		<< setw(6) << tb.day.Nam;
}
void XuatTieuDe()
{
	cout << "\n"<< resetiosflags(ios::left)
		<< setw(1) << "Ma so"
		<< setw(25) << "Ho va ten"
		<< setw(20) << "Dia chi"
		<< setw(15) << "So DT"
		<< setw(20) << "Ngay hop dong";
}

void XuatDSTB(DSThueBao dstb, int& n)
{
	XuatTieuDe();
	for (int i = 0; i < n; i++)
	{
		cout << endl;
		Xuat1TB(dstb[i]);
	}
}
int TimTB(DSThueBao dstb, int& n, string tenTB)
{
	int vt = -1;
	XuatTieuDe();
	cout << endl;
	for (int i = 0; i < n; i++)
	{
		if (dstb[i].HoTen.Ten.compare(tenTB)==0)
		{
			Xuat1TB(dstb[i]); 
			cout << endl;
			vt = i;
		}
	}
	return vt;
}
void HoanVi(ThueBao& tb1, ThueBao& tb2)
{
	ThueBao tb;
	tb = tb1;
	tb1 = tb2;
	tb2 = tb;
}
void SapXepMaVung(DSThueBao dstb, int& n)
{
	for (int i = 0; i < n-1; i++)
		for (int j = i+1; j <n; j++)
		{
			if (dstb[i].SoDT.substr(0, 3)>(dstb[j].SoDT.substr(0, 3)))
				HoanVi(dstb[i], dstb[j]);
		}
}
void XoaTB(DSThueBao dstb, int& n, string TBCanXoa)
{
	for (int i = 0; i < n; i++)
	{
		if (dstb[i].HoTen.Ten.compare(TBCanXoa) == 0)
		{
			for (int j = i; j < n - 1; j++)
			{
				dstb[j] = dstb[j + 1];
			}
			n--;
			
			
		}
	}
}