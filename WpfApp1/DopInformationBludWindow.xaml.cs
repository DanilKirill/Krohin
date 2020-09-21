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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для DopInformationBludWindow.xaml
    /// </summary>
    public partial class DopInformationBludWindow : Window
    {
        public DopInformationBludWindow(Model.Menu itemBludo)
        {
            InitializeComponent();
            txtName.Content = itemBludo.Name;
            txtCalories.Text = itemBludo.Calories.ToString();
            txtPrice.Text = itemBludo.Price.ToString() ;
            txtStructure.Text = itemBludo.Structure;
            txtWeigth.Text = itemBludo.Weight.ToString();
            if (itemBludo.Sections.Id != 0)
                cbSection.SelectedIndex = itemBludo.Sections.Id - 1;
        }
    }
}
