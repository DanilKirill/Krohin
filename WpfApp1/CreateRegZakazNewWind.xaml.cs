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
    /// Логика взаимодействия для CreateRegZakazNewWind.xaml
    /// </summary>
    public partial class CreateRegZakazNewWind : Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
        
        public CreateRegZakazNewWind()
        {
            InitializeComponent();
        }

        private void btnBuyGiftSertificate_Click(object sender, RoutedEventArgs e)
        {
            CreateGiftSertificate createGiftSertificate = new CreateGiftSertificate();
            createGiftSertificate.ShowDialog();
        }

        private void btnSaveZakaz_Click(object sender, RoutedEventArgs e)
        {

            
            RegistrationZakaza registrationZakaza = new RegistrationZakaza();
            registrationZakaza.DateOpen = DateTime.Now;
            registrationZakaza.Total = Convert.ToInt32(lblItog.Content);
            registrationZakaza.EmployeeId= ((Employees)cbEmployee.SelectedItem).id;
            registrationZakaza.Table = (Model.Table)cbTable.SelectedItem;
            registrationZakaza.ZakazZakrit = false;
            Model.Table itemTable = db.Table.Where(i => i.NumberTable == ((Model.Table)cbTable.SelectedItem).NumberTable).FirstOrDefault();
            itemTable.IsBusy = true;
            db.RegistrationZakaza.Add(registrationZakaza);
            db.SaveChanges();
            Close();
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
    }
}
