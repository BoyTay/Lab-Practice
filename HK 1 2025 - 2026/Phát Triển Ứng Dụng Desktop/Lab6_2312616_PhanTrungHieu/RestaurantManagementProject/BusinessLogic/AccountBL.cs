using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AccountBL
    {
        AccountDA da = new AccountDA();
        public List<Account> GetAll()
        {
            return da.GetAll();
        }
       
        public int Insert(Account a)
        {  
            return da.Insert_Update_Delete(a, 0);
        }
       
        public int Update(Account a)
        {  
            return da.Insert_Update_Delete(a, 1); 
        }
       
        public int Delete(Account a)
        { 
            return da.Insert_Update_Delete(a, 2);
        }
        
        public bool Validate(string acc, string pass)
        {
            return da.Validate(acc, pass);
        }
       
    }
}

