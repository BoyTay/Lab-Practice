using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachAnPham
{
    public interface IAnPham
    {
        float GiaTien { get; set; }
        string NhaXuatBan { get; set; }
        string Ten { get; set; }
       

    }
}
