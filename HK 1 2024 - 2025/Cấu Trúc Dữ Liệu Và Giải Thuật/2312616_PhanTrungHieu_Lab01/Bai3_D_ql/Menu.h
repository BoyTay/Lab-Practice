void XuatMenu()
{
	cout << "\n===========Menu===========";
	cout << "\n0. Thoat khoi chuong trinh";
	cout << "\n1. Nhap du lieu n";
	cout << "\n2. Xem du lieu n";
	cout << "\n3. Liet ke day nhi phan";
	cout << "\n4. Liet ke to hop";
	cout << "\n5. Liet ke hoan vi";
}
int ChonMenu(int soMenu)
{
	int stt;
	for (;;)
	{
		system("CLS");
		XuatMenu();
		cout << "\nNhap 1 so trong khoang [0,...," << soMenu << "] de chon menu (Lan dau tien chon 1) : ";
		cin >> stt;
		if (0 <= stt && stt <= soMenu)
			break;
	}
	return stt;

}
void XuLyMenu(int menu, int& n)
{
	switch (menu)
	{
	case 0:
		system("CLS");
		cout << "\n0. Thoat chuong trinh\n";
		break;
	case 1:
		system("CLS");
		cout << "\n1. Nhap du lieu n";	
		cout << "\nn = ";
		cin >> n;
		cout << endl;
		break;
	case 2:
		system("CLS");	
		cout << "\n2. Xem du lieu n";	
		cout << "\nn = " << n;
		cout << endl;
		break;
	case 3:
		system("CLS");		
		cout << "\n3. Liet ke day nhi phan\n";	
		dem = 0;
		LietKe_DayNP(1);
		cout << endl;
		break;
	case 4:
		system("CLS");		
		cout << "\n4. Liet ke to hop";	
		a[0] = 0;
		dem = 0;
		cout << "\nNhap k = ";
		cin >> k;
		LietKe_TH(1);
		break;
	case 5:
		system("CLS");		
		cout << "\n5. Liet ke hoan vi";
		break;
	default:
		break;
	}
}