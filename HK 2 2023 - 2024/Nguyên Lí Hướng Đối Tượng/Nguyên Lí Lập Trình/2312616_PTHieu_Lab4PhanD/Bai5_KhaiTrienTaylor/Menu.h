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
	cout << endl << "1.Tinh e^x :";
	cout << endl << "2.Tinh sin(x):";
	cout << endl << "3.Tinh cos(x):";
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
void XuLyMenu(int menu)
{
	
	
	double khaiTrien;
	switch (menu)
	{

	case 1:
		cout << endl << "Ban da chon chuc nang 1";
		khaiTrien = TinhEx();
		cout << endl << khaiTrien;
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2";
		khaiTrien = TinhSin();
		cout << endl << khaiTrien;
		break;
	case 3:
		cout << endl << "Ban da chon chuc nang 3";
		khaiTrien = TinhCos();
		cout << endl << khaiTrien;
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
void ChayChuongTrinh()
{
	int menu, soMenu = 3;
	do
	{
		menu = ChonMenu(soMenu);
		XuLyMenu(menu);
	} while (menu > 0);
	_getch();
}