using System.Windows;
using BLL.Concrete;

namespace AdminSystem.Forms
{
    public partial class FormSummaryStatement : Window
    {
        public FormSummaryStatement()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxUsersSummaryStatement.ItemsSource = new UserRepository().GetFioUsers();
        }
    }
}
