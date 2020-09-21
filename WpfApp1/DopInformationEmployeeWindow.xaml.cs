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
    /// Логика взаимодействия для DopInformationEmployeeWindow.xaml
    /// </summary>
    public partial class DopInformationEmployeeWindow : Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
        public DopInformationEmployeeWindow(Model.Employees itemEmployee)
        {
            InitializeComponent();
            txtName.Text = itemEmployee.Name;
            txtSurname.Text = itemEmployee.Surname;
            txtPatronymic.Text = itemEmployee.Patronymic;
            txtPhone.Text = itemEmployee.Phone;
            txtRestaurant.Text = itemEmployee.Restaurants.Name;
            txtBirthday.Text = itemEmployee.BirthdayDate.ToString();
            cbRole.ItemsSource = db.Roles.ToList();
            if (itemEmployee.Roles.id!=0)
            cbRole.SelectedIndex = itemEmployee.Roles.id-1;
        }
    }
}