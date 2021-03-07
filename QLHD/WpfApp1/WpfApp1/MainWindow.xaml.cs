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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private hoadonEntities dc = new hoadonEntities();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgHoaDon.ItemsSource = dc.hoadons.ToList();
            cmbMahang.ItemsSource = dc.hanghoas.ToList();
        }
        private IEnumerable<object> getCTHD(hoadon hd)
        {
            var kq = hd.chitiethoadons.Select(x => new
            {
                mahang = x.mahang,
                tenhang = x.hanghoa.tenhang,
                dvt = x.hanghoa.dvt,
                dongia = x.dongia,
                soluong = x.soluong,
                thanhtien = (x.dongia * x.soluong)
            });
            return kq.ToList();
        }
        private string getTongTienHD(hoadon hd)
        {
            return hd.chitiethoadons.Sum(x => x.dongia* x.soluong).ToString();
        }
        private void DgHoaDon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            hoadon hd = e.Row.Item as hoadon;
            DataGrid dg = e.DetailsElement.FindName("dgCTHD") as DataGrid;
            TextBox txt = e.DetailsElement.FindName("txtThanhTien") as TextBox;
            dg.ItemsSource = getCTHD(hd);
            txt.Text = getTongTienHD(hd);
        }
        private hoadon tempHD = new hoadon();
        private void BtnThemCTHD_click(object sender, RoutedEventArgs e)
        {
            if (cmbMahang.SelectedItem == null) { return; }
            chitiethoadon ct = new chitiethoadon();
            ct.hanghoa = cmbMahang.SelectedItem as hanghoa;
            ct.mahang = ct.hanghoa.mahang;
            ct.dongia = ct.hanghoa.dongia;
            ct.soluong = int.Parse(txtsoluong.Text);
            chitiethoadon tempCTDH = (from x in tempHD.chitiethoadons where x.sohd==ct.sohd select x) as chitiethoadon;
            if (tempCTDH != null)
            {
                ct.soluong = tempCTDH.soluong + ct.soluong;
                tempHD.chitiethoadons.Remove(tempCTDH);
            }
            tempHD.chitiethoadons.Add(ct);
            dgCTHD.ItemsSource = getCTHD(tempHD);
            txtThanhTien.Text = getTongTienHD(tempHD);
        }

        private void BtnLapHoaDon_Click(object sender, RoutedEventArgs e)
        {
            hoadon hd = new hoadon();
            hd.sohd = txtMSHD.Text;
            hd.ngaylaphd = dpNgayLap.SelectedDate;
            hd.tenkh = txtTenHang.Text;
            foreach(chitiethoadon t in tempHD.chitiethoadons)
            {
                t.sohd = hd.sohd;
                hd.chitiethoadons.Add(t);
            }
            dc.hoadons.Add(hd);
            dc.SaveChanges();
            tempHD.chitiethoadons.Clear();
            dgHoaDon.ItemsSource = dc.hoadons.ToList();
        }

        private void BtnXoaCTDH_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
