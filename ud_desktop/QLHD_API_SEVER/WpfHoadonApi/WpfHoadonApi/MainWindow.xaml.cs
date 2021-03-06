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
        private CHoaDon tempHD = new CHoaDon
        {
            sohd = "",
            ngaylaphd = DateTime.Now,
            tenkh = "",
            chiTietHoaDons = new List<CChiTietHoaDon>()
        };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void HienThi()
        {
            var hh = CXuLiHangHoa.getDSHH();
            var hd = CXuLiHoaDon.getDSHD();
            if (hh == null || hd == null) MessageBox.Show("Error connect sever...!");
            dgHoadon.ItemsSource = hd;
            cmbMahang.ItemsSource = hh;
        }
        private IEnumerable<Object> getCTHD(CHoaDon hd)
        {
            var kq = hd.chiTietHoaDons.Select(x => new
            {
                mahang = x.mahang,
                tenhang = x.hanghoa.tenhang,
                dvt = x.hanghoa.dvt,
                dongia = x.dongia,
                soluong = x.soluong,
                thanhtien = (x.dongia * x.soluong)
            });
            return kq;
        }
        private string getTongTienHD(CHoaDon hd)
        {
            return hd.chiTietHoaDons.Sum(x => x.dongia * x.soluong).ToString();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi();  
        }

        private void DgHoadon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            if (dgHoadon.SelectedValue == null) return;
            CHoaDon hd = CXuLiHoaDon.getHoaDon(dgHoadon.SelectedValue.ToString());
            DataGrid dg = e.DetailsElement.FindName("dgCTHD") as DataGrid;
            TextBox txt = e.DetailsElement.FindName("txtThanhtien") as TextBox;
            dg.ItemsSource = getCTHD(hd).ToList();
            txt.Text = hd.chiTietHoaDons.Sum(x => x.dongia * x.soluong).ToString();
        }

        private void DgHoadon_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgHoadon.SelectedValue == null) return;
            string id = dgHoadon.SelectedValue.ToString();
            CHoaDon hd = CXuLiHoaDon.getHoaDon(id);
            if (hd == null) return;
            txtSoHD.Text = hd.sohd;
            txtTenKH.Text = hd.tenkh;
            dpNgaylapHD.SelectedDate = hd.ngaylaphd;
            dgChitiet.ItemsSource = getCTHD(hd).ToList();
            txtThanhtien.Text = hd.chiTietHoaDons.Sum(x => x.dongia * x.soluong).ToString();
        }
        private void btnChon_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMahang.SelectedItem == null) return;
            CChiTietHoaDon ct = new CChiTietHoaDon();

            ct.hanghoa = cmbMahang.SelectedItem as CHangHoa;
            ct.mahang = ct.hanghoa.mahang;
            ct.dongia = ct.hanghoa.dongia;
            ct.soluong = int.Parse(txtSoluong.Text);

            tempHD.chiTietHoaDons.Add(ct);

            dgChitiet.ItemsSource = CXuLiHoaDon.getDSCTHoadon(tempHD);
            txtThanhtien.Text = CXuLiHoaDon.tongThanhtienHoadon(tempHD).ToString();
        }
        private void btnLapHD_Click(object sender, RoutedEventArgs e)
        {
            CHoaDon hd = new CHoaDon();
            hd.sohd = txtSoHD.Text;
            hd.ngaylaphd = dpNgaylapHD.SelectedDate;
            hd.tenkh = txtTenKH.Text;
            hd.chiTietHoaDons = tempHD.chiTietHoaDons.Select(x => new CChiTietHoaDon
            {
                sohd = txtSoHD.Text,
                mahang = x.mahang,
                dongia = x.dongia,
                soluong = x.soluong
            }).ToList();
            bool ok = CXuLiHoaDon.themHoadon(hd);
            if (ok == false) MessageBox.Show("Không thêm được!");
            else
            {
                HienThi();
                tempHD.chiTietHoaDons.Clear();
                dgChitiet.ItemsSource = CXuLiHoaDon.getDSCTHoadon(tempHD);
                txtThanhtien.Text = CXuLiHoaDon.tongThanhtienHoadon(tempHD).ToString();
            }
        }
    }
}
