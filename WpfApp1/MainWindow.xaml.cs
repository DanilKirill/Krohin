using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
       public System.Windows.Threading.DispatcherTimer timer  = new System.Windows.Threading.DispatcherTimer();
       public System.Windows.Threading.DispatcherTimer timer1 = new System.Windows.Threading.DispatcherTimer();
       public System.Windows.Threading.DispatcherTimer timer2 = new System.Windows.Threading.DispatcherTimer();


        public async void Block(Vxod item)
        {
                TimeSpan timeSpan = new TimeSpan(0, 0, 30);
                if (item.CoutWrong >= 5 && item.Id == 1)
                {
                    timer.Interval = timeSpan;
                    timer.Start();

                   await Task.Run(()=>timer.Tick += (o, e) => { MessageBox.Show($"{item.Login} разблокирован"); timer.Stop();item.CoutWrong = 1;});
                }
                if (item.CoutWrong >= 5 && item.Id == 2)
                {
                    timer1.Interval = timeSpan;
                    timer.Start();
                   await Task.Run(() => timer1.Tick += (o, e) => { MessageBox.Show($"{item.Login} разблокирован"); timer1.Stop(); item.CoutWrong = 1; });
            }             
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            bool enter = false;
            foreach (var item in db.Vxod)
            {
                if (((Vxod)cbLogin.SelectedItem).Login == item.Login && pbPassword.Password == item.Password)
                {
                    Menu menu = new Menu(item,DateTime.Now.ToString());
                    menu.Show();
                    Hide();
                    enter = true;
                }
            }
           if(!enter)
            {
                var item =(Vxod)cbLogin.SelectedItem;
                if (item.CoutWrong < 5)
                {
                    MessageBox.Show($"Неправильно введены логин или пароль Попытка {item.CoutWrong}/5", "Ошибка", MessageBoxButton.OK);
                    pbPassword.Password = "";
                }
                
                if (item.CoutWrong== 5)
                {
                    MessageBox.Show($"Этот логин Заблокирован ");
                    pbPassword.Password = "";
                    Block(item);
                }
                if (item.CoutWrong > 5)
                {
                    MessageBox.Show("Дождитесь пока пройдет блокировка");
                    pbPassword.Password = "";
                }
                item.CoutWrong++;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, 1);
            timer2.Interval = timeSpan;
            timer2.Start();
            timer2.Tick += (o, e1) => { tbTime.Text = DateTime.Now.ToString();};
            
        }

      
    }
}
