using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TableBL
    {
        TableDA da = new TableDA();
        public List<Table> GetAll()
        {
            return da.GetAll();
        }
        
        public int Insert(Table t)
        {
            return da.Insert_Update_Delete(t, 0);
        }
        
        public int Update(Table t)
        {
            return da.Insert_Update_Delete(t, 1);
        }
        
        public int Delete(Table t)
        {
            return da.Insert_Update_Delete(t, 2);
        }
        
    }
}

