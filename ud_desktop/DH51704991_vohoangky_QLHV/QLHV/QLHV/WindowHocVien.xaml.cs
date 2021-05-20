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
using System.Windows.Shapes;

namespace QLHV
{
    /// <summary>
    /// Interaction logic for WindowHocVien.xaml
    /// </summary>
    public enum luaChon { add, update };

    public partial class WindowHocVien : Window
    {
        private qlhvEntities dc = new qlhvEntities();
        public luaChon pheptoan;
        public lylich hv;

        public WindowHocVien()
        {
            InitializeComponent();
        }
        private void ShowDiem(string mshv)
        {
            var diem = (from a in dc.diemthis where a.mshv == mshv select a).ToList();
            var kq = diem.Select(x => new {
                mshv = x.mshv,
                msmh = x.msmh,
                diem = x.diem,
                lylich = x.lylich.tenhv,
                monhoc = x.monhoc.tenmh
            });
            dgBangDiem.ItemsSource = kq.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbLop.ItemsSource = dc.lops.ToList();
            if (pheptoan == luaChon.update)
            {
                txtMSHV.IsReadOnly = true;
                txtMSHV.Text = hv.mshv;
                txtTenHV.Text = hv.tenhv;
                dpNgaySinh.SelectedDate = hv.ngaysinh;
                if (hv.phai.Value) rdoNam.IsChecked = true; else rdoNu.IsChecked = true;
                cmbLop.SelectedValue = hv.malop;
                //dgBangDiem.ItemsSource = dc.diemthis.ToList();
                ShowDiem(hv.mshv);
            }
        }
        private void btnExit_click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void btnUpdate_click(object sender, RoutedEventArgs e)
        {
            hv = new lylich();
            hv.mshv = txtMSHV.Text;
            hv.tenhv = txtTenHV.Text;
            hv.ngaysinh = dpNgaySinh.SelectedDate;
            hv.phai = rdoNam.IsChecked;
            hv.malop = cmbLop.SelectedValue.ToString();
            lylich hocvien = dc.lyliches.Find(hv.mshv);
            if (hocvien != null && this.pheptoan == luaChon.add)
            {
                MessageBox.Show("Đã tồn tại mã số học viên này.");
                return;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
