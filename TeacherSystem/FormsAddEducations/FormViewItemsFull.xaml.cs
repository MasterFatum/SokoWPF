using System.Windows;

namespace UserSystem.FormsAddEducations
{
    /// <summary>
    /// Логика взаимодействия для FormViewItemsFull.xaml
    /// </summary>
    public partial class FormViewItemsFull : Window
    {
        public FormViewItemsFull(string user, string category, string title, string description, string date, int evaluation = 0)
        {
            InitializeComponent();

            TxbxUser.Text = user;
            TxbxCategory.Text = category;
            TxbxTitle.Text = title;
            TxbxDescription.Text = description;
            TxbxEvaluation.Text = evaluation.ToString();
            TxbxDate.Text = date;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
