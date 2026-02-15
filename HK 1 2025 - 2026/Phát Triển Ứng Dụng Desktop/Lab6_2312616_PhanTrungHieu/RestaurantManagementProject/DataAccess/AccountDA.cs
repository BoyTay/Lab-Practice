using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class AccountDA
    {
        public List<Account> GetAll()
        {
            var list = new List<Account>();
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.Account_GetAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Account
                            {
                                AccountName = reader["AccountName"].ToString(),
                                Password = reader["Password"].ToString(),
                                FullName = reader["FullName"] as string,
                                Email = reader["Email"] as string,
                                Tell = reader["Tell"] as string,
                                DateCreated = reader["DateCreated"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DateCreated"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int Insert_Update_Delete(Account account, int action)
        {
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.Account_InsertUpdateDelete;

                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = account.AccountName ?? "";
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = account.Password ?? "";
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000).Value = (object)account.FullName ?? DBNull.Value;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 1000).Value = (object)account.Email ?? DBNull.Value;
                    cmd.Parameters.Add("@Tell", SqlDbType.NVarChar, 200).Value = (object)account.Tell ?? DBNull.Value;
                    cmd.Parameters.Add("@DateCreated", SqlDbType.SmallDateTime).Value = (object)account.DateCreated ?? DBNull.Value;
                    cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // 2627 = PK violation, 2601 = unique index violation
                        if ((ex.Number == 2627 || ex.Number == 2601) && action == 0)
                            return 0; // duplicate -> report as failure to UI
                        throw;
                    }
                }
            }
        }

        public bool Validate(string accountName, string password)
        {
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Account_Validate";
                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = accountName ?? "";
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = password ?? "";
                    var obj = cmd.ExecuteScalar();
                    return obj != null;
                }
            }
        }
    }
}
