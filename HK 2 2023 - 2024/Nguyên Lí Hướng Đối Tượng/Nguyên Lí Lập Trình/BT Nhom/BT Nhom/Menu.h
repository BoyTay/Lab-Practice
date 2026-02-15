//Khai bao nguyen ham menu
void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(int menu,DaySo a,int &n);
void ChayChuongTrinh(DaySo a, int &n);
//Dinh nghia cac ham xu ly menu
void XuatMenu()
{
	cout << endl << "=====CHON CHUC NANG=====";
	cout << endl << "2. Tim phan tu xuat hien nhieu nhat va so lan xuat hien cua no:";
	cout << endl << "0. Thoat chuong trinh";
	cout << endl << "========================";
}
int ChonMenu(int soMenu)
{
	int stt;
	do
	{
		system("cls");
		XuatMenu();
		cout << endl << "Nhap 1 so de chon menu:";
		cin >> stt;
	} while (stt<0||stt>soMenu);
	return stt;
}
void XuLyMenu(int menu,DaySo a,int &n)
{
	int kq;
	switch (menu)
	{
	case 2:
		cout << endl << "Ban da chon chuc nang 2:";
		 TimSoLanXuatHien(a, n);
		break;

	default:
		cout << endl << "Thoat khoi chuon trinh";
		break;
	}
	if (menu > 0)
	{
		cout << endl << endl << "Nhan 1 phim bat ky de tiep tuc";
		_getch();
	}
}
void ChayChuongTrinh(DaySo a,int &n)
{
	int  menu, soMenu = 2;
	do
	{
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, a, n);
	} while (menu > 0);
	
}





