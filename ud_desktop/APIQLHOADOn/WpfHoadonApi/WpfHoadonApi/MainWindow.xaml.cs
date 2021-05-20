using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHoadonApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CHoadon tempHD = new CHoadon
        {
            sohd = "",
            ngaylaphd = DateTime.Now,
            tenkh = "",
            chitiethoadons = new List<CChitiethoadon>()
        };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            List<CHoadon> ds = CXLHoadon.getDSHoadon();
            if (ds == null) MessageBox.Show("Lỗi conn DB");
            else dgHoadon.ItemsSource = ds;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
            // liên kết cbxHanghoa vs tập đt HH
            List<CHanghoa> dshh = CXLHanghoa.getDSHanghoa();
            if (dshh == null) MessageBox.Show("Lỗi conn DB");
            else cmbMahang.ItemsSource = dshh;
        }
        private void dgHoadon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            CHoadon t = e.Row.Item as CHoadon;

            //DetailsElement trả về chi tiết dòng -> find name tìm
            DataGrid dg = e.DetailsElement.FindName("dgCTHD") as DataGrid;
            TextBox txt = e.DetailsElement.FindName("txtThanhtien") as TextBox;

            // lấy hđ từ SV thông qua attr sohd từ t lúc chọn trong DG -> đưa lên server -> có HĐ
            CHoadon hd = CXLHoadon.getHoadon(t.sohd);
            if(hd != null)
            {
                dg.ItemsSource = CXLHoadon.getDSCTHoadon(hd);
                txt.Text = CXLHoadon.tongThanhtienHoadon(hd).ToString();
            }
        }
        private void btnChon_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMahang.SelectedItem == null) return;
            CChitiethoadon ct = new CChitiethoadon();

            ct.hanghoa = cmbMahang.SelectedItem as CHanghoa;
            ct.mahang = ct.hanghoa.mahang;
            ct.dongia = ct.hanghoa.dongia;
            ct.soluong = int.Parse(txtSoluong.Text);

            tempHD.chitiethoadons.Add(ct);

            dgChitiet.ItemsSource = CXLHoadon.getDSCTHoadon(tempHD);
            txtThanhtien.Text = CXLHoadon.tongThanhtienHoadon(tempHD).ToString();
        }

        private void btnLapHD_Click(object sender, RoutedEventArgs e)
        {
            CHoadon hd = new CHoadon();
            hd.sohd = txtSoHD.Text;
            hd.ngaylaphd = dpNgaylapHD.SelectedDate;
            hd.tenkh = txtTenKH.Text;
            hd.chitiethoadons = tempHD.chitiethoadons.Select(x => new CChitiethoadon
            {
                sohd=txtSoHD.Text,
                mahang=x.mahang,
                dongia=x.dongia,
                soluong=x.soluong
            }).ToList();
            bool ok = CXLHoadon.themHoadon(hd);
            if (ok == false) MessageBox.Show("Không thêm được!");
            else
            {
                hienthi();
                tempHD.chitiethoadons.Clear();
                dgChitiet.ItemsSource = CXLHoadon.getDSCTHoadon(tempHD);
                txtThanhtien.Text = CXLHoadon.tongThanhtienHoadon(tempHD).ToString();
            }
        }
    }
}
