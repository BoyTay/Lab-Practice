using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class RoleAccountDA
    {
        public List<RoleAccount> GetAll()
        {
            var list = new List<RoleAccount>();
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.RoleAccount_GetAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new RoleAccount
                            {
                                RoleID = Convert.ToInt32(reader["RoleID"]),
                                AccountName = reader["AccountName"].ToString(),
                                Actived = Convert.ToBoolean(reader["Actived"]),
                                Notes = reader["Notes"] as string
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int Insert_Update_Delete(RoleAccount ra, int action)
        {
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.RoleAccount_InsertUpdateDelete;

                    cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = ra.RoleID;
                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = ra.AccountName ?? "";
                    cmd.Parameters.Add("@Actived", SqlDbType.Bit).Value = ra.Actived;
                    cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 3000).Value = (object)ra.Notes ?? DBNull.Value;
                    cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // 2627 = PK violation, 2601 = unique index violation
                        if ((ex.Number == 2627 || ex.Number == 2601) && action == 0)
                            return 0; // duplicate -> UI will show failed insert
                        throw;
                    }
                }
            }
        }
    }
}
