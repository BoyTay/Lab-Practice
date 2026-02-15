void XuatMenu();
int ChonMenu(int somenu);
void XuLyMenu(int menu, DSThueBao dstb, int& n);
void ChayChuongTrinh();


void XuatMenu()
{
	cout << endl << "=======CHON CHUC NANG=======";
	cout << endl << "1. Nhap co dinh danh sach thue bao ";
	cout << endl << "2. Xuat thong tin cac thue bao ra man hinh";
	cout << endl << "3. Tim nhung thue bao co ten trung voi ten (duoc nhap tu ban phim)";
	cout << endl << "4.Sap xep cac thue bao tang dan theo ma vung";
	cout << endl << "5. Doc danh sach tu file ";
	cout << endl << "6. Xoa tat ca thue bao theo ten thue bao";
	cout << endl << "0. Thoat chuong trinh";
	cout << endl << "============================";
}
int ChonMenu(int somenu)
{
	int stt;
	do
	{
		XuatMenu();
		cout << endl << "Nhap 1 so de chon menu : ";
		cin >> stt;
	} while (stt<0 || stt>somenu);
	return stt;
}
void XuLyMenu(int menu, DSThueBao dstb, int& n)
{
	int kq;
	string tenTB,filename,TBCanXoa;
	
	switch (menu)
	{
	case 1:
		cout << endl << "Ban da chon chuc nang 1";
		XuatDSTB(dstb, n);
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2";
		XuatDSTB(dstb, n);
		break;
	case 3: 
		cout << endl << "Ban da chon chuc nang 3";
		XuatDSTB(dstb, n);
		cout << endl << "Nhap ten thue bao muon tim : ";
		cin.ignore();
		getline(cin, tenTB);
		kq = TimTB(dstb, n, tenTB);
		if (kq == -1)
		{
			cout << endl << "Khong tim thay thue bao nay";
		}
		break;
	case 4:
		cout << endl << "Ban da chon chuc nang 4";
		XuatDSTB(dstb, n);
		cout << endl;
		SapXepMaVung(dstb, n);
		XuatDSTB(dstb, n);
		break;
	case 5:
		cout << endl << "Ban da chon chuc nang 5";
		cout << endl << "Nhap ten file : ";
		cin >> filename;
		DocFile(dstb, n, filename);
		XuatDSTB(dstb, n);
		break;
	case 6:
		cout << endl << "Ban da chon chuc nang 6";
		XuatDSTB(dstb, n);
		cout << endl << "Nhap thue bao can xoa: ";
		cin.ignore();
		getline(cin, TBCanXoa);
		XoaTB(dstb, n, TBCanXoa);
		XuatDSTB(dstb, n);
		break;

	default:
		cout << endl << "Thoat chuong trinh";
		break;
	}
	if (menu > 0)
		cout << endl << "Nhan 1 phim bat ki de tiep tuc";
	_getch();
}
void ChayChuongTrinh()
{
	int menu, somenu = 9;
	int n = 5;
	DSThueBao dstb = {
		{1,"Phan Trung","Hieu","Dak Lak","094.7636963",{18,03,2005}},
		{2,"Nguyen Thi","A","Da Lat","097.1333133",{13,2,2005}},
		{3,"Pham Van","B","Di Linh","097.1421424",{10,10,2005}},
		{4,"Nguyen Dinh","A","Sai Gon","092.2442424",{4,9,2004}},
		{5,"Le Thi","D","Da Nang","098.2141242",{12,03,1999}},
	};
	
	do
	{
		system("cls");
		menu = ChonMenu(somenu);
		XuLyMenu(menu, dstb, n);
	} while (menu > 0);
}
