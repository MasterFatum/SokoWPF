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
using TeacherSystem.Concrete;

namespace TeacherSystem.FormAddEducations
{
    public partial class FormEdit : Window
    {
        ContestsRepository contestsRepository = new ContestsRepository();

        public int Id { get; set; }
        public int UserIdEdit { get; set; }
        public string CategoryEdit { get; set; }
        public string TitleEdit { get; set; }
        public string DescriptionEdit { get; set; }


        public FormEdit(int id, int userIdEdit, string categoryEdit, string title, string description)
        {
            InitializeComponent();

            Id = id;
            UserIdEdit = userIdEdit;
            TxbxEditCategory.Text = categoryEdit;
            TxbxEditTitle.Text = title;
            TxbxEditDescription.Text = description;
        }

        private void BtnEditExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEditSave_Click(object sender, RoutedEventArgs e)
        {
            Contests contests = new Contests();
            contests.Id = Id;
            contests.UserId = UserIdEdit;
            contests.Category = CategoryEdit;
            contests.Title = TxbxEditTitle.Text.Trim();
            contests.Description = TxbxEditDescription.Text.Trim();

            contestsRepository.EditContests(contests);
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxbxEditTitle.Text = String.Empty;
            TxbxEditDescription.Text = String.Empty;
        }
    }
}
