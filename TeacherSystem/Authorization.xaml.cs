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

namespace TeacherSystem
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnAuthorizeExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CbxAuthorizeAs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbxAuthorizeAs.Text == "Администратор")
            {
                BtnRegistration.IsEnabled = true;
            }
            else if (CbxAuthorizeAs.Text == "Учитель")
            {
                BtnRegistration.IsEnabled = false;
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            new Message("Тут будет сообщение").ShowDialog();
        }
    }
}
