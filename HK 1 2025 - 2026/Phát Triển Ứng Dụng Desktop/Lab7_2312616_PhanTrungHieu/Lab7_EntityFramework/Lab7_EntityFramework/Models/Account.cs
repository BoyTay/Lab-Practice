using System;
using System.Collections.Generic;

namespace Lab7_EntityFramework.Models
{
    //Tài khoản người dùng (Khóa chính: AccountName)
    public class Account
    {
        public string AccountName { get; set; }       // PK
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Tell { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<RoleAccount> RoleAccounts { get; set; } = new List<RoleAccount>();
    }
}
