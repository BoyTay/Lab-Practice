using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TableDA
    {
        public List<Table> GetAll()
        {
            var list = new List<Table>();
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.Table_GetAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Table
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Status = reader["Status"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Status"]),
                                Capacity = reader["Capacity"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Capacity"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int Insert_Update_Delete(Table table, int action)
        {
            using (var conn = new SqlConnection(Ultilities.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Ultilities.Table_InsertUpdateDelete;

                    var id = new SqlParameter("@ID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.InputOutput,
                        Value = table.ID
                    };
                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = table.Name ?? "";
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Value = (object)table.Status ?? DBNull.Value;
                    cmd.Parameters.Add("@Capacity", SqlDbType.Int).Value = (object)table.Capacity ?? DBNull.Value;
                    cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                    // Không dùng kết quả trả về của ExecuteNonQuery để đánh giá thành công
                    cmd.ExecuteNonQuery();

                    // Với Insert, trả về ID mới (nếu có). Với Update/Delete, coi là thành công nếu không exception.
                    if (action == 0)
                    {
                        var outId = cmd.Parameters["@ID"].Value;
                        if (outId != null && outId != DBNull.Value)
                            return Convert.ToInt32(outId);
                        return 1; // coi như thành công nếu SP không set @ID (dự phòng)
                    }

                    return 1; // Update/Delete: thành công nếu không ném exception
                }
            }
        }
    }
}
