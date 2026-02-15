using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class ChiNhanh

    {
        public string MaChiNhanh { get; set; }
        public string TenChiNhanh { get; set; }
        public string DiaChi { get; set; }

        public ChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi)
        {
            MaChiNhanh = maChiNhanh;
            TenChiNhanh = tenChiNhanh;
            DiaChi = diaChi;
        }

        public override string ToString()
        {
            return $"Ma chi nhanh: {MaChiNhanh}\nTen chi nhanh: {TenChiNhanh}\nĐia chi: {DiaChi}";
        }
    }

    
   
}

