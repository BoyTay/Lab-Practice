using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_EntityFramework.Models
{
    //Bảng nối nhiều-nhiều Role <-> Account (Composite PK: RoleId + AccountName)
    public class RoleAccount
    {
        public int RoleId { get; set; }
        public string AccountName { get; set; }
        public bool Actived { get; set; }
        public string Notes { get; set; }

        public virtual Role Role { get; set; }
        public virtual Account Account { get; set; }
    }
}
