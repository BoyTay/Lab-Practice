using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public static class Authorization
    {
        private static readonly HashSet<string> _roles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        public static string CurrentAccountName { get; private set; }

        public static void SignIn(string accountName)
        {
            CurrentAccountName = accountName;
            _roles.Clear();
            if (string.IsNullOrWhiteSpace(accountName)) return;

            var roleBL = new RoleBL();
            var roles = roleBL.GetByAccountName(accountName);
            foreach (var r in roles) _roles.Add(r.RoleName ?? "");
        }

        public static void SignOut()
        {
            CurrentAccountName = null;
            _roles.Clear();
        }

        public static bool IsInRole(string roleName) => _roles.Contains(roleName ?? "");
        public static bool IsInAny(params string[] roleNames) => roleNames != null && roleNames.Any(IsInRole);
        public static IEnumerable<string> CurrentRoles() => _roles.ToArray();
    }
}
