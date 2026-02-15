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
	cout << endl << "1. Xuat cac uoc so cua n:";
	cout << endl << "2. Den so luong uoc so cua n:";
	cout << endl << "3. Tinh tong cac uoc so cua n:";
	cout << endl << "4. Tinh can bac hai cua n:";
	cout << endl << "5. So lon nhat nho hon hoac bang ma la luy thua cua 2:";

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
	int uocSo;
	switch (menu)
	{

	case 1:
		cout << endl << "Ban da chon chuc nang 1:";
		cout << endl;
		UocSo(n);
		break;
	case 2:
		cout << endl << "Ban da chon chuc nang 2:";
		uocSo = DemUocSo(n);
		cout << endl << uocSo;
		break;
	case 3:
		cout << endl << "Ban da chon chuc nang 3:";
		uocSo = TongUocSo(n);
		cout << endl << uocSo;
		break;
	case 4:
		cout << endl << "Ban da chon chuc nang 4:";
		uocSo = CanBacHai(n);
		cout << endl << uocSo;
		break;
	case 5:
		cout << endl << "Ban da chon chuc nang 5:";
		uocSo = TimSo(n);
		cout << endl << uocSo;
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
