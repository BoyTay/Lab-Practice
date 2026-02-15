using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillDetailsDA
    {
        public List<BillDetails> GetAll()
        {
            var list = new List<BillDetails>();
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.BillDetail_GetAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new BillDetails
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                                FoodID = Convert.ToInt32(reader["FoodID"]),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int Insert_Update_Delete(BillDetails detail, int action)
        {
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.BillDetail_InsertUpdateDelete;

                    var id = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.InputOutput, Value = detail.ID };
                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = detail.InvoiceID;
                    cmd.Parameters.Add("@FoodID", SqlDbType.Int).Value = detail.FoodID;
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = detail.Quantity;
                    cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0) return (int)cmd.Parameters["@ID"].Value;
                    return 0;
                }
            }
        }
    }
}
