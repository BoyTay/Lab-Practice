using DataAccess;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class RoleBL
    {
        RoleDA da = new RoleDA();
        public List<Role> GetAll()
        {
            return da.GetAll();
        }    
        public int Insert(Role r)
        {
            return da.Insert_Update_Delete(r, 0); 
        }
       
        public int Update(Role r)
        {
             return da.Insert_Update_Delete(r, 1);
        }
     
        public int Delete(Role r)
        {
            return da.Insert_Update_Delete(r, 2);
        }
        public List<Role> GetByAccountName(string accountName)
        {
            return da.GetByAccountName(accountName);
        }
    }

}

