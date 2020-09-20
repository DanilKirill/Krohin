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
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        string DateNow = "";
        Vxod Login = new Vxod();
        List<Employees> listEmp = new List<Employees>();
        k_kiri11Entities db = new k_kiri11Entities();
        public Employee(Vxod Login,string DateNow)
        {
            
            InitializeComponent();
            this.Login = Login;
            this.DateNow = DateNow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from item in db.Employees
                        select item;
            dgEmployee.ItemsSource = query.ToList();
            btnSave.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployee createEmployee = new CreateEmployee();
            createEmployee.ShowDialog();
            var query = from item in db.Employees
                        select item;
            dgEmployee.ItemsSource = query.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployee.SelectedItem != null)
            {
                Employees emp = (Employees)dgEmployee.SelectedItem;

                if (MessageBox.Show("Вы точно хотите удалить?", "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {

                    db.Employees.Remove(emp);
                    db.SaveChanges();
                }

                var query = from item in db.Employees
                            select item;
                dgEmployee.ItemsSource = query.ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dgEmployee.IsReadOnly = false;
            btnCreateEmployee.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnSave.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgEmployee.IsReadOnly = true;
            btnCreateEmployee.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnSave.IsEnabled=false;
        }

        private void btnBludo_Click(object sender, RoutedEventArgs e)
        {
            Bludo winBludo = new Bludo(Login,DateNow);
            winBludo.Show();
            Hide();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            var all = db.Employees.OrderBy(p => p.id).ToList();
            var application = new Excel.Application();
            application.Visible = true;
            application.SheetsInNewWorkbook = 1;
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            int start = 1;
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            worksheet.Name = "Сотрудники";
            worksheet.Cells[1][start] = "Фамилия";
            worksheet.Cells[2][start] = "Сумма заказов";
            worksheet.Cells[3][start] = "Премия";



            start++;
            for (int i = 0; i < all.Count; i++)
            {
                worksheet.Cells[1][start] = all[i].Surname;
                worksheet.Cells[2][start] = all[i].SumZakazov;
                if (all[i].Premia != null)
                {
                    worksheet.Cells[3][start] = all[i].Premia;
                }
                else
                    worksheet.Cells[3][start] = 0;

                start++;
            }
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(Login,DateNow);
            menu.Show();
            Hide();
        }

        private void dgEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DopInformationEmployeeWindow nextWindow = new DopInformationEmployeeWindow((Employees)dgEmployee.SelectedItem);
            nextWindow.ShowDialog();
        }
    }
}
