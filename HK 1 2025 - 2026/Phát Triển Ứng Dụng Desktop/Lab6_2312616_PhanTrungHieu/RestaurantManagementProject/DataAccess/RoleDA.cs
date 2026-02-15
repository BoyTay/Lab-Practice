using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class RoleDA
    {
        public List<Role> GetAll()
        {
            var list = new List<Role>();
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.Role_GetAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Role
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                RoleName = reader["RoleName"].ToString(),
                                Path = reader["Path"] as string,
                                Notes = reader["Notes"] as string
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int Insert_Update_Delete(Role role, int action)
        {
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.Role_InsertUpdateDelete;

                    var id = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.InputOutput, Value = role.ID };
                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 1000).Value = role.RoleName ?? "";
                    cmd.Parameters.Add("@Path", SqlDbType.NVarChar, 3000).Value = (object)role.Path ?? DBNull.Value;
                    cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 3000).Value = (object)role.Notes ?? DBNull.Value;
                    cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                    var affected = cmd.ExecuteNonQuery();
                    if (action == 0)
                    {
                        var outId = cmd.Parameters["@ID"].Value;
                        if (outId != null && outId != DBNull.Value) return Convert.ToInt32(outId);
                    }
                    return affected > 0 ? affected : 0;
                }
            }
        }

        // NEW: lấy role theo tài khoản
        public List<Role> GetByAccountName(string accountName)
        {
            var list = new List<Role>();
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Role_GetByAccountName";
                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName ?? "";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Role
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                RoleName = reader["RoleName"].ToString(),
                                Path = reader["Path"] as string,
                                Notes = reader["Notes"] as string
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
