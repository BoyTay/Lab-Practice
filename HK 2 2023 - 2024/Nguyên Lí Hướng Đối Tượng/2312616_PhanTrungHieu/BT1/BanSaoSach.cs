using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class BanSaoSach
    {
        public string MaSach{ get; set; }
        public string SoBanSao { get; set; }
      

        public BanSaoSach(string maSach, string soBanSao)
        {
           MaSach = maSach;
           SoBanSao = soBanSao;
        }

        public override string ToString()
        {
            return $"Ma sach: {MaSach}\nSo ban sao: {SoBanSao}";
        }
    }
}
