using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BillsBL
    {
        BillsDA da = new BillsDA();
        public List<Bills> GetAll()
        {
            return da.GetAll();
        }
        
        public int Insert(Bills b)
        {
            return da.Insert_Update_Delete(b, 0);
        }
        
        public int Update(Bills b)
        {
            return da.Insert_Update_Delete(b, 1);
        }
        
        public int Delete(Bills b)
        {
            return da.Insert_Update_Delete(b, 2);
        }
        
    }
}

