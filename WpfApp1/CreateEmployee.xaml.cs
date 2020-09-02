using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CreateEmployee.xaml
    /// </summary>
    public partial class CreateEmployee : Window
    {
        k_kiri11Entities db = new k_kiri11Entities();
        public CreateEmployee()
        {
            InitializeComponent();
        }

        private void btnCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                bool proverka = true;
                Employees emp = new Employees();

                if (txtSurname.Text != "")
                    emp.Surname = txtSurname.Text;
                else
                {
                    MessageBox.Show("Поле Фамилия не заполнено");
                    proverka = false;
                }

                if (txtName.Text != "")
                    emp.Name = txtName.Text;
                else
                {
                    MessageBox.Show("Поле Имя не заполнено");
                    proverka = false;
                }

                if (txtPatronymic.Text != "")
                    emp.Patronymic = txtPatronymic.Text;
                else
                {
                    MessageBox.Show("Поле Отчество не заполнено");
                    proverka = false;
                } 

                
                if (!(txtPhone.Text.Contains('+')&&txtPhone.Text.Contains('(')&& txtPhone.Text.Contains(')')))
                {
                    MessageBox.Show("Неправльно введен номер телефона\nПример +7(921)1256599");
                    proverka = false;
                }
                else
                    emp.Phone = txtPhone.Text;
                DateTime date = DateTime.Parse(dpBirthday.Text);
                if (DateTime.Today != date)
                    emp.BirthdayDate = date;
                else
                {
                    MessageBox.Show("Неправильно введена дата рождения");
                    proverka = false;
                }

            if (cbRole.SelectedItem != null)
            {
              Roles role=(Roles)cbRole.SelectedItem;
                emp.IdRole = role.id;
            }
            else
            {
               MessageBox.Show("Поле Должность не выборано");
                proverka = false;

            }

            if (cbWorkPlace.SelectedItem != null)
            {
                Restaurants restaurants = (Restaurants)cbWorkPlace.SelectedItem;
                emp.Restaurant = restaurants.id;
            }
            else
            {
                MessageBox.Show("Поле Место работы не выбрано");
                proverka = false;
            }

                if(proverka==true)
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                Close();
                }

            //}
            //catch
            //{
                //MessageBox.Show("Что то пошло не так","Упс");
           // }
        }
    }
}
