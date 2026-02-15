#include<iostream>
#include <algorithm>//Chua cac ham sap xep
using namespace std;
#define MAX 100
//a va b la cac cap phan tu trong mang a dung truoc b dung sau
//true : a va b da dung thu tu ban can sap xep
//false : a va b dang sai thu tu ban can sap xep


bool cmp(int a, int b)
{
    /*if (a < b)
    {
        return true;
    }
    else {
        return false;
    }*/
    return a > b;//giam dan ,tang dan thi a < b
}

// Ví dụ sắp xếp theo tổng các số
int Tong(int n)
{
    int tong = 0;
    while (n)
    {
        tong += n % 10;
        n /= 10;
    }
    return tong;
}
bool cmp1(int a, int b)
{
    return Tong(a) > Tong(b);
}
bool cmp3(pair<int, int> a, pair<int, int> b)
{
    int kc1 = a.first * a.first + a.second * a.second;
    int kc2 = b.first * b.first + b.second * b.second;
    if (kc1 != kc2)
    {
        return kc1 < kc2;

    }
    if (a.first != b.first)
        return a.first < b.first;
    return a.second < b.second;
}
int le(int a)
{
    int le = 0;
    while (a)
    {
        if (a % 2 == 1) {
            ++le;
        }
        a /= 10;
    }
    return le;
}
bool cmp4(int a, int b)
{
    if (le(a) != le(b))
        return le(a) > le(b);
    else
        return a < b;

}
int main()
{

   
    int n;
    cout << "Nhap so luong mang : ";
    cin >> n;
    int a[MAX];  
    for (int i = 0; i < n; i++)
    {
        cout << "a[" << i << "]= ";
        cin >> a[i];
    }
    //sort(a, a + n,cmp3);// sắp xếp theo thứ tự tăng dần
    ////a,a+n là 2 con trỏ(a+x,a+y) x,y: 2 chỉ số i
    ////sort(a, a + n, greater<int>()); sắp xếp theo thứ tự giảm dần
    //for (int i = 0; i < n; i++)
    //{
    //    cout << a[i]<<' ';
    //}
    // VD:Cho mảng A gồm n điểm trong hệ tọa độ Oxy ,sắp xếp các điểm này theo kc về gốc tọa độ tăng dần , nếu 2 điểm có cùng kc tới gốc tọa độ
    //thì in ra theo hoành độ tăng dần ,nếu 2 điểm này có cùng hoành độ thì in ra theo thứ tự tung độ tăng dần
   /* pair<int, int> a[MAX];
  
    for (int i = 0; i < n; i++)
    {
        cout << "Nhap hoanh do va tung do diem thu "<<i+1<<" : \n";
        cin >> a[i].first >> a[i].second;

    }
    sort(a, a + n,cmp3);
    for (auto i = 0; i < n; i++)
    {
        cout << a[i].first << ' ' << a[i].second << endl;
    }*/
    //VD : Cho mảng A gồm n phần tử sắp xếp sao cho số nào có nhiều số lẻ hơn thì đứng trước,trong th nhiều số có cùng chữ số lẻ thì số nào nhỏ đứng trước
   /* int a[MAX];
    for (int i = 0; i < n; i++)
    {
        cout << "a[" << i << "]= ";
        cin >> a[i];
    }
    sort(a, a + n,cmp4);
    for (int i = 0; i < n; i++)
    {
        cout << a[i]<<' ';
    }*/

    //Binary_search:lưu ý mảng phải được sắp xếp rồi mới sử dụng hàm này
    if (binary_search(a, a + n, 2))
        cout << "FOUND\n";
    else {
        cout << "NOT FOUND\n";
    }
    //Tìm x có xuất hiện trong mảng hay không
}
