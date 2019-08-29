using System;
using System.Diagnostics;
using System.Net.Mime;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace UserSystem.FormsAddEducations
{
    
    public partial class FormViewItemsFull : Window
    {
        public string MyUrlHyperlink { get; set; }

        public FormViewItemsFull(string user, string category, string title, string description, string date, string hyperlink, int evaluation = 0)
        {
            InitializeComponent();

            TxbxUser.Text = user;
            TxbxCategory.Text = category;
            TxbxTitle.Text = title;
            TxbxDescription.Text = description;
            TxbxEvaluation.Text = evaluation.ToString();
            TxbxDate.Text = date;
            MyUrlHyperlink = hyperlink;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(MyUrlHyperlink));
            e.Handled = true;
            
        }
    }
}
