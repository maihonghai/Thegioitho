using DTO;
using GUI.All_Tho_Control;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DTO.BaiDang;
using static DTO.BaiDangND;

namespace GUI.All_User_Control
{
    public partial class UC_DanhSachBaiDangND : UserControl
    {

        private BaiDangNDRepository baiDangNDRepository;

        public int IDNguoiDung;
        public UC_DanhSachBaiDangND()
        {
            InitializeComponent();
        }
        public UC_DanhSachBaiDangND(int iDNguoidung)
        {
            InitializeComponent();
            //  lblIDTho.Text = iDTho.ToString();
            IDNguoiDung = iDNguoidung;

            baiDangNDRepository = new BaiDangNDRepository();
            pnlDanhSachIDND.Controls.Clear();
            List<BaiDangND> danhSachBaiDang = new List<BaiDangND>();

            // Hiển thị danh sách bài đăng đã lấy được
            HienThiDanhSachBaiDang(danhSachBaiDang);
        }
        private void HienThiDanhSachBaiDang(List<BaiDangND> danhSachBaiDang)
        {
            baiDangNDRepository = new BaiDangNDRepository();
            pnlDanhSachIDND.Controls.Clear();
            danhSachBaiDang = baiDangNDRepository.LayBaiDangTheoIDNguoiDung(IDNguoiDung);

            // Lấy danh sách bài đăng từ cơ sở dữ liệu
            //List<BaiDang> danhSachBaiDang = baiDangRepository.LayDanhSachBaiDang();

            int x = 15; // Vị trí x của UserControl trong panel
            int y = 25; // Vị trí y của UserControl trong panel
            int k = 0;

            // Hiển thị thông tin của từng bài đăng trên giao diện
            foreach (BaiDangND baiDang in danhSachBaiDang)
            {
                // Tạo một UserControl mới để hiển thị thông tin của bài đăng
                UC_BaiDangND uC_BaiDang = new UC_BaiDangND(baiDang);

                Guna2Button btnXoa = uC_BaiDang.GetXoaButton();
               // Guna2Button btnChinhSua = uC_BaiDang.GetChinhSuaButton();

                btnXoa.Visible = true;
                //btnChinhSua.Visible = true;

                btnXoa.Click += (sender, e) =>
                {
                    HienThiDanhSachBaiDang(danhSachBaiDang);
                };
                // Thiết lập vị trí của UserControl
                uC_BaiDang.Location = new Point(x, y);
                uC_BaiDang.BackColor = Color.White;
                // Thêm UserControl vào panel pnlDanhSachBaiDang
                pnlDanhSachIDND.Controls.Add(uC_BaiDang);

        
                k++;
                if (k == 1)
                {
                    y += uC_BaiDang.Height + 10; // 10 là khoảng cách giữa các UserControl
                    x = 15;
                    k = 0;
                }
            }
        }

        private void ptbBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
