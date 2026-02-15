using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De2_2312616_PhanTrungHieu
{
   public interface INguoi
   {
        string Ho { get; set; }
        string Ten { get; set; }
        void LayTenDayDu();
    }
}
