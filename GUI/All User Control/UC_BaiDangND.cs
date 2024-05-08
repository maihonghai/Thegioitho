using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DTO.BaiDangND;

namespace GUI.All_User_Control
{
    public partial class UC_BaiDangND : UserControl
    {
        public int IDBaiDangND { get; set; }
        public Guna2Button GetXoaButton() { return btnXoaBaiDang; }
        //public Guna2Button GetChinhSuaButton() { return btnChinhSua; }
        public UC_BaiDangND(BaiDangND baiDang)
        {
            InitializeComponent();
            //lblIDBaiDang.Text = baiDang.IDBaiDangND.ToString();
            //txtTenKhachHang.Text = baiDang.HoTen;
            txtDiaChi.Text = baiDang.DiaChi;
            //txtSoDienThoai.Text = baiDang.SoDienThoai;
            txtLinhVuc.Text = baiDang.CongViec;
            //txtLichThoDen.Text = baiDang.LichThoDen.ToString("dd/MM/yyyy");
            txtmota.Text = baiDang.MoTa;
            lblTieuDE.Text = baiDang.TieuDe;
            //txtGio.Text = baiDang.Gio;
            Image hinhanhmota = ByteArrayToImage(baiDang.HinhAnhMoTa);
            pbAnh.Image = hinhanhmota;

            IDBaiDangND = int.Parse(baiDang.IDBaiDangND.ToString());
        }
        // Hàm để chuyển đổi mảng byte thành hình ảnh
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        private void pnThongTin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            FrmXemKhachHang form = new FrmXemKhachHang(IDBaiDangND);
            form.ShowDialog();
        }

        private void btnXoaBaiDang_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa bài đăng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Gọi phương thức xóa bài đăng từ repository
                BaiDangNDRepository repository = new BaiDangNDRepository();
                repository.XoaBaiDang(IDBaiDangND);

                // Sau khi xóa, có thể thực hiện các hành động khác như cập nhật giao diện, thông báo thành công, v.v.

                // Ví dụ: Xóa control UC_BaiDangND khỏi cha của nó sau khi đã xóa bài đăng thành công
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
