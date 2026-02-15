using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RoleAccountBL
    {
        RoleAccountDA da = new RoleAccountDA();
        public List<RoleAccount> GetAll()
        { 
            return da.GetAll();
        }
      
        public int Insert(RoleAccount ra)
        {
            return da.Insert_Update_Delete(ra, 0);
        }
        
        public int Update(RoleAccount ra)
        {
            return da.Insert_Update_Delete(ra, 1);
        }
        
        public int Delete(RoleAccount ra)
        {
            return da.Insert_Update_Delete(ra, 2);
        }
        
    }
}

