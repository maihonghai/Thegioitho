using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LyDoHuy
    {
        // Phương thức để thêm lý do hủy vào bảng LyDoHuy trong cơ sở dữ liệu
        public void AddReason(int idCongViec, string lyDo)
        {
            // Truy vấn SQL để thêm lý do hủy vào bảng LyDoHuy
            string insertQuery = @"
            INSERT INTO LyDoHuy (IDCongViec, LyDo)
            VALUES (@IDCongViec, @LyDo)
        ";

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = ConnectionDTO.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Tạo đối tượng SqlCommand để thực thi truy vấn
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Thêm tham số vào truy vấn
                    command.Parameters.AddWithValue("@IDCongViec", idCongViec);
                    command.Parameters.AddWithValue("@LyDo", lyDo);

                    // Thực thi truy vấn để thêm lý do hủy vào bảng LyDoHuy
                    command.ExecuteNonQuery();
                }
            }
        }
        public string GetReason(int lichHenID)
        {
            string reason = null;

            try
            {
                using (SqlConnection connection = ConnectionDTO.GetSqlConnection())
                {
                    connection.Open();

                    string query = "SELECT LyDo FROM LyDoHuy WHERE IDCongViec = @IDLichHen";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDLichHen", lichHenID);

                        // Execute the command and retrieve the reason
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            reason = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Instead of showing MessageBox, throw an exception
                throw new Exception("Error while getting reason from the database: " + ex.Message);
            }

            return reason;
        }
    }
}
