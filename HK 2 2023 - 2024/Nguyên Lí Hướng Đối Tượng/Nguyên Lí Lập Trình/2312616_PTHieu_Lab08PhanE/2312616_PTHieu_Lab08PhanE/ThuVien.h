#define MAX 100
//Cau truc sinh vien
struct SinhVien
{
	int MSSV;
	string HoVaTenLot;
	string Ten;
	string GioiTinh;
	double DTB;
	string Lop;
};
typedef SinhVien DanhSachSV[MAX];
void HamCoDinh(DanhSachSV dssv, int& n);
void Nhap1SV(SinhVien& sv);
void Xuat1SV(SinhVien& n);
void XuatTieuDe();
void NhapDSSV(DanhSachSV dssv, int n);
void XuatDSSV(DanhSachSV dssv, int n);
void HoanVi(SinhVien& sv1, SinhVien& sv2);
void SapXepTheoDTB(DanhSachSV dssv, int& n);
int TimThongTinSv(DanhSachSV dssv, int& n, string tenSV);


void HamCoDinh(DanhSachSV dssv, int& n)
{
		{
			dssv[0] = { 2312616,"Phan Trung", "Hieu","M",10.0,"CTK47A"};
			dssv[1] = { 2312617,"Nguyen Van","C","M",9.5,"CTK47A" };
			dssv[2] = { 2312618,"Nguyen Thi","A","F",4,"CTK47B" };
			dssv[3] = { 2312619,"Nguyen Thi","B","F",8.5,"CTK47C"};
			dssv[4] = { 2312612,"Nguyen Duy","Vu","M",4.5,"CTK47A" };

		};
		n = 5;
}
void Nhap1SV(SinhVien& sv)
{
	cout << "\nNhap ma so sinh vien:";
	cin >> sv.MSSV;
	cout << "\nNhap ho va ten lot:";
	cin.ignore();
	getline(cin, sv.HoVaTenLot);
	cout << "\nNhap ten sinh vien:";
	cin >> sv.Ten;
	cout << "\nNhap gioi tinh:";
	cin >> sv.GioiTinh;
	cout << "\nNhap diem trung binh:";
	cin >> sv.DTB;
	cout << "\nNhap lop :";
	cin.ignore();
	getline(cin, sv.Lop);
}
void Xuat1SV(SinhVien& sv)
{
	cout << "\n" << resetiosflags(ios::left)
		<< setw(10) << sv.MSSV
		<< setw(30) << sv.HoVaTenLot
		<< setw(10) << sv.Ten
		<< setw(15) << sv.GioiTinh
		<< setw(15) << sv.DTB
		<< setw(10) << sv.Lop;
}
void XuatTieuDe()
{
	cout << "\n" << resetiosflags(ios::left)
		<< setw(10) << "MSSV"
		<< setw(30) << "Ho va ten lot"
		<< setw(10) << "Ten"
		<< setw(15) << "Gioi tinh"
		<< setw(15) << "DTB"
		<< setw(10) << "Lop";
}
void NhapDSSV(DanhSachSV dssv, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << "\nNhap thong tin sinh vien:" << i + 1;
		Nhap1SV(dssv[i]);
	}
}
void XuatDSSV(DanhSachSV dssv, int n)
{
	XuatTieuDe();
	for (int  i = 0; i < n; i++)
	{
		Xuat1SV(dssv[i]);
	}
}
void HoanVi(SinhVien& sv1, SinhVien& sv2)
{
	SinhVien sv;
	sv = sv1;
	sv1 = sv2;
	sv2 = sv;
}
void SapXepTheoDTB(DanhSachSV dssv, int& n)
{
	for (int i = 0; i < n-1; i++)
		for (int j = i + 1; j < n; j++)
		{
			if (dssv[i].DTB < dssv[j].DTB)
			{
				HoanVi(dssv[i], dssv[j]);
			}

		}
}
void SapXepTheoTen(DanhSachSV dssv, int& n)
{
	for (int i = 0; i < n-1; i++)
		for (int j = i+1; j < n; j++)
		{
			if (dssv[i].Ten > dssv[j].Ten || dssv[i].Ten == dssv[j].Ten && (dssv[i].HoVaTenLot.compare(dssv[j].HoVaTenLot) == 1))
				HoanVi(dssv[i], dssv[j]);
		}
}
int TimThongTinSv(DanhSachSV dssv, int& n, string tenSV)
{
	int vt=-1;
	for (int i = 0; i < n; i++)
	{
		if (dssv[i].Ten.compare(tenSV) == 0)
		{
			vt = i;
			break;
		}
	}
	return vt;
}
int XuatDSSVLop(DanhSachSV dssv, int& n, string Lop)
{
	int dem = 0;
	for (int i = 0; i < n; i++)
	{
		if (dssv[i].Lop.compare(Lop) == 0)
		{
			Xuat1SV(dssv[i]);
			dem ++;
		}
	}
	return dem;
}
int TotNghiep(DanhSachSV dssv, int& n)
{
	int dem = 0;
	for (int i = 0; i < n; i++)
	{
		if (dssv[i].DTB < 5)
		{
			Xuat1SV(dssv[i]);
			dem++;
		}
	}
	return dem;
}
int ThongTinSVMaSo(DanhSachSV dssv, int& n,int MaSo)
{
	int dem = -1;
	for (int i = 0; i < n; i++)
	{
		if(MaSo==dssv[i].MSSV)
		{
			dem = i;
			break;
		}
	}
	return dem;
}
double TyLeSVLoaiGioi(DanhSachSV dssv, int& n)
{
	int dem = 0;
	for (int i = 0; i < n; i++)
	{
		if (dssv[i].DTB >= 8.0 && dssv[i].DTB <= 10.0)
		{
			dem++;
		}
	}
	return (dem*100)/n;
}
int XepLoaiHocLuc(DanhSachSV dssv, int& n)
{
	for (int i = 0; i < n; i++)
	{
		if (dssv[i].DTB >= 9.0 && dssv[i].DTB <= 10)
		{
			cout << endl <<dssv[i].Ten<< " co hoc luc xuat sac";
		}
		else if (dssv[i].DTB >= 8.0 && dssv[i].DTB < 9.0)
		{
			cout << endl << dssv[i].Ten << " co hoc luc gioi";
		}
		else if (dssv[i].DTB >= 7.0 && dssv[i].DTB < 8.0)
		{
			cout << endl << dssv[i].Ten << " co hoc luc kha";
		}
		else if (dssv[i].DTB >= 6.5 && dssv[i].DTB < 7.0)
		{
			cout << endl << dssv[i].Ten << " co hoc luc trung binh kha";
		}
		else if (dssv[i].DTB >= 5.0 && dssv[i].DTB < 6.5)
		{
			cout << endl << dssv[i].Ten << " co hoc luc trung binh";
		}
		else if (dssv[i].DTB >= 3.0 && dssv[i].DTB < 5.0)
		{
			cout << endl << dssv[i].Ten << " co hoc luc yeu";
		}
		else
		{
			cout << endl << dssv[i].Ten << " co hoc luc kem";
		}
	}

	return 0;
}
double ThongKeTyLeHocLuc(DanhSachSV dssv, int& n)
{
	int XuatSac=0;
	int Gioi = 0 ;
	int Kha=0;
	int TBKha=0;
	int TrungBinh=0;
	int Yeu=0;
	int Kem=0;
	for (int i = 0; i < n; i++)
	{
		if (dssv[i].DTB >= 9.0 && dssv[i].DTB <= 10)
		{
			XuatSac++;
		}
		else if (dssv[i].DTB >= 8.0 && dssv[i].DTB < 9.0)
		{
			Gioi++;
		}
		else if (dssv[i].DTB >= 7.0 && dssv[i].DTB < 8.0)
		{
			Kha++;
		}
		else if (dssv[i].DTB >= 6.5 && dssv[i].DTB < 7.0)
		{
			TBKha++;
		}
		else if (dssv[i].DTB >= 5.0 && dssv[i].DTB < 6.5)
		{
			TrungBinh++;
		}
		else if (dssv[i].DTB >= 3.0 && dssv[i].DTB < 5.0)
		{
			Yeu++;
		}
		else
		{
			Kem++;
		}
	}
	double	TLXS = (XuatSac * 100) / n;
	double TLG = (Gioi * 100) / n;
	double TLK = (Kha * 100) / n;
	double TLTBK=(TBKha * 100) / n;
	double TLTB=(TrungBinh * 100) / n;
	double TLY = (Yeu * 100) / n;
	double TLKem = (Kem * 100) / n;

	cout << endl << "Ty le hoc sinh xuat sac : " << TLXS << "%";
	cout << endl << "Ty le hoc sinh gioi : " << TLG << "%";
	cout << endl << "Ty le hoc sinh kha : " << TLK << "%";
	cout << endl << "Ty le hoc sinh trung binh kha : " << TLTBK << "%";
	cout << endl << "Ty le hoc sinh trung binh : " << TLTB << "%";
	cout << endl << "Ty le hoc sinh yeu : " << TLY << "%";
	cout << endl << "Ty le hoc sinh kem : " << TLKem << "%";
	return 0;
}
double DTBSinhVien(DanhSachSV dssv, int& n)
{
	float TongDiem = 0;
	for (int i = 0; i < n; i++)
	{
		TongDiem  += dssv[i].DTB;
	}
	return TongDiem / n;
}
int ChenhLechGT(DanhSachSV dssv, int& n)
{
	int SoLuongNam = 0;
	int SoLuongNu = 0;
	for (int i = 0; i < n; i++)
	{
		if (dssv[i].GioiTinh == "M")
		{
			SoLuongNam++;
		}
		else
		{
			SoLuongNu++;
		}
	}
	return SoLuongNam - SoLuongNu;
}
void ThongKeSLSV(DanhSachSV dssv, int& n)
{
	for (int i = 0; i < n; i++) 
	{
		int count = 0;
		for (int j = 0; j < n; j++) {
			if (dssv[i].Lop.compare(dssv[j].Lop)==0)
			{
				count++;
			}

		}
			cout << "Lop " << dssv[i].Lop << " co " << count << " sinh vien " << endl;
		
	}
}
void DTBCaoNhat(DanhSachSV dssv, int& n)
{
	for (int i = 0; i < n-1; i++)
		for (int j = i+1; j < n; j++)
		{
			if (dssv[i].DTB < dssv[j].DTB)
			{
				HoanVi(dssv[i], dssv[j]);
			}
		}
	for (int i = 0; i < n; i++)
	{
		cout << endl << "Ho va ten lot : " << dssv[i].HoVaTenLot;
		cout << endl << "Ten : " << dssv[i].Ten;
		cout << endl << "Gioi tinh : " << dssv[i].GioiTinh;
		cout << endl << "Diem trung binh : " << dssv[i].DTB;
		cout << endl << "Lop : " << dssv[i].Lop << endl;
	}
}