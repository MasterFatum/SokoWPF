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

namespace TeacherSystem.FormAddEducations
{
    /// <summary>
    /// Логика взаимодействия для FormChooseEducation.xaml
    /// </summary>
    public partial class FormChooseCategory : Window
    {

        public int UserId { get; set; }

        public FormChooseCategory(int userId)
        {
            InitializeComponent();

            UserId = userId;
        }
        
        private void BtnChooseEducation_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnMainAdd_Click(object sender, RoutedEventArgs e)
        {
            new FormAdd(UserId, ((ComboBoxItem)CbxSelectCategory.SelectedItem).Content.ToString()).ShowDialog();
        }
    }
}
