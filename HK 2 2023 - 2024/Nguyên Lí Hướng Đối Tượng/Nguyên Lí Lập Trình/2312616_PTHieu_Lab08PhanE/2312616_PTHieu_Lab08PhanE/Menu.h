void XuatMenu();
int ChonMenu(int somenu);
void XuLyMenu(int menu, DanhSachSV dssv, int& n);
void ChayChuongTrinh();

void XuatMenu()
{
	cout << endl << "=======CHON CHUC NANG========";
	cout << endl << "1. Nhap vao mot danh sach sinh vien  ";
	cout << endl << "2. Xuat danh sach sinh vien";
	cout << endl << "3. Sap xep sinh vien giam dan theo diem trung binh ";
	cout << endl << "4. Sap xep sinh vien tang dan theo ten";
	cout << endl << "5.Tim thong tin sinh vien ";
	cout << endl << "6. Xuat danh sach sinh vien cua lop";
	cout << endl << "7. Xuat danh sach sinh vien khong duoc tot nghiep ";
	cout << endl << "8. Tim thong tin sinh vien theo ma so";
	cout << endl << "9. Tinh ty le so sinh vien dat gioi tro len";
	cout << endl << "10. Xep loai hoc luc cua sinh vien";
	cout << endl << "11. Thong ke ty le hoc sinh theo xep loai hoc luc";
	cout << endl << "12. Tinh diem trung binh cua tat ca sinh vien";
	cout << endl << "13. Chenh lech ve so luong sinh vien nam va sinh vien nu";
	cout << endl << "14. Thong ke so luong sinh vien cua tung lop";
	cout << endl << "15. Tim va xuat thong tin nhung sinh vien co diem trung binh cao nhat";
	cout << endl << "0. Thoat chuong trinh";
	cout << endl << "===============================";
}
int ChonMenu(int somenu)
{
	int stt;
	do
	{
		XuatMenu();
		cout << endl << "Nhap 1 so de chon menu :";
		cin >> stt;
	} while (stt<0||stt>somenu);
	return stt;
}
void XuLyMenu(int menu, DanhSachSV dssv, int& n)
{
	int kq,MaSo;
	string tenSV,Lop;
	double TyLe;
	switch (menu)
	{
	case 1: 
		cout << endl << "Ban da chon chuc nang 1";
		cout << endl << "Nhap so sinh vien :";
		cin >> n;
		NhapDSSV(dssv, n);
		XuatDSSV(dssv, n);
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2";
		XuatDSSV(dssv, n);
		break;
	case 3:
		cout << endl << "Ban da chon chuc nang 3";
		XuatDSSV(dssv, n);
		cout << endl;
		SapXepTheoDTB(dssv, n);
		XuatDSSV(dssv, n);
		break;
	case 4:
		cout << endl << "Ban da chon chuc nang 4";
		XuatDSSV(dssv, n);
		cout << endl;
		SapXepTheoTen(dssv, n);
		XuatDSSV(dssv, n);
		break;
	case 5:
		cout << endl << "Ban da chon chuc nang 5";
		XuatDSSV(dssv, n);
		cout << endl;
		cout << endl << "Nhap ten sinh vien muon tim :";
		cin >> tenSV;
		kq = TimThongTinSv(dssv, n, tenSV);
		if (kq != -1)
		{
			cout << endl << "Thong tin sinh vien co ten :" << tenSV ;
			cout << endl << "Ma so sinh vien : " << dssv[kq].MSSV;
			cout << endl << "Ho va ten lot : " << dssv[kq].HoVaTenLot;
			cout << endl << "Gioi tinh : " << dssv[kq].GioiTinh;
			cout << endl << "Diem trung binh : " << dssv[kq].DTB;
			cout << endl << "Lop : " << dssv[kq].Lop;
		}
		else
		{
			cout << endl << "Khong tim thay sinh vien nay";
		}
		break;
	case 6:
		cout << endl << "Ban da chon chuc nang 6";
		XuatDSSV(dssv, n);
		cout << endl;
		cout << endl << "Nhap lop muon xuat dssv :";
		cin.ignore();
		getline(cin, Lop);
		kq = XuatDSSVLop(dssv, n, Lop);
		break;
	case 7:
		cout << endl << "Ban da chon chuc nang 7";
		XuatDSSV(dssv, n);
		cout << endl;
		cout << endl<<"Sinh vien co kha nang truot tot nghiep";
		kq=TotNghiep(dssv, n);
		if (kq == 0)
		{
			cout << endl << "Khong co sinh vien co kha nang khong tot nghiep ";
		}
		break;
	case 8:
		cout << endl << "Ban da chon chuc nang 8";
		XuatDSSV(dssv, n);
		cout << endl;
		cout << endl << "Nhap ma so sinh vien muon tim :";
		cin >> MaSo;
		kq = ThongTinSVMaSo(dssv, n, MaSo);
		if (kq != -1)
		{
			cout << endl << "Thong tin sinh vien co ma so :" << MaSo;
			cout << endl << "Ho va ten lot : " << dssv[kq].HoVaTenLot;
			cout << endl << "Ten : " << dssv[kq].Ten;
			cout << endl << "Gioi tinh : " << dssv[kq].GioiTinh;
			cout << endl << "Diem trung binh : " << dssv[kq].DTB;
			cout << endl << "Lop : " << dssv[kq].Lop;
		}
		else
		{
			cout << endl << "Khong tim thay sinh vien nay";
		}
		break;
	case 9:
		cout << endl << "Ban da chon chuc nang 9";
		XuatDSSV(dssv, n);
		cout << endl;
		TyLe = TyLeSVLoaiGioi(dssv, n);
		cout << endl << "Ty le sinh vien  dat loai gioi tro len : " << TyLe << "%";
		break;
	case 10:
		cout << endl << "Ban da chon chuc nang 10";
		XuatDSSV(dssv, n);
		cout << endl;
		kq = XepLoaiHocLuc(dssv, n);
		break;
	case 11:
		cout << endl << "Ban da chon chuc nang 11";
		XuatDSSV(dssv, n);
		cout << endl;
		ThongKeTyLeHocLuc(dssv, n);
		break;
	case 12:
		cout << endl << "Ban da chon chuc nang 12";
		XuatDSSV(dssv, n);
		cout << endl;
		cout<<endl<<"Diem trung binh cua tat ca sinh vien la : "<<DTBSinhVien(dssv, n);
		break;
	case 13:
		cout << endl << "Ban da chon chuc nang 13";
		XuatDSSV(dssv, n);
		cout << endl;
		cout << endl << "Chenh lech ve so luong sinh vien nam va sinh vien nu : " << ChenhLechGT(dssv, n);
		break; 
	case 14:
		cout << endl << "Ban da chon chuc nang 14";
		XuatDSSV(dssv, n);
		cout << endl;
	   ThongKeSLSV(dssv, n);
		break; 
	case 15:
		cout << endl << "Ban da chon chuc nang 15";
		XuatDSSV(dssv, n);
		cout <<endl<< "Cac sinh vien co diem trung binh cao nhat la : ";
		DTBCaoNhat(dssv, n);
		break;
	default:
		cout << endl << "Thoat chuong trinh";
		break;
	}
	if (menu > 0)
		cout << endl << "Nhap 1 phim bat ki de tiep tuc";
	_getch();
}
void ChayChuongTrinh()
{
	int menu,
		somenu = 15;
	int n;
	DanhSachSV dssv;
	HamCoDinh(dssv, n);
	do
	{
		system("cls");
		menu = ChonMenu(somenu);
		XuLyMenu(menu, dssv, n);

	} while (menu>0);
}
