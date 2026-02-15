using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class NguoiMuonSach
    {
        public string SoThe { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public NguoiMuonSach(string soThe, string hoTen, string diaChi, string soDienThoai)
        {
            SoThe = soThe;
            HoTen = hoTen;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }

        public override string ToString()
        {
            return $"So the: {SoThe}\nHo ten: {HoTen}\nDia chi: {DiaChi}\nSo dien thoai: {SoDienThoai}";
        }
    }
}
