//khai bao nguyen mau cac ham xu li menu
void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(DaySo a, int &n, int menu);
void ChayChuongTrinh();
//Dinh nghia ham
void XuatMenu()
{
	cout << endl << "=====CHON CHUC NANG=====";
	cout << endl << "1. Tim vi tri xuat hien dau tien cua phan tu x";
	cout << endl << "2. Tim vi tri cua so nguyen to cuoi cung trong mang a";
	cout << endl << "3. Tim phan tu xuat hien nhieu nhat va so lan xuat hien cua no";
	cout << endl << "4. Tim phan tu co gia tri nho nhat trong mang";
	cout << endl << "5. Tim tat ca cac so hoan chinh co trong mang";
	cout << endl << "6. Tim so am lon nhat va vi tri cua no";
	cout << endl << "7. Tim so duong nho nhat va vi tri cua no";
	cout << endl << "8. Tim phan tu co gia tri gan voi x";
	cout << endl << "0. Thoat chuong trinh";
	cout << endl << "================================";
}
int ChonMenu(int soMenu)
{
	int stt;
	do
	{
		
		XuatMenu();
		cout << endl << "Nhap 1 so de chon menu:";
		cin >> stt;
	} while (stt<0 || stt>soMenu);
	return stt;
}
void XuLyMenu(DaySo a, int &n, int menu)
{
	int x;
    switch (menu)
	{
	case 1:
		cout << endl << "Ban da chon chuc nang 1";
		cout << endl << "Nhap gia tri x:";
		cin >> x;
		cout << "Vi tri xuat hien dau tien cua phan tu " << x << " la:" << ChuaX(a, n, x);
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2";
		cout << endl << "Vi tri cua so nguyen to cuoi cung trong mang a la :" << SNTCuoiCung(a, n);
		break;
	case 3:
		cout << endl << "Ban da chon chuc nang 3";
		cout << endl;  PhanTuNhieuNhat(a, n);
		break;
	case 4:
		cout << endl << "Ban da chon chuc nang 4";
		cout << endl << "Phan tu co gia tri nho nhat trong mang la :" << GTNN(a, n);
		break;
	case 5:
		cout << endl << "Ban da chon chuc nang 5";
		cout << endl << "Tat ca cac so hoan chinh co trong mang la :"; XuatSoHC(a, n);
		break;
	case 6:
		cout << endl << "Ban da chon chuc nang 6";
		cout << endl; SoAmLonNhat(a, n);
		break;
	case 7:
		cout << endl << "Ban da chon chuc nang 7";
		cout << endl; SoDuongNhoNhat(a, n);
		break;
	case 8:
		cout << endl << "Ban da chon chuc nang 8";
		cout << endl << "Nhap gia tri x:";
		cin >> x;
		cout << endl << "So gan voi " << x << " nhat trong mang la: " << GTGanNhat(a, n, x);
		break;
	default:
		cout << endl << "Thoat khoi chuong trinh";
		break;
	}
	if (menu > 0)
		cout << endl << "1 Phim bat ki de tiep tuc";
	_getch();
}
void ChayChuongTrinh()
{
	int menu,
		soMenu = 8;
	DaySo a;
	int n;
cout << endl << "Nhap so phan tu :";
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