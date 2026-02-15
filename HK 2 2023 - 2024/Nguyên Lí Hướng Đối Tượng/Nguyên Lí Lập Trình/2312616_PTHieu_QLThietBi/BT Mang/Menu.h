//Khai bao nguyen mau
void XuatMenu();
int ChonMenu(int somenu);
void XuLyMenu(int menu, DanhSachTB dstb, int& n);
void ChayChuongTrinh();
//Dinh nghia ham
void XuatMenu()
{
	cout << "\n==============Menu=============";
	cout << "\n1. Nhap dstb";
	cout << "\n2. Xuat dstb";
	cout << "\n3. Tinh tong gia tien cua tat ca thiet bi co nam nhap[x..y]";
	cout << "\n4. Tim vi tri thiet bi theo ma thiet bi";
	cout << "\n5. Sap xep danh sach thiet bi giam theo nam nhap";
	cout << "\n6. Xoa tat ca thiet bi co nam nhap =x";
	cout << "\n7. Chen thiet bi tb sau thiet bi co ma thiet bi la y";
	cout << "\n8. In bang thong ke so thiet bi theo nam nhap";
	cout << "\n0. Thoat chuong trinh";
	cout << "\n===============================";
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
void XuLyMenu(int menu, DanhSachTB dstb, int& n)
{
	string MaX;
	int vt;
	int kq;
	switch (menu)
	{
	case 1:
		cout << endl << "Ban da chon chuc nang 1";
		cout << endl << "Nhap so tb:";
		cin >> n;
		NhapDSTB(dstb, n);
		XuatDSTB(dstb, n);
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2";
		cout << endl << "Xuat dstb";
		XuatDSTB(dstb, n);
		break;
	case 3:
		cout << endl << "Ban da chon chuc nang 3";
		int x, y;
		XuatDSTB(dstb, n);
		cout << endl << "Nhap so x:";
		cin >> x;
		cout << endl << "Nhap so y:";
		cin >> y;
		cout << endl << "Tong gia tien cua cac thiet bi co nam nhap tu [" << x << "..." << y << "] la :" << TinhTongGiaTien(dstb,n,x,y);		
		break;
	case 4:
		cout << endl << "Ban da chon chuc nang 4";
		XuatDSTB(dstb, n);
		cout << endl << "Nhap vao ma thiet bi can tim vi tri: ";
		cin >> MaX;
		kq=TimVTTheoMS(dstb, n, MaX);
		if (kq != -1)
			cout << endl << "Vi tri cua thiet bi nam o vi tri thu :" <<kq + 1;
		else
		{
			cout << endl << "Khong tim thay thiet bi nay";
		}
		break;
	case 5:
		cout << endl << "Ban da chon chuc nang 5";
		XuatDSTB(dstb, n);
		cout << endl;
		SapXep(dstb, n);
		XuatDSTB(dstb, n);
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
		somenu = 5;
	int  n;
	DanhSachTB dstb;
	HamCoDinh(dstb, n);
	do
	{
		system("cls");
		menu = ChonMenu(somenu);
		XuLyMenu(menu, dstb, n);
	} while (menu>0);
}

