using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BT1
{
    class ThreadExample
    {
        static void Main(string[] args)
        {
            MyThreadClass mtc1 = new MyThreadClass("Day la tieu trinh thu 1");
            Thread thread1 = new Thread(new ThreadStart(mtc1.runMyThread));
            thread1.Start();

            MyThreadClass mtc2 = new MyThreadClass("Day la tieu trinh thu 2");
            Thread thread2 = new Thread(new ThreadStart(mtc2.runMyThread));
            thread2.Start();

            Console.ReadKey();
        }
        //Tạo 2 đối tượng MyThreadClass khác nhau, mỗi đối tượng có thông điệp riêng.
        //Mỗi đối tượng được gán vào một luồng riêng(Thread).
        //Khi gọi.Start(), hai luồng bắt đầu chạy song song(đồng thời).
        //Console.ReadKey() giữ cửa sổ console mở cho đến khi người dùng nhấn phím.
    }
}
