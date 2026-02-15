using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BillDetailsBL
    {
        BillDetailsDA da = new BillDetailsDA();
        public List<BillDetails> GetAll()
        {
            return da.GetAll();
        }
        
        public int Insert(BillDetails d)
        {
            return da.Insert_Update_Delete(d, 0);
        }
        
        public int Update(BillDetails d)
        {
            return da.Insert_Update_Delete(d, 1);
        }
        
        public int Delete(BillDetails d)
        {
            return da.Insert_Update_Delete(d, 2);
        }
        
    }
}

