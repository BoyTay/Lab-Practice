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
	cout << endl << "1. Doi sang he nhi phan (b=2):";
	cout << endl << "1. Doi sang he bat phan (b=8):";
	cout << endl << "1. Doi sang he thap luc phan (b=16):";
	cout << endl << "1. Doi sang he co so 7 (b=7):";
	cout << endl << "1. Doi sang he co so bat ky (2<=b<=16):";
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
	int b;
	switch (menu)
	{
	case 1:
		cout << endl << "Ban da chon chuc nang 1";
		cout << endl;
		DoiCoSo(n, 2);
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2";
		cout << endl;
		DoiCoSo(n, 8);
		break;
	case 3:
		cout << endl << "Ban da chon chuc nang 3";
		cout << endl;
		DoiCoSo(n, 16);
		break;
	case 4:
		cout << endl << "Ban da chon chuc nang 4";
		cout << endl;
		DoiCoSo(n, 7);
		break;
	case 5:
		cout << endl << "Ban da chon chuc nang 5";
		cout << endl;
		cout << "Nhap b:";
		cin >> b;
		DoiCoSo(n, b);
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


