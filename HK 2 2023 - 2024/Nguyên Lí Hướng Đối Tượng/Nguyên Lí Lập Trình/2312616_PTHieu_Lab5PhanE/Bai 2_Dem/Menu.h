//Khai bao nguyen mau ham xu li menu
void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(DaySo a, int &n, int menu);
void ChayChuongTrinh();
//Dinh nghia ham
void XuatMenu()
{

	cout << endl << "=====CHON CHUC NANG=====";
	cout << endl << "1. Dem so luong so le trong mang";
	cout << endl << "2. Dem va xuat cac so chia het cho 3 va khong chia het cho 4";
	cout << endl << "3. Dem so lan xuat hien cua phan tu x tai vi tri le";
	cout << endl << "4. Dem so luong so co 3 chu so";
	cout << endl << "5. Dem cac so nam ngoai pham vi[min...max] cho truoc";
	cout << endl << "6. Dem so luong so chinh phuong ";
	cout << endl << "7. Dem va xuat cac phan tu xuat hien it nhat k lan voi k cho truoc";
	cout << endl << "8. Dem so lan xuat hien cua phan tu x ke tu tu vt cho truoc";
	cout << endl << "0. Thoat chuong trinh";
	cout << endl << "=========================";
}
int ChonMenu(int soMenu)
{
	int stt;
	do
	{
		XuatMenu();
		cout <<endl<< "Nhap 1 so de chon menu: ";
		cin >> stt;
	} while (stt<0||stt>soMenu);
	return stt;

}
void XuLyMenu(DaySo a, int& n, int menu)
{
	int x;
	switch (menu)
	{
	case 1:
		cout << endl << "Ban da chon chuc nang 1";
		cout << endl; SoLe(a, n);
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2";
		cout << endl << "Co " << SoChiaHet(a, n) << " so chia het cho 3 nhung khong chia het cho 4 la so:"; XuatSoChiaHet(a, n);
		break;
	case 3:
		cout << endl << "Ban da chon chuc nang 3";
		cout << endl << "Nhap phan tu x :";
		cin >> x;
		cout << endl << "So lan xuat hien cua phan tu "<<x<<" tai vi tri le la : " << ViTriLe(a, n, x);
	default:
		cout << endl << "Thoat khoi chuong trinh";
		break;
	}
	if (menu > 0)
		cout << endl << "Nhan 1 phim bat ki de tiep tuc";
	_getch();
}
void ChayChuongTrinh()
{
	int menu,
		soMenu = 8;
	DaySo a;
	int n;
	cout << "Nhap so phan tu:";
	cin >> n;
	NhapMang(a, n);
	do
	{
		system("cls");
		XuatMang(a, n);
		menu = ChonMenu(soMenu);
		XuLyMenu(a, n, menu);
	} while (menu>0);
}