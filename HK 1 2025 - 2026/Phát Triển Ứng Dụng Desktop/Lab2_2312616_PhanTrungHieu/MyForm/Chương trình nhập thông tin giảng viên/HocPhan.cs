using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chương_trình_nhập_thông_tin_giảng_viên
{
    public class HocPhan
    {
        public int ID { get; set; }
        public string TenHP { get; set; }
        public int SoTC { get; set; }

        public HocPhan(string ten)
        {
            this.TenHP = ten;
        }
        public HocPhan(int id, string ten, int tc)
        {
            this.ID = id;
            this.TenHP = ten;
            this.SoTC = tc;
        }

        public override string ToString()
        {
            return TenHP;
        }
    }

}
