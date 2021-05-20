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
using System.IO;
using Microsoft.Win32;

namespace WpfHinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        private string path = "";    
        public MainWindow()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            List<CHocvien> ds = CXuLyHocVien.getDSHocvien();
            if (ds == null) MessageBox.Show("Loi ket noi Server!!!");
            else dgHocvien.ItemsSource = ds;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private void dgHocvien_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            CHocvien t = e.Row.Item as CHocvien;
            Image img = e.DetailsElement.FindName("imgHinh") as Image;
            if (t.hinh == "") img.Source = null;
            else
            {
                byte[] buf = CXuLyHocVien.getHinhHocvien(t.hinh);
                if (buf == null) MessageBox.Show("Khong doc duoc file hinh :)))");
                else
                {
                    MemoryStream ms = new MemoryStream(buf);
                    BitmapImage bm = new BitmapImage();
                    bm.BeginInit();
                    bm.StreamSource = ms;
                    bm.EndInit();
                    img.Source = bm;
                }
            }

        }
        private void dgHocvien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(rdoSua.IsChecked==true)
            {
                if (dgHocvien.SelectedItem == null) return;
                CHocvien t = dgHocvien.SelectedItem as CHocvien;
                txtMahv.Text = t.mshv;
                txtTenhv.Text = t.tenhv;
                if (t.hinh == "")
                {
                    imgHinh.Source = null;
                }
                else
                {
                    byte[] buf = CXuLyHocVien.getHinhHocvien(t.hinh);
                    if (buf == null) MessageBox.Show("Khong doc duoc file hinh :)))");
                    else
                    {
                        MemoryStream ms = new MemoryStream(buf);
                        BitmapImage bm = new BitmapImage();
                        bm.BeginInit();
                        bm.StreamSource = ms;
                        bm.EndInit();
                        imgHinh.Source = bm;
                    }
                }
            }
        }
        private void btnChonhinh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog()==true)
            {
                FileStream f = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                byte[] buf = new byte[f.Length];
                f.Read(buf, 0, (int)f.Length);
                f.Close();
                MemoryStream ms = new MemoryStream(buf);
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.StreamSource = ms;
                bm.EndInit();
                imgHinh.Source = bm;
            }
        }

        private void btnBochon_Click(object sender, RoutedEventArgs e)
        {
            imgHinh.Source = null;
        }

        private void btnThuchien_Click(object sender, RoutedEventArgs e)
        {
            if(rdoThem.IsChecked==true)
            {
                CHocvien hv = new CHocvien();
                hv.mshv = txtMahv.Text;
                hv.tenhv = txtTenhv.Text;
                if (imgHinh.Source == null)
                {
                    hv.hinh = "";
                }
                else
                {
                    hv.hinh = hv.mshv;
                    BitmapImage bm = imgHinh.Source as BitmapImage;
                    MemoryStream ms = bm.StreamSource as MemoryStream;
                    bool okHinh = CXuLyHocVien.themHinhHocvien(hv.hinh, ms.ToArray());
                    if (okHinh == false) MessageBox.Show("Loi ghi file hinh !!!");
                }
                bool ok = CXuLyHocVien.themHocvien(hv);
                if (ok == false) MessageBox.Show("Loi ghi thong tin hoc vien");
                else hienthi();
            }
            else if(rdoXoa.IsChecked==true)
            {
                if (dgHocvien.SelectedItem == null) return;
                CHocvien hv = dgHocvien.SelectedItem as CHocvien;
                if (hv.hinh != "")
                {
                    bool okHinh = CXuLyHocVien.xoaHinhHocvien(hv.hinh);
                    if (okHinh == false) MessageBox.Show("Khong xoa duoc hinh!!!");
                }
                bool ok = CXuLyHocVien.xoaHocvien(hv.mshv);
                if (ok == false) MessageBox.Show("Khong xoa duoc thong tin hoc vien");
                else hienthi();
            }else if(rdoSua.IsChecked==true)
            {
                if (dgHocvien.SelectedItem == null) return;
                CHocvien t = dgHocvien.SelectedItem as CHocvien;

                CHocvien hv = new CHocvien();
                hv.mshv = txtMahv.Text;
                hv.tenhv = txtTenhv.Text;
                if(imgHinh.Source==null)
                {
                    hv.hinh = "";
                    if (t.hinh != "")
                    {
                        if (CXuLyHocVien.xoaHinhHocvien(t.hinh) == false)
                            MessageBox.Show("Khong xoa duoc hinh!!");
                    }
                }
                else
                {
                    hv.hinh = hv.mshv;
                    if (t.hinh != "")
                    {
                        if (CXuLyHocVien.xoaHinhHocvien(t.hinh) == false)
                            MessageBox.Show("Khong xoa duoc hinh!!");
                    }
                    BitmapImage bm = imgHinh.Source as BitmapImage;
                    MemoryStream ms = bm.StreamSource as MemoryStream;
                    if (CXuLyHocVien.themHinhHocvien(hv.hinh, ms.ToArray()) == false)
                        MessageBox.Show("Khong ghi duoc hinh");
                }
                bool ok = CXuLyHocVien.suaHocvien(hv);
                if (ok == false) MessageBox.Show("Loi sua thong tin hoc vien");
                else hienthi();
            }
        }

        private void rdoThem_Click(object sender, RoutedEventArgs e)
        {
            txtMahv.IsReadOnly = false;
            txtTenhv.IsReadOnly = false;
            btnChonhinh.IsEnabled = true;
            btnBochon.IsEnabled = true;
        }

        private void rdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtMahv.IsReadOnly = true;
            txtTenhv.IsReadOnly = true;
            btnChonhinh.IsEnabled = false;
            btnBochon.IsEnabled = false;
        }

        private void rdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtMahv.IsReadOnly = true;
            txtTenhv.IsReadOnly = false;
            btnChonhinh.IsEnabled = true;
            btnBochon.IsEnabled = true;
        }

        
    }
}
