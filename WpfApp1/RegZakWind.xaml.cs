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
using WpfApp1.Data;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RegZakWind.xaml
    /// </summary>
    public partial class RegZakWind : System.Windows.Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
        Model.Vxod Login =new Model.Vxod();
        string DateNow = "";
        Model.Menu newBludo=new Model.Menu();

        public RegZakWind(Model.Vxod Login,string DateNow)
        {
            InitializeComponent();
            this.Login = Login;
            this.DateNow = DateNow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from item in db.RegistrationZakaza
                        select item;
            dgZakazi.ItemsSource = query.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dgZakazi.IsReadOnly = false;
            btnCreateBludo.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnSave.IsEnabled = true;
            btnImport.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgZakazi.IsReadOnly = true;
            btnCreateBludo.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnImport.IsEnabled = true;
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee(Login,DateNow);
            emp.Show();
            Hide();
        }

        private void btnBludo_Click(object sender, RoutedEventArgs e)
        {
            Bludo bludo = new Bludo(Login,DateNow);
            bludo.Show();
            Hide();
        }

        private void btnCreateBludo_Click(object sender, RoutedEventArgs e)
        {
            Model.RegistrationZakaza registrationZakaza = new RegistrationZakaza();
            db.RegistrationZakaza.Add(registrationZakaza);
            db.SaveChanges();
            
            CreateRegZakazNewWind createRegZakazNewWind  = new CreateRegZakazNewWind(newBludo, registrationZakaza);
            createRegZakazNewWind.ShowDialog();
            dgZakazi.ItemsSource = db.RegistrationZakaza.ToList();

            //CreateRegZakWind createRegZakWind = new CreateRegZakWind();
            //createRegZakWind.ShowDialog();

            //var query = from item in db.RegistrationZakaza
            //            select item;
            //dgZakazi.ItemsSource = query.ToList();
            dgZakazi.ItemsSource = db.RegistrationZakaza.ToList();

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            
            var all = db.RegistrationZakaza.ToList().OrderBy(p => p.Id).ToList();
            var item =(RegistrationZakaza)dgZakazi.SelectedItem;
            var application = new Excel.Application();
            application.Visible = true;
            application.SheetsInNewWorkbook = 1;
                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                int start = 1;
                Excel.Worksheet worksheet = application.Worksheets.Item[1];
                worksheet.Name = "Регистрация заказа";
                worksheet.Cells[1][start] = "Код";
                worksheet.Cells[2][start] = "Код официанта";
                worksheet.Cells[3][start] = "Номер стола";
                worksheet.Cells[4][start] = "Номер блюда";
                worksheet.Cells[5][start] = "Итог";
                
                start++;
               
                    worksheet.Cells[1][start] = item.Id;
                    worksheet.Cells[2][start] = item.EmployeeId;
                    worksheet.Cells[3][start] = item.NumberTable;
                    worksheet.Cells[4][start] = item.ZakazBludaId;  
                    worksheet.Cells[5][start] = item.Total;


                
        }

        private void btnCloseZakaz_Click(object sender, RoutedEventArgs e)
        {
                if (dgZakazi.SelectedItem != null)
                {


                    RegistrationZakaza zakazItem = (RegistrationZakaza)dgZakazi.SelectedItem;
                    if ((bool)zakazItem.ZakazZakrit)
                        MessageBox.Show("Заказ уже закрыт");
                    else
                    {
                        if (MessageBox.Show("Вы точно хотите закрыть заказ?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            zakazItem.Table.IsBusy = false;
                            zakazItem.ZakazZakrit = true;
                            zakazItem.DateClose = DateTime.Now;
                            db.SaveChanges();
                            dgZakazi.ItemsSource = db.RegistrationZakaza.ToList();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Чтобы закрыть заказ,необходимо выбрать заказ,который хотите закрыть");
                }
            } 

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgZakazi.SelectedItem!=null)
            {
                if (((RegistrationZakaza)(dgZakazi.SelectedItem)).DateClose == null)
                {
                    if (MessageBox.Show("Вы точно хотите удалить заказ?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        db.RegistrationZakaza.Remove((RegistrationZakaza)dgZakazi.SelectedItem);
                        db.SaveChanges();
                        dgZakazi.ItemsSource = db.RegistrationZakaza.ToList();
                    }
                }
                else
                {
                 MessageBox.Show("Вы не можете удалить заказ,который закрыт");
                }
            }
            else
            {
                MessageBox.Show("Чтобы удалить заказ необходимо выбрать заказ");
            }
        }
    }
}
