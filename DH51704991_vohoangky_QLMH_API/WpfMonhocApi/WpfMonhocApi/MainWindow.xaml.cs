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

namespace WpfMonhocApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //CXuLyMonHoc XLMH = new CXuLyMonHoc();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgMonhoc.ItemsSource = CXuLyMonHoc.getDSMH();
        }

        private void dgMonhoc_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgMonhoc.SelectedValue == null) return;
            string msmh = dgMonhoc.SelectedValue.ToString();
            CMonHoc mh = CXuLyMonHoc.getMH(msmh);
            if (mh != null)
            {
               // txtMamh.IsEnabled = false;
                txtMamh.Text = mh.msmh;
                txtTenmh.Text = mh.tenmh;
                txtSotiet.Text = mh.sotiet.ToString();
            }
            return;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            CMonHoc mh = new CMonHoc();
            mh.msmh = txtMamh.Text;
            mh.tenmh = txtTenmh.Text;
            mh.sotiet = int.Parse(txtSotiet.Text);
            if (!CXuLyMonHoc.addMonHoc(mh))
            {
                MessageBox.Show("them that bai");
                return;
            }
            dgMonhoc.ItemsSource = CXuLyMonHoc.getDSMH();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgMonhoc.SelectedValue == null) return;
            string msmh = dgMonhoc.SelectedValue.ToString();
            bool result = CXuLyMonHoc.deleteMonHoc(msmh);
            if (!result)
            {
                MessageBox.Show("xoa that bai");
                return;
            }
            dgMonhoc.ItemsSource = CXuLyMonHoc.getDSMH();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgMonhoc.SelectedValue == null) return;
            string msmh = dgMonhoc.SelectedValue.ToString(); 
            CMonHoc mh = CXuLyMonHoc.getMH(msmh);
            mh.tenmh = txtTenmh.Text;
            mh.sotiet = int.Parse(txtSotiet.Text);
            if (!CXuLyMonHoc.updateMonHoc(mh))
            {
                MessageBox.Show("sua that bai");
                return;
            }
            dgMonhoc.ItemsSource = CXuLyMonHoc.getDSMH();
        }
    }
}
