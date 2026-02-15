void XuatMenu();
int ChonMenu(int somenu);
void XuLyMenu(int menu);
void ChayChuongTrinh();

void XuatMenu()
{
	cout << endl << "==========================Chuc Nang===================";
	cout << endl << "1.Chuc Nang 1";
	cout << endl << "0.Thoat chuong trinh";
	cout << endl << "======================================================";
}
int ChonMenu(int somenu)
{
	int stt;
	do
	{
		system("cls");
		XuatMenu();
		cout << endl << "Nhap so menu de chon";
	    cin >> stt;
	} while (stt<0||stt>somenu);
	return stt;
}
void XuLyMenu(int menu)
{
	switch (menu)
	{
	case 1:
		cout << endl << "Ban da chon chuc nang 1";
		break;
	default:
		cout << endl << "Thoat chuong trinh";
		break;
	}
	if (menu > 0)
		cout << endl << "Nhan phim bat ki de tiep tuc";
	_getch();
}
void ChayChuongTrinh()
{
	int menu, somenu = 2;
	do
	{
		menu = ChonMenu(somenu);
		XuLyMenu(menu);
	} while (menu>0);
}
