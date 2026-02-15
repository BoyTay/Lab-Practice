using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillsDA
    {
        public List<Bills> GetAll()
        {
            var list = new List<Bills>();
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.Bill_GetAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Bills
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"] as string,
                                TableID = Convert.ToInt32(reader["TableID"]),
                                Amount = Convert.ToInt32(reader["Amount"]),
                                Discount = reader["Discount"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["Discount"]),
                                Tax = reader["Tax"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["Tax"]),
                                Status = reader["Status"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(reader["Status"]),
                                CheckoutDate = reader["CheckoutDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["CheckoutDate"]),
                                Account = reader["Account"] as string
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int Insert_Update_Delete(Bills bill, int action)
        {
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.Bill_InsertUpdateDelete;

                    var id = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.InputOutput, Value = bill.ID };
                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = (object)bill.Name ?? DBNull.Value;
                    cmd.Parameters.Add("@TableID", SqlDbType.Int).Value = bill.TableID;
                    cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = bill.Amount;
                    cmd.Parameters.Add("@Discount", SqlDbType.Float).Value = (object)bill.Discount ?? DBNull.Value;
                    cmd.Parameters.Add("@Tax", SqlDbType.Float).Value = (object)bill.Tax ?? DBNull.Value;
                    cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = (object)bill.Status ?? DBNull.Value;
                    cmd.Parameters.Add("@CheckoutDate", SqlDbType.SmallDateTime).Value = (object)bill.CheckoutDate ?? DBNull.Value;
                    cmd.Parameters.Add("@Account", SqlDbType.NVarChar, 100).Value = (object)bill.Account ?? DBNull.Value;
                    cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0) return (int)cmd.Parameters["@ID"].Value;
                    return 0;
                }
            }
        }
    }
}
