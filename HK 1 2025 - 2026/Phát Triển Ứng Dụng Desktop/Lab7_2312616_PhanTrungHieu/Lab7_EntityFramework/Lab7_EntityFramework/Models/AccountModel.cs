using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_EntityFramework.Models
{
    public class AccountModel
    {
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Tell { get; set; }
        public bool Active { get; set; }          // Đánh dấu hoạt động (Password != null && có ít nhất 1 role Actived)
        public string Roles { get; set; }
    }
}
