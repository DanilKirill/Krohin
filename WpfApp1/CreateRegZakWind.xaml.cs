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
    /// Логика взаимодействия для CreateRegZakWind.xaml
    /// </summary>
    public partial class CreateRegZakWind : Window
    {
        /*
        k_kiri11Entities db = new k_kiri11Entities();
        public CreateRegZakWind()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            RegistrationZakaza registrationZakaza = new RegistrationZakaza();
            ZakaznBluda zakaznBluda = new ZakaznBluda();
            if (cbBludo1.SelectedItem != null)
            {
                zakaznBluda.FirstBludo = ((Model.Menu)cbBludo1.SelectedItem).Id;
            }
            if (cbBludo2.SelectedItem != null)
            {
                zakaznBluda.SecondBludo = ((Model.Menu)cbBludo2.SelectedItem).Id;
            }
            if (cbBludo3.SelectedItem != null)
            {
                zakaznBluda.ThirtdBludo = ((Model.Menu)cbBludo3.SelectedItem).Id;
            }
            if (cbBludo4.SelectedItem != null)
            {
                zakaznBluda.FourthBludo = ((Model.Menu)cbBludo4.SelectedItem).Id;
            }
            if (cbBludo5.SelectedItem != null)
            {
                zakaznBluda.FifthBludo = ((Model.Menu)cbBludo5.SelectedItem).Id;
            }

            //if (zakaznBluda != null)
            //{
            //    zakaznBluda.Total =int.Parse(lblItog.Content.ToString());
            //    db.ZakaznBluda.Add(zakaznBluda);
            //    db.SaveChanges();
            //}
            bool proverka = true;

            if (cbEmployee.SelectedItem != null)
            {
                registrationZakaza.EmployeeId = ((Employees)cbEmployee.SelectedItem).id;
            }
            else
            {
                proverka = false;
                MessageBox.Show("Поле Сотрудник не заполнено");
            }

            if (cbNumberTable != null)
            {
                registrationZakaza.NumberTable = ((Model.Table)cbNumberTable.SelectedItem).Id;
            }
            else
            {
                proverka = false;
                MessageBox.Show("Поле Номер стола не заполнено");
            }
            if (proverka)
            {
                zakaznBluda.Total = int.Parse(lblItog.Content.ToString());
                    db.ZakaznBluda.Add(zakaznBluda);
                    db.SaveChanges();
                registrationZakaza.DateOpen = DateTime.Now;
                registrationZakaza.ZakazBludaId = zakaznBluda.Id;
                registrationZakaza.Total = zakaznBluda.Total;
            //    if (cbCheckSaleCart.IsChecked == true && cbSaleCart.SelectedItem != null)
               // {
              //      GiftSertificate itemGS = (GiftSertificate)cbGiftSertificate.SelectedItem;
              //      itemGS.Status ="Used";
            //    }
                registrationZakaza.ZakazZakrit = false;
                Model.Table itemTable =db.Table.Where(i => i.NumberTable == ((Model.Table)cbNumberTable.SelectedItem).NumberTable).FirstOrDefault();
                itemTable.IsBusy = true;
                db.RegistrationZakaza.Add(registrationZakaza);
                db.SaveChanges();
                Close();
            }
        }

        private void cbBludo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double itog =0;
            Model.Menu bludo1 = (Model.Menu)cbBludo1.SelectedItem;
            if (bludo1!=null)
            {
                itog += Convert.ToInt32(bludo1.Price);
            }
            Model.Menu bludo2 = (Model.Menu)cbBludo2.SelectedItem;
            if (bludo2 != null)
            {
                itog += Convert.ToInt32(bludo2.Price);
            }
            Model.Menu bludo3 = (Model.Menu)cbBludo3.SelectedItem;
            if (bludo3 != null)
            {
                itog += Convert.ToInt32(bludo3.Price);
            }
            Model.Menu bludo4 = (Model.Menu)cbBludo4.SelectedItem;
            if (bludo4 != null)
            {
                itog += Convert.ToInt32(bludo4.Price);
            }
            Model.Menu bludo5 = (Model.Menu)cbBludo5.SelectedItem;
            if (bludo5 != null)
            {
                itog += Convert.ToInt32(bludo5.Price);
            }
            lblItog.Content= itog;
            if (cbCheckSaleCart.IsChecked == true && cbSaleCart.SelectedItem != null)
            {
                SaleCarts saleCart = (SaleCarts)cbSaleCart.SelectedItem;
                double nominal = int.Parse(saleCart.Nominal);
                itog = itog- (itog* (nominal/100));
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

        private void cbBludo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double itog = 0;
            Model.Menu bludo1 = (Model.Menu)cbBludo1.SelectedItem;
            if (bludo1 != null)
            {
                itog += Convert.ToInt32(bludo1.Price);
            }
            Model.Menu bludo2 = (Model.Menu)cbBludo2.SelectedItem;
            if (bludo2 != null)
            {
                itog += Convert.ToInt32(bludo2.Price);
            }
            Model.Menu bludo3 = (Model.Menu)cbBludo3.SelectedItem;
            if (bludo3 != null)
            {
                itog += Convert.ToInt32(bludo3.Price);
            }
            Model.Menu bludo4 = (Model.Menu)cbBludo4.SelectedItem;
            if (bludo4 != null)
            {
                itog += Convert.ToInt32(bludo4.Price);
            }
            Model.Menu bludo5 = (Model.Menu)cbBludo5.SelectedItem;
            if (bludo5 != null)
            {
                itog += Convert.ToInt32(bludo5.Price);
            }
            
            lblItog.Content = itog;
            if (cbCheckSaleCart.IsChecked == true && cbGiftSertificate.SelectedItem != null)
            {
             
                SaleCarts saleCart = (SaleCarts)cbSaleCart.SelectedItem;
                double nominal = double.Parse(saleCart.Nominal);
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

        private void cbBludo3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double itog = 0;
            Model.Menu bludo1 = (Model.Menu)cbBludo1.SelectedItem;
            if (bludo1 != null)
            {
                itog += Convert.ToInt32(bludo1.Price);
            }
            Model.Menu bludo2 = (Model.Menu)cbBludo2.SelectedItem;
            if (bludo2 != null)
            {
                itog += Convert.ToInt32(bludo2.Price);
            }
            Model.Menu bludo3 = (Model.Menu)cbBludo3.SelectedItem;
            if (bludo3 != null)
            {
                itog += Convert.ToInt32(bludo3.Price);
            }
            Model.Menu bludo4 = (Model.Menu)cbBludo4.SelectedItem;
            if (bludo4 != null)
            {
                itog += Convert.ToInt32(bludo4.Price);
            }
            Model.Menu bludo5 = (Model.Menu)cbBludo5.SelectedItem;
            if (bludo5 != null)
            {
                itog += Convert.ToInt32(bludo5.Price);
            }

            lblItog.Content = itog;
            if (cbCheckSaleCart.IsChecked == true && cbSaleCart.SelectedItem!=null)
            {
                
                SaleCarts saleCart = (SaleCarts)cbSaleCart.SelectedItem;
                double nominal = double.Parse(saleCart.Nominal);
                itog = itog - (itog * (nominal / 100));
                if (itog < 0)
                    itog = 0;
                lblItog.Content = itog.ToString();
            }

             if (cbChekGiftSertificate.IsChecked == true && cbGiftSertificate != null)
                {
                
                GiftSertificate giftSertificate = (GiftSertificate)cbGiftSertificate.SelectedItem;
                int nominal = (int)giftSertificate.Nominal;
                itog = itog - nominal;
                if (itog < 0)
                    itog = 0;
                lblItog.Content = itog.ToString();
            }
        }

        private void cbBludo4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double itog = 0;
            Model.Menu bludo1 = (Model.Menu)cbBludo1.SelectedItem;
            if (bludo1 != null)
            {
                itog += Convert.ToInt32(bludo1.Price);
            }
            Model.Menu bludo2 = (Model.Menu)cbBludo2.SelectedItem;
            if (bludo2 != null)
            {
                itog += Convert.ToInt32(bludo2.Price);
            }
            Model.Menu bludo3 = (Model.Menu)cbBludo3.SelectedItem;
            if (bludo3 != null)
            {
                itog += Convert.ToInt32(bludo3.Price);
            }
            Model.Menu bludo4 = (Model.Menu)cbBludo4.SelectedItem;
            if (bludo4 != null)
            {
                itog += Convert.ToInt32(bludo4.Price);
            }
            Model.Menu bludo5 = (Model.Menu)cbBludo5.SelectedItem;
            if (bludo5 != null)
            {
                itog += Convert.ToInt32(bludo5.Price);
            }

            lblItog.Content = itog;
            if (cbCheckSaleCart.IsChecked == true && cbSaleCart.SelectedItem!=null)
            {
               
                SaleCarts saleCart = (SaleCarts)cbSaleCart.SelectedItem;
                double nominal = double.Parse(saleCart.Nominal);
                itog = itog - (itog * (nominal / 100));
                if (itog < 0)
                    itog = 0;
                lblItog.Content = itog.ToString();
            }

            if (cbChekGiftSertificate.IsChecked == true && cbGiftSertificate != null)
                {
                GiftSertificate giftSertificate = (GiftSertificate)cbGiftSertificate.SelectedItem;
                int nominal = (int)giftSertificate.Nominal;
                itog = itog - nominal;
                if (itog < 0)
                    itog = 0;
                lblItog.Content = itog.ToString();
            }
        }

        private void cbBludo5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double itog = 0;
            Model.Menu bludo1 = (Model.Menu)cbBludo1.SelectedItem;
            if (bludo1 != null)
            {
                itog += Convert.ToInt32(bludo1.Price);
            }
            Model.Menu bludo2 = (Model.Menu)cbBludo2.SelectedItem;
            if (bludo2 != null)
            {
                itog += Convert.ToInt32(bludo2.Price);
            }
            Model.Menu bludo3 = (Model.Menu)cbBludo3.SelectedItem;
            if (bludo3 != null)
            {
                itog += Convert.ToInt32(bludo3.Price);
            }
            Model.Menu bludo4 = (Model.Menu)cbBludo4.SelectedItem;
            if (bludo4 != null)
            {
                itog += Convert.ToInt32(bludo4.Price);
            }
            Model.Menu bludo5 = (Model.Menu)cbBludo5.SelectedItem;
            if (bludo5 != null)
            {
                itog += Convert.ToInt32(bludo5.Price);
            }

            lblItog.Content = itog;
            if (cbCheckSaleCart.IsChecked == true)
            {
                cbCheckSaleCart_Click(sender,e);
              
                SaleCarts saleCart = (SaleCarts)cbSaleCart.SelectedItem;
                double nominal = double.Parse(saleCart.Nominal);
                itog = itog - (itog * (nominal / 100));
                if (itog < 0)
                    itog = 0;
                lblItog.Content = itog.ToString();
            }

            if (cbGiftSertificate != null)
                {
                cbChekGiftSertificate_Click (sender, e);
                //int Itog = int.Parse(lblItog.Content.ToString());
                //GiftSertificate giftSertificate = (GiftSertificate)cbGiftSertificate.SelectedItem;
                //int nominal = (int)giftSertificate.Nominal;
                //Itog = Itog - nominal;
                //lblItog.Content = Itog.ToString();
            }
        }

        private void cbCheckSaleCart_Click(object sender, RoutedEventArgs e)
        {
            if (cbCheckSaleCart.IsChecked == true && cbSaleCart.SelectedItem != null)
            {
                double itog = 0;
                Model.Menu bludo1 = (Model.Menu)cbBludo1.SelectedItem;
                if (bludo1 != null)
                {
                    itog += Convert.ToInt32(bludo1.Price);
                }
                Model.Menu bludo2 = (Model.Menu)cbBludo2.SelectedItem;
                if (bludo2 != null)
                {
                    itog += Convert.ToInt32(bludo2.Price);
                }
                Model.Menu bludo3 = (Model.Menu)cbBludo3.SelectedItem;
                if (bludo3 != null)
                {
                    itog += Convert.ToInt32(bludo3.Price);
                }
                Model.Menu bludo4 = (Model.Menu)cbBludo4.SelectedItem;
                if (bludo4 != null)
                {
                    itog += Convert.ToInt32(bludo4.Price);
                }
                Model.Menu bludo5 = (Model.Menu)cbBludo5.SelectedItem;
                if (bludo5 != null)
                {
                    itog += Convert.ToInt32(bludo5.Price);
                }
                SaleCarts saleCart = (SaleCarts)cbSaleCart.SelectedItem;
                double nominal = Convert.ToDouble(saleCart.Nominal);
                itog = itog - (itog * (nominal / 100));
                if (itog < 0)
                    itog = 0;
                lblItog.Content = itog;
            }
            else if (cbCheckSaleCart.IsChecked == false && cbSaleCart.SelectedItem!=null)
            {
                double itog = 0;
                Model.Menu bludo1 = (Model.Menu)cbBludo1.SelectedItem;
                if (bludo1 != null)
                {
                    itog += Convert.ToInt32(bludo1.Price);
                }
                Model.Menu bludo2 = (Model.Menu)cbBludo2.SelectedItem;
                if (bludo2 != null)
                {
                    itog += Convert.ToInt32(bludo2.Price);
                }
                Model.Menu bludo3 = (Model.Menu)cbBludo3.SelectedItem;
                if (bludo3 != null)
                {
                    itog += Convert.ToInt32(bludo3.Price);
                }
                Model.Menu bludo4 = (Model.Menu)cbBludo4.SelectedItem;
                if (bludo4 != null)
                {
                    itog += Convert.ToInt32(bludo4.Price);
                }
                Model.Menu bludo5 = (Model.Menu)cbBludo5.SelectedItem;
                if (bludo5 != null)
                {
                    itog += Convert.ToInt32(bludo5.Price);
                }
                SaleCarts saleCart = (SaleCarts)cbSaleCart.SelectedItem;
                double nominal = Convert.ToDouble(saleCart.Nominal);
                lblItog.Content = itog;
            }
            
        }

        private void cbChekGiftSertificate_Click(object sender, RoutedEventArgs e)
        {
            double itog = 0;
            Model.Menu bludo1 = (Model.Menu)cbBludo1.SelectedItem;
            if (bludo1 != null)
            {
                itog += Convert.ToInt32(bludo1.Price);
            }
            Model.Menu bludo2 = (Model.Menu)cbBludo2.SelectedItem;
            if (bludo2 != null)
            {
                itog += Convert.ToInt32(bludo2.Price);
            }
            Model.Menu bludo3 = (Model.Menu)cbBludo3.SelectedItem;
            if (bludo3 != null)
            {
                itog += Convert.ToInt32(bludo3.Price);
            }
            Model.Menu bludo4 = (Model.Menu)cbBludo4.SelectedItem;
            if (bludo4 != null)
            {
                itog += Convert.ToInt32(bludo4.Price);
            }
            Model.Menu bludo5 = (Model.Menu)cbBludo5.SelectedItem;
            if (bludo5 != null)
            {
                itog += Convert.ToInt32(bludo5.Price);
            }

            lblItog.Content = itog;
            if (cbChekGiftSertificate.IsChecked == true && cbGiftSertificate.SelectedItem != null)
            {

               
                GiftSertificate giftSertificate = (GiftSertificate)cbGiftSertificate.SelectedItem;
                int nominal = Convert.ToInt32(giftSertificate.Nominal);
                itog = itog - nominal;
                if (itog < 0)
                    itog = 0;
                lblItog.Content = itog.ToString();

            }
            else if (cbChekGiftSertificate.IsChecked == false)
            {
                
                GiftSertificate giftSertificate = (GiftSertificate)cbGiftSertificate.SelectedItem;
                int nominal = Convert.ToInt32(giftSertificate.Nominal);
                lblItog.Content = itog.ToString();
            }

       
        }

        private void cbNumberTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Table itemTable =(Model.Table)cbNumberTable.SelectedItem;
            if (itemTable != null)
            {
                if (itemTable.IsBusy)
                {
                    cbNumberTable.SelectedItem = null;
                    MessageBox.Show("Стол занят");
                }
            }
        }

        private void btnCreateGS_Click(object sender, RoutedEventArgs e)
        {
            CreateGiftSertificate createGiftSertificate = new CreateGiftSertificate();
            createGiftSertificate.ShowDialog();
            cbGiftSertificate.ItemsSource = db.GiftSertificate.ToList();
            int countGS = cbGiftSertificate.Items.Count;
            cbGiftSertificate.SelectedItem=cbGiftSertificate.Items[countGS-1];
            cbChekGiftSertificate.IsChecked = true;
            cbChekGiftSertificate_Click(sender,e);
        }
        */
    }
}
