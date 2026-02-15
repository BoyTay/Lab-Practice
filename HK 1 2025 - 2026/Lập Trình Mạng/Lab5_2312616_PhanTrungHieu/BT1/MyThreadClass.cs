 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BT1
{
    class MyThreadClass
    {
        private const int RANDOM_SLEEP_MAX = 1000;   // thời gian ngủ ngẫu nhiên tối đa (ms)
        private const int LOOP_COUNT = 10;           // số lần lặp của mỗi luồng
        private String greeting;                     // thông điệp chào cho luồng

        public MyThreadClass(String greeting)
        {
            this.greeting = greeting;                // khởi tạo chuỗi chào
        }

        public void runMyThread()
        {
            Random rand = new Random();
            for (int x = 0; x < LOOP_COUNT; x++)
            {
                Console.WriteLine(greeting + " (Thread ID:" + Thread.CurrentThread.GetHashCode() + ")");
                try
                {
                    Thread.Sleep(rand.Next(0, RANDOM_SLEEP_MAX));  // tạm dừng ngẫu nhiên
                }
                catch (ThreadInterruptedException) { }
            }
        }
        //Lớp này định nghĩa công việc mà mỗi luồng sẽ thực hiện.
        //Mỗi luồng sẽ:
        //In ra chuỗi greeting và ID của chính luồng đó.
        //Tạm dừng ngẫu nhiên từ 0 → 1000 ms sau mỗi lần in.
        //Lặp lại hành động này 10 lần.

    }
}
