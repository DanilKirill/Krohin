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
using WpfApp1.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для GiftSertificateWind.xaml
    /// </summary>
    public partial class GiftSertificateWind : Window
    {
        Vxod Login = new Vxod();
        string DateNow = "";
        k_kiri11Entities db=new k_kiri11Entities();
        public GiftSertificateWind(Vxod Login,string DateNow)
        {
            InitializeComponent();
            this.Login = Login;
            this.DateNow = DateNow;
            GifSertificateWind.Title = GifSertificateWind + "/ Пользователь " + Login + "/ Дата входа" + DateNow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from item in db.GiftSertificate
                        select item;
            dgGiftSertificate.ItemsSource = query.ToList();
        }

        private void btnCreateGiftSertificate_Click(object sender, RoutedEventArgs e)
        {
            CreateGiftSertificate createGiftSertificate = new CreateGiftSertificate();
            createGiftSertificate.ShowDialog();

            var query = from item in db.GiftSertificate
                        select item;
            dgGiftSertificate.ItemsSource = query.ToList();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(Login,DateNow);
            menu.Show();
            Hide();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgGiftSertificate.SelectedItem != null)
            {
                GiftSertificate giftSertificate = (GiftSertificate)dgGiftSertificate.SelectedItem;
                if (MessageBox.Show("Вы точно хотите удалить?", "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    db.GiftSertificate.Remove(giftSertificate);
                    db.SaveChanges();
                }
                var query = from item in db.GiftSertificate
                            select item;
                dgGiftSertificate.ItemsSource = query.ToList();
            }
            }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dgGiftSertificate.IsReadOnly =false;
            btnCreateGiftSertificate.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnSave.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgGiftSertificate.IsReadOnly = true;
            btnCreateGiftSertificate.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnSave.IsEnabled = false;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            var all =db.GiftSertificate.OrderBy(p => p.Id).Where(i=>i.Status=="Used").ToList();
            var application = new Excel.Application();
            application.Visible = true;
            application.SheetsInNewWorkbook = 1;
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            int start = 1;
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            worksheet.Name = "ПодарочныеСертификаты";
            worksheet.Cells[1][start] = "Номер";
            worksheet.Cells[2][start] = "Дата";
            worksheet.Cells[3][start] = "Номинал";
           

            start++;
            for (int i = 0; i <all.Count; i++)
            {
                worksheet.Cells[1][start] = all[i].Number;
                worksheet.Cells[2][start] = all[i].Date;
                worksheet.Cells[3][start] = all[i].Nominal;
                start++;
            }
          
           
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee(Login,DateNow);
            employee.Show();
            Hide();
        }

        private void btnBludo_Click(object sender, RoutedEventArgs e)
        {
            Bludo bludo = new Bludo(Login,DateNow);
            bludo.Show();
            Hide();
        }

        private void btnRegZakWind_Click(object sender, RoutedEventArgs e)
        {
            RegZakWind regZakWind = new RegZakWind(Login,DateNow);
            regZakWind.Show();
            Hide();
        }
    }
}
