using DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static DAL.ThongTinTho;

namespace GUI.All_User_Control
{
    public partial class UC_ThoYeuThich : UserControl
    {

        

        public int IDTho; // Chuyển IDTho thành biến instance để sử dụng trong phương thức btnHuyYeuThich_Click
        public event EventHandler<int> XemBaiDangClicked;
        public UC_ThoYeuThich(ThongTinTho tho)
        {
            InitializeComponent();
            txtHoVaTen.Text = tho.HoTen;
            txtSoDienThoai.Text = tho.SoDienThoai;
            txtDiaChi.Text = tho.DiaChi;
            txtSoNamKinhNghiem.Text = tho.SoNamKinhNghiem.ToString();
            IDTho = tho.IDTho;
            if(tho.GioiTinh == "Nữ")
            {
                ptbNu.Visible = true;
            }
            lblIDTho.Text = IDTho.ToString();
            // Khởi tạo nhãn để hiển thị số lượt yêu thích
            lblYeuThich.Text = tho.SoLuotYeuThich.ToString()+ " lượt";

           

            

            
        }
        public void HienThiRatingStar(int rating)
        {
            // Đặt giá trị cho GunaRatingStar
            guna2RatingThoYeuThich.Value = rating;
            // Hiển thị GunaRatingStar
            guna2RatingThoYeuThich.Visible = true;
            lblYeuThich.Visible = false;
            lblBiHuy.Visible = false;
        }

        public int LaySoSaoDanhGia(int IDTho)
        {
            // Thực hiện truy vấn SQL để lấy số sao đánh giá của thợ
            string query = @"SELECT AVG(SoSao) AS DiemTrungBinh
                     FROM DanhGia
                     WHERE IDCongViec IN (SELECT IDCongViec FROM CongViec WHERE IDTho = @IDTho)";

            // Thực hiện truy vấn và lấy kết quả
            int diemTrungBinh = 0;
            using (SqlConnection connection = ConnectionDAL.GetSqlConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDTho", IDTho);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        diemTrungBinh = Convert.ToInt16(result);
                    }
                }
            }

            return diemTrungBinh;
        }

        public void HienThiDoanhThu(string doanhThu)
        {
            lblDoanhThu.Text = doanhThu;
            lblDoanhThu.Visible = true;

            lblYeuThich.Visible = false;
            lblBiHuy.Visible = false;
        }

        public string LayDoanhThu(int IDTho)
        {
            // Thực hiện truy vấn SQL để lấy số sao đánh giá của thợ
            string query = @"SELECT SUM(cv.GiaTien) AS TongDoanhThu
                     FROM CongViec cv
                     WHERE cv.IDTho = @IDTho AND cv.TrangThaiCongViecTho = @TrangThai";

            // Thực hiện truy vấn và lấy kết quả
            decimal tongDoanhThu = 0;
            using (SqlConnection connection = ConnectionDAL.GetSqlConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDTho", IDTho);
                    command.Parameters.AddWithValue("@TrangThai", "Đã hoàn thành");
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        tongDoanhThu = Convert.ToDecimal(result);
                    }
                }
            }

            return tongDoanhThu.ToString("C0");
        }

        public Guna2HtmlLabel GetSoLuotYeuThich()
        {
            return lblYeuThich;
        }
        public Guna2Button GetBtnHuyYeuThich()
        {
            return btnHuyYeuThich;
        }
        private void btnXemBaiDang_Click(object sender, EventArgs e)
        {
            // Khi người dùng nhấn nút XemBaiDang, gửi sự kiện với IDTho tới form cha
            XemBaiDangClicked?.Invoke(this, IDTho);
        }
       
        private void btnHuyYeuThich_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy yêu thích thợ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ThoYeuThichRepository repository = new ThoYeuThichRepository();
                    repository.XoaThoYeuThich(BLL.LoginBLL.IDNguoiDung, IDTho); // Sử dụng IDTho từ biến instance
                    MessageBox.Show("Đã xóa thông tin thợ yêu thích thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa thông tin thợ yêu thích: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblYeuThich_Click(object sender, EventArgs e)
        {

        }

        private void lblBiHuy_Click(object sender, EventArgs e)
        {

        }

        private void guna2RatingStar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ptbNu_Click(object sender, EventArgs e)
        {

        }

        private void UC_ThoYeuThich_Load(object sender, EventArgs e)
        {

        }
    }
}
