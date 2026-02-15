using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2_2312616_PhanTrungHieu
{
   public interface INhanVien
   {
         int NhanVienID { get; set; }
         string Phong { get; set; }
         void LayThongTinChiTiet();
        
           
        
        
    }
}
