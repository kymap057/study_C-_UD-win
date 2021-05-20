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

namespace QLHV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private qlhvEntities dc = new qlhvEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            showHVTable();
        }
        private void showHVTable()
        {
            var kq = dc.lyliches.ToList().Select(x => new
            {
                mshv = x.mshv,
                tenhv = x.tenhv,
                ngaysinh = x.ngaysinh.Value.ToShortDateString(),
                phai = x.phai.Value ? "nam" : "nữ",
                malop = x.malop,
                tenlop = x.lop.tenlop
            });
            dgqlhv.ItemsSource = kq;
        }

        private void BtnXoaHV_Click(object sender, RoutedEventArgs e)
        {
            string mshv = dgqlhv.SelectedValue.ToString();
            if (dgqlhv.SelectedValue != null)
            {
                var checkHV = (from x in dc.diemthis where mshv == x.mshv select x).ToList();
                if (checkHV.Count > 0)
                {
                    MessageBox.Show("không thể xóa học viên.");
                    return;
                }
                lylich hv = dc.lyliches.Find(mshv);
                if (hv != null)
                {
                    dc.lyliches.Remove(hv);
                    dc.SaveChanges();
                }
            }
            showHVTable();
        }
        private void BtnSuaHV_Click(object sender, RoutedEventArgs e)
        {
            WindowHocVien dialogHV = new WindowHocVien();
            dialogHV.pheptoan = luaChon.update;
            dialogHV.hv = dc.lyliches.Find(dgqlhv.SelectedValue);
            if (dialogHV.ShowDialog() == true && dialogHV.pheptoan == luaChon.update)
            {
                lylich hv = dc.lyliches.Find(dialogHV.hv.mshv);
                if (hv != null)
                {
                    hv.tenhv = dialogHV.hv.tenhv;
                    hv.ngaysinh = dialogHV.hv.ngaysinh;
                    hv.phai = dialogHV.hv.phai;
                    hv.malop = dialogHV.hv.malop;
                    dc.SaveChanges();
                    showHVTable();
                }
            }
        }
        private void BtnthemHV_Click(object sender, RoutedEventArgs e)
        {
            WindowHocVien dialogHV = new WindowHocVien();
            dialogHV.pheptoan = luaChon.add;
            if (dialogHV.ShowDialog() == true && dialogHV.pheptoan == luaChon.add)
            {
                dc.lyliches.Add(dialogHV.hv);
                dc.SaveChanges();
                showHVTable();
            }
        }
    }
}
