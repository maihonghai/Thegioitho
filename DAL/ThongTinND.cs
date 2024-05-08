using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongTinND
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public ThongTinND(int nDID)
        {
            // Thực hiện truy vấn SQL để lấy thông tin của Thợ từ cơ sở dữ liệu
            SqlConnection connection = ConnectionDAL.GetSqlConnection();
            string query = "SELECT TenTaiKhoan, MatKhau, Email,HoTen,SoDienThoai,DiaChi FROM TaiKhoan WHERE IDTaiKhoan = @nDID";
            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nDID", nDID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Gán thông tin của Thợ từ kết quả truy vấn vào các thuộc tính của đối tượng ThongTinCaNhan
                    TenTaiKhoan = reader["TenTaiKhoan"].ToString();
                    MatKhau = reader["MatKhau"].ToString();
                    HoTen = reader["HoTen"].ToString();
                    DiaChi = reader["DiaChi"].ToString();
                    SoDienThoai = reader["SoDienThoai"].ToString();
                    Email = reader["Email"].ToString();
                }

                reader.Close();
            }
        }
        // Các thuộc tính và phương thức hiện có trong lớp

        public List<BaiDangND> GetDanhSachBaiDang(int IdND)
        {
            List<BaiDangND> danhSachBaiDang = new List<BaiDangND>();

            // Thực hiện truy vấn SQL để lấy danh sách bài đăng của người dùng từ cơ sở dữ liệu
            SqlConnection connection = ConnectionDAL.GetSqlConnection();
            string query = "SELECT * FROM BaiDangND WHERE IDNguoiDung = @IDNguoiDung";
            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDNguoiDung",IdND); // IDNguoiDung là thuộc tính IDNguoiDung của lớp

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Tạo một đối tượng BaiDangND từ kết quả truy vấn và thêm vào danh sách
                    BaiDangND baiDang = new BaiDangND();
                    baiDang.IDBaiDangND = Convert.ToInt32(reader["IDBaiDangND"]);
                    // Gán các thuộc tính khác của bài đăng từ kết quả truy vấn
                    danhSachBaiDang.Add(baiDang);
                }

                reader.Close();
            }

            return danhSachBaiDang;
        }
        public ThongTinND(string tenTaiKhoan, string matKhau, string hoTen, string diaChi, string soDienThoai, string email)
        {
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
            HoTen = hoTen;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
        }
    }
   
}
