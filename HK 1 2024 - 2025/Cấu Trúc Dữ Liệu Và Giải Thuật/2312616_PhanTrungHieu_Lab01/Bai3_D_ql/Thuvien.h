#define MAX 20
//Các biến toàn cục
int n,
k;
int a[MAX], b[MAX];
int dem;

//Xuất dãy nhị phân ,hoán vị,tổ hợp
void Xuat_KQ(int a[MAX], int n)
{
	int i;
	cout << "kq" << setw(3) << dem << " : ";
	for (i = 1; i <= n; i++)
		cout << setw(2) << a[i];
	cout << endl;
}

//Dãy nhị phân chiều dài n
void LietKe_DayNP(int i)
{
	int j;
	for (j = 0; j <= 1; j++)
	{
		a[i] = j;
		if (i < n)
			LietKe_DayNP(i + 1);
		else
		{
			dem++;
			Xuat_KQ(a, n);
		}
	}
}
///Bai toan liet ke to hop 
//To hop chap k trong n 
void LietKe_TH(int i)
{
	int j;
	for (j = a[i - 1] + 1; j <= n - k + i; j++)
	{
		a[i] = j;
		if (i == k)
		{
			dem++;
			Xuat_KQ(a, k);
		}
		else
		   LietKe_TH(i + 1);
	}

}