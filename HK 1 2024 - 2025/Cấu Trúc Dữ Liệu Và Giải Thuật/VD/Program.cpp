#include <vector>
#include <iostream>
#include <set>

using namespace std;
int main()
{
	//push_back them phan tu vao cuoi
	//size in ra so phan tu 
	//foreach :Range base for loop
	//iterator
	//auto tu nhan biet kieu du lieu
	//kieu du lieu pair
	//set
	//empty kiem tra rong neu rong tra ve true,nguoc lai tra ve false
	//multiset
	
	//vector<int> v;// khong co phan tu nao	
	////vector<int> v(3,100); {100,100,100}
	//v.push_back(3);//{3}
	//v.push_back(5);//{3,5}
	//v.push_back(2);//{3,5,2}
	//v.push_back(1);//{3,5,2,1}
	//cout << "So phan tu trong vector : ";
	//cout << v.size() << endl;
	//cout << "Phan tu trong vector : ";

	/*for (int i = 0; i < v.size(); i++)
	{
		cout << v[i] << ' ';
	}

	cout << endl<< "Phan tu trong vector (nguoc lai) : ";
	for (int i = v.size()-1; i >=0; i--)
	{
		cout << v[i] << ' ';
	}*/

	/*for (int x:v)
	{
		cout << x <<' ';
	}*/

	//vector<int>::iterator it = v.begin();
	////++++it; Phan tu thu 3 (qua phai) 
	////  hoac it+=3
	////--it; Qua trai
	//cout <<endl<< "Phan tu dau tien trong vector : ";
	//cout << *it <<endl;

	/*vector<int>::iterator it;*/
	//Duyet qua cac phan tu bang iterator
	/*for (it=v.begin();it!=v.end();it++)
	{
		cout<<*it<<' ';
	}*/

	//vector<int>::iterator it = v.begin()+3;//v[3]
	//auto it = v.begin(); auto tu nhan biet kieu du lieu

	//Nhap phan tu vao trong vector
	/*int n;
	int x;
	cout << endl << "Nhap so luong vector can nhap : ";
	cin >> n;
	for (int i = 0; i < n; i++)
	{
		cout << "Nhap phan tu : ";
		cin >> x;
		v.push_back(x);
	}
	cout<<"Cac vector sau khi duoc nhap : ";
	for (int x : v)
	{
		cout << x << ' ';
	}*/ 

	//Chen phan tu vao vector
	//v.insert(v.begin() + 2, 100); //chen phan tu 100 vao vi tri thu 3
	
	//Xoa phan tu trong vector
	//v.erase(v.begin() + 3); //xoa phan tu vi tri thu 4
	//v.pop_back(); //Xoa phan tu cuoi
	/*for (int x : v)
	{
		cout << x << ' ';
	}*/

	/*VD: Thao tac 1 :Them 1 phan tu vao cuoi vector
	      Thao tac 2 : Xoa phan tu cuoi vector neu vector khong rong ,in ra EMPTY neu vector rong */
	/*vector<int> y;
	int n;
	cout << endl << "Nhap so luong vector can nhap : ";
	cin >> n;
	int tt;
	cout << "Nhap thao tac : ";
	cin >> tt;
	for (int i = 0; i < n; i++)
	{		
			
		if(tt==1)
		{ 			
			int z;
			cout << "\nNhap phan tu : ";
			cin >> z;
			y.push_back(z);			
		}
		else
		{
			if(y.empty() == false)
			{
				y.pop_back();
			}			
		}		
	}	
	if (y.empty())
		cout << "EMPTY\n";
	else {
		cout << endl << "Vector sau khi duoc chinh sua : ";
		for (int x : y)
		{
			cout << x << ' ';
		}
		cout << endl;
	}
		*/


	// kieu du lieu pair
	//pair<int, int> e = make_pair(10, 20);<=>
   /* pair<int, int> e = { 10,20 };
	cout << e.first << ' ' << e.second << endl;
	pair<int, pair<int, int>> p;
	p.first = 10;
	p.second.first = 20;
	p.second.second = 30;*///{10,{20,30}}


	/*set :-tu loai bo phan tu trung khong co 2 phan tu giong nhau
	       -phan tu sap xep tang dan*/
	set<int> se;//{}
	//se.insert(1);//{1}
	//se.insert(5);//{1,5}
	//se.insert(2);//{1,2,5}
	//se.insert(4);//{1,2,4,5}
	//se.insert(5);//{1,2,4,5}
	//cout << "So luong phan tu trong set : ";
	//cout << se.size() << endl;
	
	
	//Nhap phan tu vao trong set
	/*cout << "Nhap so luong phan tu can nhap : ";
	int n;
	cin >> n;
	for (auto i = 0; i < n; i++)
	{
		cout << "Nhap phan tu x: ";
		int x;
		cin >> x;
		se.insert(x);
	}*/
	//Duyet cac phan tu trong set
	/*for (int x : se)
	{
		cout << x << ' ';
	}*/

	//Find tim phan tu trong set
	//int y;
	//cout << "\nNhap phan tu can tim : ";
	//cin >> y;
	//if (se.find(y) != se.end())//se.count(y)!=0 xem thu co xuat hien khong
	//{
	//	cout << "\nFound\n";
	//}
	//else
	//{
	//	cout << "\nNot found\n";
	//}
	
	// Erase xoa 1 phan tu trong set
	//Luu y phai dam bao phai ton tai phan tu can xoa neu khong xay ra loi runtime error
	/*int z;
	cout << "Nhap phan tu can xoa : ";
	cin >> z;
	auto it = se.find(z);
	se.erase(it);*/
	
	//Multiset :-luu phan tu co gia giong nhau,sap xep tang dan cung tuong tu nhu set
	multiset<int> se1;
	cout << "Nhap so luong phan tu can nhap : ";
	int n;
	cin >> n;
	for (auto i = 0; i < n; i++)
	{
		cout << "Nhap phan tu x: ";
		int x;
		cin >> x;
		se1.insert(x);
	}
	for (int x : se1)
	{
		cout << x << ' ';
	}






}