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
    /// Логика взаимодействия для SelectOptionsZakazWind.xaml
    /// </summary>
    public partial class SelectOptionsZakazWind : Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
        Employees employee =new Employees();
        Model.Table table = new Model.Table();
        public SelectOptionsZakazWind()
        {
            InitializeComponent();
        }
        private void cbNumberTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Table itemTable = (Model.Table)cbTable.SelectedItem;
            if (itemTable != null)
            {
                if (itemTable.IsBusy)
                {
                    cbTable.SelectedItem = null;
                    MessageBox.Show("Стол занят");
                }
            }
        }

        private void btnCreateZakaz_Click(object sender, RoutedEventArgs e)
        {
            employee= (Employees)cbEmployee.SelectedItem;
            table= (Model.Table)cbTable.SelectedItem;
            CreateRegZakazNewWind createRegZakazNewWind = new CreateRegZakazNewWind();
            createRegZakazNewWind.Show();
            Close();
        }
    }
}
