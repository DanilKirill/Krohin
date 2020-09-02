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
    /// Логика взаимодействия для CreateBludo.xaml
    /// </summary>
    public partial class CreateBludo : Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
        public CreateBludo()
        {
            InitializeComponent();
        }

        private void btnCreateBludo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            Model.Menu menu = new Model.Menu();
            bool proverka = true;

            if (txtName.Text != "")
            {
                menu.Name = txtName.Text;
            }
            else
            {
                proverka = false;
                MessageBox.Show("Поле Название не заполнено");
            }

            if (int.TryParse(txtWeight.Text,out int result))
            {
                menu.Weight = result ;
            }
            else
            {
                proverka = false;
                MessageBox.Show("Поле Вес не заполнено");
            }

            if (txtStructure.Text != "")
            {
                menu.Name = txtStructure.Text;
            }
            else
            {
                proverka = false;
                MessageBox.Show("Поле Состав не заполнено");
            }


            if (int.TryParse(txtCalories.Text, out  result))
            {
                menu.Calories = result;
            }
            else
            {
                proverka = false;
                MessageBox.Show("Поле Калории не заполнено");
            }


            if (int.TryParse(txtPrice.Text, out result))
            {
                menu.Price = result;
            }
            else
            {
                proverka = false;
                MessageBox.Show("Поле Цена не заполнено");
            }

            if (cbRazdelMenu.Text != null)
            {
                Sections sections =(Sections)cbRazdelMenu.SelectedItem;

                menu.Section= sections.Id;
            }
            if (proverka == true)
            {
                db.Menu.Add(menu);
                db.SaveChanges();
                    Close();
            }
            }
            catch
            {

                MessageBox.Show("Что то пошло не так", "Упс");
            }
        }
    }
}
