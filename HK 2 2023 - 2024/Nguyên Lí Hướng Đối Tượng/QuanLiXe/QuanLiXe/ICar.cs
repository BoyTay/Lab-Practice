using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiXe
{
    public interface ICar
    {
        int SoChoNgoi { get; set; }
        void MoCua();
        void DongCua();
    }
}
