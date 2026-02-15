#pragma once
//Khai bao nguyen mau cac ham xu ly menu
void XuatMenu();
int ChonMenu(int soMenu);
void XuLyMenu(int menu);
void ChayChuongTrinh();
//Dinh nghia cac ham xu ly menu
void XuatMenu()
{
	cout << endl << "===== CHON CHUC NANG =====";
	cout << endl << "1. Cac so cach nhau 1 dau tab ";
	cout << endl << "2. cac so chia het cho 3 nhung khong chia het cho 4";
	cout << endl << "3. so luong chu so cua n:";
	cout << endl << "4. dao nguoc so n";
	cout << endl << "5. Tinh tong cac chu so trong n";
	cout << endl << "6. cho biet chu so dau tien trong n";
	cout << endl << "7. Doi so n sang he nhi phan";
	cout << endl << "8. Kiem tra so n co phai la so hoan hao";
	cout << endl << "9. Xuat cac so hoan chinh trong pham vi [1..n]";
	cout << endl << "10. Tim so nguyen m lon nhat sao cho tong 1+2+...+m<=n";
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
	} while (stt<0 || stt>soMenu);
	return stt;
}
void XuLyMenu(int menu, int n)
{
	int soNguyen;
	switch (menu)
	{
	case 1:
		cout << endl << "Ban da chon chuc nang 1:";
		XuatCacSo(n);
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2:"; SoChiaHet(n);
		break;
	case 3:
		cout << endl << "Ban da chon chuc nang 3:"; DemSoLuong(n);
		break;
	case 4:
		cout << endl << "Ban da chon chuc nang 4:"; DaoNguoc(n);
		break;
	case 5:
		cout << endl << "Ban da chon chuc nang 5:"; TongChuSo(n);
		break;
	case 6:
		cout << endl << "Ban da chon chuc nang 6:"; ChuSoDauTien(n);
		break;
	case 7:
		cout << endl << "Ban da chon chuc nang 7:";
		soNguyen = DoiNhiPhan(n);
		cout << endl << soNguyen;
		break;
	case 8:
		cout << endl << "Ban da chon chuc nang 8:";
		soNguyen = SoHoanHao(n);
		cout << endl << soNguyen;
		break;
	case 9:
		cout << endl << "Ban da chon chuc nang 9:"; XuatSoHC(n);
		break;
	case 10:
		cout << endl << "Ban da chon chuc nang 10:";
		soNguyen = TimM(n);
		cout << endl << soNguyen;
		break;

	default:
		cout << endl << "Thoat khoi chuong trinh";
		break;
	}
	if (menu > 0)
	{
		cout << endl << endl << "Nhan 1 phim bat ky de tiep tuc";
		_getch();
	}
}
void ChayChuongTrinh(unsigned int n)
{
	int menu, soMenu = 10;
	do
	{
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, n);
	} while (menu > 0);
	_getch();
}





