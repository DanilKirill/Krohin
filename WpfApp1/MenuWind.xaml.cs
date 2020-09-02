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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Vxod Login = new Vxod(); 
        string Info = "";
        string DateNow = "";
        public Menu(Vxod Login,string DateNow)
        {
            InitializeComponent();
            this.Login = Login;
            this.DateNow = DateNow;
            Info = MenuWind.Title + "/ Пользователь: " + Login.Login+ "/ Время: "+DateNow;
            MenuWind.Title = Info;
            
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee windEmployee = new Employee(Login,DateNow);
            windEmployee.Show();
            Hide();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnBludo_Click(object sender, RoutedEventArgs e)
        {
            Bludo bludo = new Bludo(Login,DateNow);
            bludo.Show();
            Hide();
        }

        private void btnGiftSertificate_Click(object sender, RoutedEventArgs e)
        {
            GiftSertificateWind giftSertificateWind = new GiftSertificateWind(Login,DateNow);
            giftSertificateWind.Show();
            Hide();
        }

        private void btnSaleCart_Click(object sender, RoutedEventArgs e)
        {
            SaleCartWind saleCartWind = new SaleCartWind(Login,DateNow);
            saleCartWind.Show();
            Hide();

        }

        private void btnRegZakaz_Click(object sender, RoutedEventArgs e)
        {
            RegZakWind regZakWind = new RegZakWind(Login,DateNow);
            regZakWind.Show();
            Hide();
        }

        
    }
}
