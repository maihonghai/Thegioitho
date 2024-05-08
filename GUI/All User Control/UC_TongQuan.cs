using DAL;
using DTO;
using GUI.All_Tho_Control;
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

namespace GUI.All_User_Control
{
    public partial class UC_TongQuan : UserControl
    {
        private UC_BaiDang uC_BaiDang;
        public UC_TongQuan()
        {
            InitializeComponent();
            // Gọi phương thức để lấy danh sách các thơ được yêu thích nhiều nhất từ cơ sở dữ liệu
            List<ThongTinTho> danhSachTopTho = LayDanhSachTopThoYeuThich();

            // Hiển thị danh sách các thơ được yêu thích nhiều nhất lên panel
            HienThiDanhSachTho(danhSachTopTho);
        }

        private void HienThiDanhSachThoYeuThich()
        {
            ThongTinTho.ThoYeuThichRepository repository = new ThongTinTho.ThoYeuThichRepository();
            List<ThongTinTho> danhSachThoYeuThich = repository.LayDanhSachThoYeuThich(BLL.LoginBLL.IDNguoiDung);

            // Xóa tất cả các control hiện có trong panel trước khi thêm mới
            pnlDanhSachTho.Controls.Clear();

            int x = 10; // Vị trí x của UserControl trong panel
            int y = 15; // Vị trí y của UserControl trong panel

            // Duyệt qua danh sách các thợ yêu thích và hiển thị thông tin trên giao diện
            foreach (ThongTinTho thongTinTho in danhSachThoYeuThich)
            {
                UC_ThoYeuThich uC_Tho = new UC_ThoYeuThich(thongTinTho);


                // Lấy nút Hủy yêu thích từ UserControl
                Guna2Button btnHuyYeuThich = uC_Tho.GetBtnHuyYeuThich();

                // Đăng ký sự kiện từ UC_ThoYeuThich
                uC_Tho.XemBaiDangClicked += UC_ThoXemBaiDangTheoIDThoClicked;
                // Gắn sự kiện click cho nút Hủy yêu thích
                btnHuyYeuThich.Click += (sender, e) =>
                {
                    HienThiDanhSachThoYeuThich();
                };
                // Thiết lập vị trí của UserControl
                uC_Tho.Location = new Point(x, y);
                uC_Tho.BackColor = Color.White;
                uC_Tho.SendToBack();
                uC_Tho.BorderStyle = BorderStyle.FixedSingle;
                pnlDanhSachTho.Controls.Add(uC_Tho);

                // Tăng vị trí y cho UserControl tiếp theo
                x += uC_Tho.Width + 20; // 10 là khoảng cách giữa các UserControl
                pnlDanhSachTho.AutoScrollMinSize = new Size(x, pnlDanhSachTho.Height);
            }
        }
        private void UC_ThoXemBaiDangTheoIDThoClicked(object sender, int IDTho)
        {
            // Ép kiểu sender về UC_BaiDang
            //UC_BaiDang uC_BaiDang = sender as UC_BaiDang;
            // Khởi tạo thể hiện của UC_BaiDang
            uC_BaiDang = new UC_BaiDang(IDTho);

            // Kiểm tra xem uC_BaiDang có khác null trước khi tiếp tục
            if (uC_BaiDang != null)
            {
                // Sử dụng thể hiện của UC_BaiDang để gọi phương thức LayDanhSachBaiDangTheoIDTho
                List<BaiDang> danhSachBaiDang = uC_BaiDang.LayDanhSachBaiDangTheoIDTho(IDTho);
                // Lấy tham chiếu đến nút Quay lại từ UC_BaiDang
                Guna2Button btnQuayLai = uC_BaiDang.GetQuayLaiButton();

                // Đặt thuộc tính Visible của nút Quay lại
                btnQuayLai.Visible = true;

                // Tiếp tục hiển thị danh sách bài đăng
                // Ví dụ:
                // Thêm UC_BaiDang vào panel của UserControl hiện tại:
                this.Controls.Add(uC_BaiDang);
                uC_BaiDang.Dock = DockStyle.Fill;
                uC_BaiDang.BringToFront();
            }
            else
            {
                //Console.WriteLine(sender);
                // Xử lý trường hợp khi uC_BaiDang là null
                MessageBox.Show("Không có bài dăng!");

            }
        }

        private void btnTopTho_Click(object sender, EventArgs e)
        {
            // Gọi phương thức để lấy danh sách các thơ được yêu thích nhiều nhất từ cơ sở dữ liệu
            List<ThongTinTho> danhSachTopTho = LayDanhSachTopThoYeuThich();

            // Hiển thị danh sách các thơ được yêu thích nhiều nhất lên panel
            HienThiDanhSachTho(danhSachTopTho);
        }
        private List<ThongTinTho> LayDanhSachTopThoYeuThich()
        {
            // Gọi phương thức từ repository để lấy danh sách các thơ được yêu thích nhiều nhất
            ThongTinTho.ThoYeuThichRepository repository = new ThongTinTho.ThoYeuThichRepository();
            List<ThongTinTho> danhSachTopTho = repository.LayDanhSachTopThoYeuThich();

            return danhSachTopTho;
        }

        private void HienThiDanhSachTho(List<ThongTinTho> danhSachTho)
        {
            // Xóa tất cả các control hiện có trong panel trước khi thêm mới
            pnlDanhSachTho.Controls.Clear();

            int x = 10; // Vị trí x của UserControl trong panel
            int y = 15; // Vị trí y của UserControl trong panel

            // Duyệt qua danh sách các thợ yêu thích và hiển thị thông tin trên giao diện
            foreach (ThongTinTho thongTinTho in danhSachTho)
            {
                UC_ThoYeuThich uC_Tho = new UC_ThoYeuThich(thongTinTho);

                // Lấy nút Hủy yêu thích từ UserControl
                Guna2Button btnHuyYeuThich = uC_Tho.GetBtnHuyYeuThich();
                btnHuyYeuThich.Visible = false;
                //lblSoLuot

                Guna2HtmlLabel lblYeuThich = uC_Tho.GetSoLuotYeuThich();
                lblYeuThich.Visible = true;

                // Đăng ký sự kiện từ UC_ThoYeuThich
                uC_Tho.XemBaiDangClicked += UC_ThoXemBaiDangTheoIDThoClicked;

                // Gắn sự kiện click cho nút Hủy yêu thích
                /* btnHuyYeuThich.Click += (sender, e) =>
                 {
                     // Sau khi hủy yêu thích, cập nhật lại danh sách top thơ yêu thích
                     btnTopTho_Click(sender, e);
                 };*/

                // Thiết lập vị trí của UserControl
                uC_Tho.Location = new Point(x, y);
                uC_Tho.BackColor = Color.White;
                uC_Tho.SendToBack();
                uC_Tho.BorderStyle = BorderStyle.FixedSingle;
                pnlDanhSachTho.Controls.Add(uC_Tho);
                // Tăng vị trí y cho UserControl tiếp theo
                x += uC_Tho.Width + 20; // 10 là khoảng cách giữa các UserControl
                pnlDanhSachTho.AutoScrollMinSize = new Size(x, pnlDanhSachTho.Height);
            }
        }

        private void btnThoBiHuy_Click(object sender, EventArgs e)
        {
            // Gọi phương thức để lấy danh sách các thợ bị hủy xét từ cơ sở dữ liệu
            List<ThongTinTho> danhSachThoBiHuy = LayDanhSachThoBiHuy();

            // Hiển thị danh sách các thợ bị hủy xét lên panel
            HienThiDanhSachTho(danhSachThoBiHuy);
        }
        private List<ThongTinTho> LayDanhSachThoBiHuy()
        {
            // Gọi phương thức từ repository để lấy danh sách các thợ bị hủy xét
            ThongTinTho.ThoYeuThichRepository repository = new ThongTinTho.ThoYeuThichRepository();
            List<ThongTinTho> danhSachThoBiHuy = repository.LayDanhSachThoBiHuy();

            return danhSachThoBiHuy;
        }

        private void btnTopDanhGia_Click(object sender, EventArgs e)
        {
            // Gọi phương thức để lấy danh sách các thợ được đánh giá cao nhất từ cơ sở dữ liệu
            List<ThongTinTho> danhSachTopDanhGia = LayDanhSachTopDanhGia();

            // Hiển thị danh sách các thợ được đánh giá cao nhất lên panel
            HienThiDanhSachTho(danhSachTopDanhGia);

            // Hiển thị GunaRatingStar cho từng UserControl UC_ThoYeuThich trong danh sách
            foreach (UC_ThoYeuThich thoYeuThich in pnlDanhSachTho.Controls)
            {
                thoYeuThich.HienThiRatingStar(thoYeuThich.LaySoSaoDanhGia(thoYeuThich.IDTho));
            }
        }

        private List<ThongTinTho> LayDanhSachTopDanhGia()
        {
            // Gọi phương thức từ repository để lấy danh sách các thợ được đánh giá cao nhất
            // (Bạn cần thêm phương thức này vào `ThoYeuThichRepository`)
            ThongTinTho.ThoYeuThichRepository repository = new ThongTinTho.ThoYeuThichRepository();
            List<ThongTinTho> danhSachTopDanhGia = repository.LayDanhSachTopDanhGia();

            return danhSachTopDanhGia;
        }

        private void btnTopDoanhThu_Click(object sender, EventArgs e)
        {
            List<ThongTinTho> danhSachTopDoanhThu = LayDanhSachTopDoanhThu();
            HienThiDanhSachTho(danhSachTopDoanhThu);

            foreach (UC_ThoYeuThich thoYeuThich in pnlDanhSachTho.Controls)
            {
                thoYeuThich.HienThiDoanhThu(thoYeuThich.LayDoanhThu(thoYeuThich.IDTho));
            }
        }

        private List<ThongTinTho> LayDanhSachTopDoanhThu()
        {
            ThongTinTho.ThoYeuThichRepository repository = new ThongTinTho.ThoYeuThichRepository();
            List<ThongTinTho> danhSachTopDoanhThu = repository.LayDanhSachTopDoanhThu();

            return danhSachTopDoanhThu;
        }

        private void btnTopCongViec_Click(object sender, EventArgs e)
        {
            XemTop5CongViecDuocDatNhieuNhatTheoLinhVuc();

        }

        private void XemTop5CongViecDuocDatNhieuNhatTheoLinhVuc()
        {
            // Xóa các điều khiển hiện có trong panel1 (nếu có)
            pnlDanhSachTho.Controls.Clear();

            // Thực hiện truy vấn SQL để lấy top 5 công việc được book nhiều nhất theo lĩnh vực
            string query = @"SELECT cv.LinhVuc, COUNT(*) AS SoLanDat
                    FROM CongViec cv
                    GROUP BY cv.LinhVuc
                    ORDER BY SoLanDat DESC
                    OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";

            // Thực hiện truy vấn và lấy kết quả
            DataTable dt = new DataTable();
            using (SqlConnection connection = ConnectionDAL.GetSqlConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }

            // Tạo DataGridView để hiển thị kết quả
            DataGridView dgvTop5CongViec = new DataGridView();
            dgvTop5CongViec.AutoGenerateColumns = true;
            dgvTop5CongViec.Dock = DockStyle.Fill;

            // Tạo và thêm cột vào DataGridView
            DataGridViewTextBoxColumn colLinhVuc = new DataGridViewTextBoxColumn();
            colLinhVuc.HeaderText = "Lĩnh Vực";
            colLinhVuc.DataPropertyName = "LinhVuc";
            dgvTop5CongViec.Columns.Add(colLinhVuc);

            DataGridViewTextBoxColumn colSoLanDat = new DataGridViewTextBoxColumn();
            colSoLanDat.HeaderText = "Số Lần Đặt";
            colSoLanDat.DataPropertyName = "SoLanDat";
            dgvTop5CongViec.Columns.Add(colSoLanDat);

            // Gán dữ liệu cho DataGridView
            dgvTop5CongViec.DataSource = dt;

            dgvTop5CongViec.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvTop5CongViec.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTop5CongViec.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvTop5CongViec.DefaultCellStyle.BackColor = Color.LightGray;
            dgvTop5CongViec.DefaultCellStyle.ForeColor = Color.Black;
            dgvTop5CongViec.DefaultCellStyle.Font = new Font("Arial", 9);

            dgvTop5CongViec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động điều chỉnh kích thước cột để lấp đầy DataGridView
            dgvTop5CongViec.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Tự động điều chỉnh kích thước hàng để vừa với nội dung của cell


            // Thêm DataGridView vào panel1
            pnlDanhSachTho.Controls.Add(dgvTop5CongViec);
        }

        private void pnlDanhSachTho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_TongQuan_Load(object sender, EventArgs e)
        {

        }
    }
}
