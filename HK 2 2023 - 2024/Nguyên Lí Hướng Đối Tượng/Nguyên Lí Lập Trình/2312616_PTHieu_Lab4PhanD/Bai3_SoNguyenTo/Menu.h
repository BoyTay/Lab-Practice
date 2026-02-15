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
	cout << endl << "1. Kiem tra n co phai la so nguyen to khong:";
	cout << endl << "2. Cac so cach nhau 1 dau Tab:";
	cout << endl << "3. Dem so luong so nguyen to:";
	cout << endl << "4. Tinh tong cac uoc so nguyen to cua n:";
	cout << endl << "5. Phan tich n thanh tich cac thua so nguyen to:";

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
	int nguyenTo;
	switch (menu)
	{
	case 1:
		cout << endl << "Ban da chon chuc nang 1";
		cout << endl;
		KiemTraNT(n);
		if (KiemTraNT(n)) cout << n << " la so nguyen to" << endl;
		else cout << n << " khong phai la so nguyen to" << endl;
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2";
		cout << endl;
		XuatNSoNT(n);
		break;
	case 3:
		cout << endl << "Ban da chon chuc nang 3";
		nguyenTo = DemSoNguyenTo(n);
		cout << endl << nguyenTo;
		break;
	case 4:
		cout << endl << "Ban da chon chuc nang 4";
		nguyenTo = TongUocSNT(n);
		cout << endl << nguyenTo;
		break;
	case 5:
		cout << endl << "Ban da chon chuc nang 5";
		cout << endl;
		PhanTichSNT(n);
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
	int menu, soMenu = 5;
	do
	{
		menu = ChonMenu(soMenu);
		XuLyMenu(menu, n);
	} while (menu > 0);
	_getch();
}
