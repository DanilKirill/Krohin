using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Bludo.xaml
    /// </summary>
    public partial class Bludo : Window
    {
        Vxod Login = new Vxod();
        string DateNow = "";
        string Info = "";
        k_kiri11Entities db = new k_kiri11Entities();
        public Bludo(Vxod Login, string DateNow)
        {
            InitializeComponent();
            this.Login = Login;
            this.DateNow = DateNow;
            Info = BludoWind.Title + "/ Пользователь: " + Login.Login + "/ Время: " + DateNow;
            BludoWind.Title = Info;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from item in db.Menu
                        select item;
            dgBluda.ItemsSource = query.ToList();
            Employees itemEmp = new Employees();
            foreach (var item in db.Employees)
            {
                if (item.VxodId == Login.Id)
                    itemEmp = item;
            }
            if (itemEmp.IdRole != 1 && itemEmp.IdRole != 2)
            {
                btnCreateBludo.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnEdit.IsEnabled = false;


            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee(Login, DateNow);
            emp.Show();
            Hide();
        }

        private void btnCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            CreateBludo createBludo = new CreateBludo();
            createBludo.ShowDialog();

            var query = from item in db.Menu
                        select item;
            dgBluda.ItemsSource = query.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgBluda.SelectedItem != null)
            {
                db.Menu.Remove((Model.Menu)dgBluda.SelectedItem);
                if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                    db.SaveChanges();
                var query = from item in db.Menu
                            select item;
                dgBluda.ItemsSource = query.ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dgBluda.IsReadOnly = false;
            btnCreateBludo.IsEnabled = false;
            btnSave.IsEnabled = true;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
        private void cbCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbCheck.IsChecked == true)
                {
                    Sections selectSection = (Sections)cbRazdelMenu.SelectedItem;

                    var query = from item in db.Menu
                                where item.Section == selectSection.Id
                                select item;
                    dgBluda.ItemsSource = query.ToList();
                }
                else
                {
                    var query = from item in db.Menu
                                select item;
                    dgBluda.ItemsSource = query.ToList();
                }
            }
            catch
            {

            }


        }

        private void cbRazdelMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCheck.IsChecked == true)
            {
                Sections selectSection = (Sections)cbRazdelMenu.SelectedItem;

                var query = from item in db.Menu
                            where item.Section == selectSection.Id
                            select item;
                dgBluda.ItemsSource = query.ToList();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgBluda.IsReadOnly = true;
            btnCreateBludo.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {

            Menu menu = new Menu(Login, DateNow);
            menu.Show();
            Hide();
        }

        private void dgBluda_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DopInformationBludWindow nextWindow = new DopInformationBludWindow((Model.Menu)dgBluda.SelectedItem);
            nextWindow.ShowDialog();
        }
    }
}
