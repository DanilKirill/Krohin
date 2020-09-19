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
        Vxod Login { get; set; }
        string Date = "";
        k_kiri11Entities db = new k_kiri11Entities();
        Model.Menu newBludo = new Model.Menu(); 
        ZakaznBludaNew zakaznBludaNew = new ZakaznBludaNew();
        Model.RegistrationZakaza registrationZakaza = new RegistrationZakaza();
        int idNewZakaz;

        public CreateRegZakazNewWind(Model.Menu newBludo,RegistrationZakaza registrationZakaza/*,Vxod Login,string Date*/)
        {
            InitializeComponent();
            newBludo = this.newBludo;
            this.registrationZakaza=registrationZakaza;
            idNewZakaz = registrationZakaza.Id;
            //this.Login = Login;
            //this.Date = Date;
        }

        private void btnBuyGiftSertificate_Click(object sender, RoutedEventArgs e)
        {
            CreateGiftSertificate createGiftSertificate = new CreateGiftSertificate();
            createGiftSertificate.ShowDialog();
        }

        private void btnSaveZakaz_Click(object sender, RoutedEventArgs e)
        {
            double itogSum = 0;
            bool proverka = true;
            registrationZakaza.DateOpen = DateTime.Now;
            foreach (var item in db.ZakaznBludaNew)
            {
                if (item.IdZakaza==idNewZakaz)
                {
                    itogSum += (double)item.Price;
                }
            }
            registrationZakaza.Total =(int)itogSum;
            if (cbEmployee.SelectedItem!=null)
            {
                registrationZakaza.EmployeeId = ((Employees)cbEmployee.SelectedItem).id;
            }
            else 
            {
                MessageBox.Show("Поле Сотрудник не заполнено");
                proverka = false;
            }
            if (cbTable.SelectedItem!=null)
            {
                registrationZakaza.NumberTable = ((Model.Table)cbTable.SelectedItem).Id;
                registrationZakaza.ZakazZakrit = false;
                Model.Table itemTable = db.Table.Where(i => i.NumberTable == ((Model.Table)cbTable.SelectedItem).NumberTable).FirstOrDefault();
                itemTable.IsBusy = true;
            }
            else
            {
                MessageBox.Show("Поле Стол не заполнено");
                proverka = false;
            }
            if (proverka!=false)
            {
                db.RegistrationZakaza.Add(registrationZakaza);
                db.SaveChanges();
                idNewZakaz = registrationZakaza.Id;
                Close();
            }
            
           
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddBludoZakaz addBludo = new AddBludoZakaz(idNewZakaz);
            addBludo.ShowDialog();
            dgAddBludo.ItemsSource = db.ZakaznBludaNew.Where(i=>i.IdZakaza==idNewZakaz).ToList();
            double itogSum = 0;
            foreach (var item in db.ZakaznBludaNew)
            {
                if (item.IdZakaza == idNewZakaz)
                {
                    itogSum += (double)item.Price;
                }
            }
            lblItog.Content = itogSum;

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgAddBludo.SelectedItem != null)
            {
                ZakaznBludaNew delBludo = (ZakaznBludaNew)dgAddBludo.SelectedItem;
                if (MessageBox.Show("Вы точно хотите удалить блюдо из заказа?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    db.ZakaznBludaNew.Remove(delBludo);
                    db.SaveChanges();
                    dgAddBludo.ItemsSource = db.ZakaznBludaNew.Where(i => i.IdZakaza == idNewZakaz).ToList();

                }
            }
            else
                MessageBox.Show("Чтобы удалить надо выбрать что удалять");

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RegistrationZakaza registrationZakaza = db.RegistrationZakaza.Where(i => i.Id == idNewZakaz).FirstOrDefault();
            db.RegistrationZakaza.Remove(registrationZakaza);
            db.SaveChanges();
      
        }

        private void cbCheckGiftSert_Click(object sender, RoutedEventArgs e)
        {
            double itog = 0;
            
                foreach (var item in db.ZakaznBludaNew)
                {
                    if (item.IdZakaza == idNewZakaz)
                        itog += (double)item.Price;
                }
                //itog=itog-(itog*()) Доделать использование скидочных карт и подарочных сертификатов как однвременно так и по отдельности и при выборе товара
                //itog = itog - (itog - (double)((GiftSertificate)cbGiftSertificate.SelectedItem).Nominal);

                lblItog.Content = itog;
                if (cbCheckSaleCart.IsChecked == true && cbSaleCart.SelectedItem != null)
                {
                    SaleCarts saleCart = (SaleCarts)cbSaleCart.SelectedItem;
                    double nominal = int.Parse(saleCart.Nominal);
                    itog = itog - (itog * (nominal / 100));
                    lblItog.Content = itog.ToString();
                }

                if (cbChekGiftSertificate.IsChecked == true && cbGiftSertificate.SelectedItem != null)
                {
                    GiftSertificate giftSertificate = (GiftSertificate)cbGiftSertificate.SelectedItem;
                    int nominal = (int)giftSertificate.Nominal;
                    itog = itog - nominal;
                    lblItog.Content = itog.ToString();
                }
            }

        

        private void cbCheckSaleCart_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
 