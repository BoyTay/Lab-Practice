using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._4
{
    internal class XuLy
    {
        public static void ChaoHoi(string hoTen, bool gioiTinh)
        {
            if (gioiTinh)          
                MessageBox.Show("Chào Ông " + hoTen);           
            else          
                MessageBox.Show("Chào Bà " + hoTen);          
        }

        public static int USCLN(int m, int n)
        {
            while (n != 0)
            {
                int temp = n;
                n = m % n;
                m = temp;
            }
            return m;
        }

    }
}
