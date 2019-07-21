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
    /// Логика взаимодействия для FormAdd.xaml
    /// </summary>
    public partial class FormAdd : Window
    {
        public string SelectedEducation { get; set; }

        public FormAdd(string selectedEducation)
        {
            InitializeComponent();

            SelectedEducation = selectedEducation;
            TxbxSelectedEducation.Text = SelectedEducation;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxbxTitle.Text = String.Empty;
            TxbxDescription.Text = String.Empty;
        }
    }
}
