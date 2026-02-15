using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiXe
{
    public interface IVehicle
    {
       string Ten {  get; set; }
       int TocDo {  get; set; }
       string Loai {  get; set; }
       void Chay();
       void Dung();
    }
}
