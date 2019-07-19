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

namespace TeacherSystem
{
    /// <summary>
    /// Логика взаимодействия для Registrations.xaml
    /// </summary>
    public partial class Registrations : Window
    {
        public Registrations()
        {
            InitializeComponent();
        }
        
        UserRepository userRepository = new UserRepository();

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PwdBox.Password.Equals(PwdBoxReplase.Password))
                {
                    Users user = new Users();
                    user.Lastname = TxbxLastname.Text.Trim();
                    user.Firstname = TxbxFirstname.Text.Trim();
                    user.Middlename = TxbxMiddlename.Text.Trim();
                    user.Position = ((ComboBoxItem)CbxPosition.SelectedItem).Content.ToString();
                    user.Privilege = "User";
                    user.Email = TxbxEmail.Text.Trim();
                    user.Password = PwdBox.Password;

                    userRepository.AddUser(user);

                    //new Message("Вы успешно зарегестрированы в системе! Войдите под вашим логином и паролем!").ShowDialog();
                }

                else
                {
                    new Message("Пароли не совдпадают!").ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                new Message(ex.Message).ShowDialog();
            }

            
        }
    }
}
