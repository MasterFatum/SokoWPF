using System.Windows;
using System.Windows.Controls;

namespace UserSystem.FormsAddEducations
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
