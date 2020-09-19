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
    /// Логика взаимодействия для AddBludoZakaz.xaml
    /// </summary>
    public partial class AddBludoZakaz : Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
        int idNewZakaz=0;
        public AddBludoZakaz(int idNewZakaz)
        {
            InitializeComponent();
            this.idNewZakaz=idNewZakaz;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            int countKolvo = int.Parse(lblCount.Text);
            countKolvo++;
            lblCount.Text = countKolvo.ToString();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            int countKolvo = int.Parse(lblCount.Text);
            countKolvo--;
            lblCount.Text = countKolvo.ToString();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ZakaznBludaNew zakaznBludaNew = new ZakaznBludaNew();
            zakaznBludaNew.Count = int.Parse(lblCount.Text);
            zakaznBludaNew.IdBluda = ((Model.Menu)cbBluda.SelectedItem).Id;
            zakaznBludaNew.NameBluda = ((Model.Menu)cbBluda.SelectedItem).Name;
            zakaznBludaNew.Price = (float)((Model.Menu)cbBluda.SelectedItem).Price * zakaznBludaNew.Count;
            zakaznBludaNew.IdZakaza = idNewZakaz;
            db.ZakaznBludaNew.Add(zakaznBludaNew);
             db.SaveChanges();
            Close();
        }
    }
}
