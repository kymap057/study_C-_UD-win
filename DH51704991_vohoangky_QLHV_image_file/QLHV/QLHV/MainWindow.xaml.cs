using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        private hinhEntities dc = new hinhEntities();
        private string path = "";
        FileStream f = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
            dgHocVien.ItemsSource = dc.hocviens.ToList();
            DirectoryInfo df = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
            df = df.Parent;
            df = df.Parent;
            //MessageBox.Show(df.FullName);
            path = df.FullName + @"\image\";
            //MessageBox.Show(path);
        }
        private void DgHocVien_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            hocvien hv = e.Row.Item as hocvien;
            Image img = e.DetailsElement.FindName("imgHinh") as Image;
            if (hv.hinh == null)
            {
                img.Source = null;
            }
            else
            {
                if (f != null)
                {
                    f.Close();
                }
                f = new FileStream(path + hv.hinh, FileMode.Open);
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.StreamSource = f;
                bm.EndInit();
                img.Source = bm;
            }
        }
        private void BtnChonHinh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog odg = new OpenFileDialog();
            if (odg.ShowDialog() == true)
            {
                if (imgHinh.Source != null)
                {
                    BitmapImage t = imgHinh.Source as BitmapImage;
                    t.StreamSource.Close();
                    imgHinh.Source = null;
                }
                if (f != null)
                {
                    f.Close();
                }
                f = new FileStream(odg.FileName, FileMode.Open);
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.StreamSource = f;
                bm.EndInit();
                imgHinh.Source = bm;
            }
        }

        private void BtnBoChonHinh_Click(object sender, RoutedEventArgs e)
        {
            if (imgHinh.Source != null)
            {
                BitmapImage t = imgHinh.Source as BitmapImage;
                t.StreamSource.Close();
                imgHinh.Source = null;
            }
        }

        private void BtnHien_Click(object sender, RoutedEventArgs e)
        {
            if (rdoThem.IsChecked == true)
            {
                if (txtMshv.Text == "" || txtTenhv.Text == "")
                {
                    MessageBox.Show("không được để trống các thuộc tính...!");
                    return;
                }
                hocvien hvCheck = dc.hocviens.Find(txtMshv.Text) as hocvien;
                if (hvCheck != null)
                {
                    MessageBox.Show("đã tồn tại học viên.");
                    return;
                }
                hocvien hv = new hocvien();
                hv.mshv = txtMshv.Text;
                hv.tenhv = txtTenhv.Text;
                if (imgHinh.Source == null)
                {
                    hv.hinh = null;
                }
                else
                {
                    BitmapImage t = imgHinh.Source as BitmapImage;
                    FileStream f = t.StreamSource as FileStream;
                    FileInfo fi = new FileInfo(f.Name);
                    hv.hinh = hv.mshv + fi.Extension;
                    File.Copy(f.Name, path + hv.hinh);
                    f.Close();
                }
                dc.hocviens.Add(hv);
                dc.SaveChanges();
                dgHocVien.ItemsSource = dc.hocviens.ToList();
                return;
            }
            else if (rdoXoa.IsChecked == true)
            {
                if (dgHocVien.SelectedValue == null)
                    return;
                string mahv = dgHocVien.SelectedValue.ToString();
                hocvien hv = dc.hocviens.Find(mahv);
                if (hv != null)
                {
                    if (hv.hinh != null)
                    {
                        if (f != null)
                        {
                            f.Close();
                        }
                        imgHinh.Source = null;
                        File.Delete(path + hv.hinh);
                    }
                    dc.hocviens.Remove(hv);
                    dc.SaveChanges();
                    dgHocVien.ItemsSource = dc.hocviens.ToList();
                }
            }
            else if (rdoSua.IsChecked == true)
            {
                if (dgHocVien.SelectedValue == null)
                    return;
                string mahv = dgHocVien.SelectedValue.ToString();
                hocvien hv = dc.hocviens.Find(mahv);
                if (hv != null)
                {
                    hv.tenhv = txtTenhv.Text;
                    if (imgHinh.Source == null)
                    {
                        hv.hinh = null;
                    }
                    else
                    {
                        BitmapImage t = imgHinh.Source as BitmapImage;
                        FileStream f = t.StreamSource as FileStream;
                        FileInfo fi = new FileInfo(f.Name);
                        if (fi.Name != hv.hinh)
                        {
                            hv.hinh = hv.mshv + fi.Extension;
                            File.Copy(f.Name, path + hv.hinh);
                        }
                        f.Close();
                    }
                    dc.SaveChanges();
                    dgHocVien.ItemsSource = dc.hocviens.ToList();
                }
            }
        }

        private void RdoThem_Click(object sender, RoutedEventArgs e)
        {
            txtMshv.IsReadOnly = false;
            txtTenhv.IsReadOnly = false;
            btnChonHinh.IsEnabled = true;
            btnBoChonHinh.IsEnabled = true;
        }

        private void RdoXoa_Click(object sender, RoutedEventArgs e)
        {
            txtMshv.IsReadOnly = true;
            txtTenhv.IsReadOnly = true;
            btnChonHinh.IsEnabled = false;
            btnBoChonHinh.IsEnabled = false;

        }

        private void RdoSua_Click(object sender, RoutedEventArgs e)
        {
            txtMshv.IsReadOnly = true;
            txtTenhv.IsReadOnly = false;
            btnChonHinh.IsEnabled = true;
            btnBoChonHinh.IsEnabled = true;

        }

        private void DgHocVien_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgHocVien.SelectedValue == null) return;
            string mshv = dgHocVien.SelectedValue.ToString();
            hocvien hvSeclect = dc.hocviens.Find(mshv) as hocvien;
            if (hvSeclect != null)
            {
                if (f != null)
                {
                    f.Close();
                }
                rdoSua.IsChecked = true;
                txtMshv.IsReadOnly = true;
                txtTenhv.IsReadOnly = false;
                btnChonHinh.IsEnabled = true;
                btnBoChonHinh.IsEnabled = true;
                txtMshv.Text = hvSeclect.mshv;
                txtTenhv.Text = hvSeclect.tenhv;
                if (hvSeclect.hinh == null)
                {
                    imgHinh.Source = null;
                }
                else
                {
                    f = new FileStream(path + hvSeclect.hinh, FileMode.Open);
                    BitmapImage bm = new BitmapImage();
                    bm.BeginInit();
                    bm.StreamSource = f;
                    bm.EndInit();
                    imgHinh.Source = bm;
                }
            }
            else return;
        }
    }
}
