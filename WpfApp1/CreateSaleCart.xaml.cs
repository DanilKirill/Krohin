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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CreateSaleCart.xaml
    /// </summary>
    public partial class CreateSaleCart : Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
        public CreateSaleCart()
        {
            InitializeComponent();
        }

        private void btnCreateSaleCart_Click(object sender, RoutedEventArgs e)
        {
            bool proverka = true;
            SaleCarts saleCarts = new SaleCarts();
            saleCarts.Name = txtName.Text;
            saleCarts.Surname = txtSurname.Text;
            saleCarts.Patronymic = txtPatronymic.Text;
            saleCarts.Nominal = txtNominal.Text;
            if (cbEmployee.SelectedItem != null)
            {
                Employees emp = (Employees)cbEmployee.SelectedItem;
                saleCarts.EmployeeId = emp.id.ToString();
            }
            else
            {
                proverka = false;
                MessageBox.Show("Поле сотрудник не заполнено");
            }

            if (proverka)
            {
                db.SaleCarts.Add(saleCarts);
                db.SaveChanges();
                Close();
            }
        }
    }
}
