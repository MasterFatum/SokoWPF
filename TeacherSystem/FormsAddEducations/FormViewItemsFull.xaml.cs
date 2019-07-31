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

namespace TeacherSystem.FormsAddEducations
{
    /// <summary>
    /// Логика взаимодействия для FormViewItemsFull.xaml
    /// </summary>
    public partial class FormViewItemsFull : Window
    {
        public FormViewItemsFull(string user, string category, string title, string description, int evaluation = 0)
        {
            InitializeComponent();

            TxbxUser.Text = user;
            TxbxCategory.Text = category;
            TxbxTitle.Text = title;
            TxbxDescription.Text = description;
            TxbxEvaluation.Text = evaluation.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
