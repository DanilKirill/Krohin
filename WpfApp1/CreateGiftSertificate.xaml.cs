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
    /// Логика взаимодействия для CreateGiftSertificate.xaml
    /// </summary>
    public partial class CreateGiftSertificate : Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
        public CreateGiftSertificate()
        {
            InitializeComponent();
        }

        private void btnCreateGiftSertificate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GiftSertificate giftSertificate = new GiftSertificate();
                giftSertificate.Date = DateTime.Now;
                string number = "AA-000";
                int GS = db.GiftSertificate.LastOrDefault().Id;
                giftSertificate.Number =number+ GS;
                giftSertificate.Nominal = int.Parse(txtNominal.Text);
                db.GiftSertificate.Add(giftSertificate);
                db.SaveChanges();
                Close();
            }
            catch 
            {
                
                
            }
          
        }
    }
}
