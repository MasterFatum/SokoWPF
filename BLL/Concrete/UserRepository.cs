using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLL;
using BLL.Abstract;
using BLL.Entities;

namespace BLL.Concrete
{
    public class UserRepository : IUserRepository
    {
        SokoContext sokoContext = new SokoContext();

        public void AddUser(Users user)
        {
            try
            {
                sokoContext.Users.Add(user);

                sokoContext.SaveChanges();

                MessageBox.Show("Вы успешно зарегистрированы в системе! Войдите в систему под вашим логином и паролем!", "", MessageBoxButton.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void EditUser(int id, string lastname, string firstname, string middlename, string position, string email)
        {
            try
            {
                var user = sokoContext.Users.Find(id);

                if (user != null)
                {
                    user.Lastname = lastname;
                    user.Firstname = firstname;
                    user.Middlename = middlename;
                    user.Position = position;
                    user.Email = email;

                    sokoContext.Users.AddOrUpdate(user);

                    sokoContext.SaveChanges();

                    MessageBox.Show("Ваш аккаунт успешно отредактирован!", "Редактирование пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EditUser(int id, string lastname, string firstname, string middlename, string position, string email, string password)
        {
            try
            {
                var user = sokoContext.Users.Find(id);

                if (user != null)
                {
                    user.Id = id;
                    user.Lastname = lastname;
                    user.Firstname = firstname;
                    user.Middlename = middlename;
                    user.Position = position;
                    user.Email = email;
                    user.Password = password;

                    sokoContext.Users.AddOrUpdate(user);

                    sokoContext.SaveChanges();

                    MessageBox.Show("Аккаунт успешно отредактирован!", "Редактирование пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IEnumerable<Users> GetAllUser()
        {
            IEnumerable<Users> users = sokoContext.Users.ToList();

            return users;
        }

        public List<String> GetFioUsers()
        {
            List<Users> users = sokoContext.Users.ToList();

            List<String> userFio  = new List<string>();

            foreach (var user in users)
            {
                userFio.Add(String.Format($"{user.Lastname} {user.Firstname} {user.Middlename}"));
            }

            return userFio;
        }

        public Users ValidationUser(string username, string password)
        {
            try
            {
                Users user = null;

                var findUser = sokoContext.Users.FirstOrDefault(u => u.Email == username);

                if (findUser != null)
                {
                    if (findUser.Password == password)
                    {
                        user = findUser;

                    }
                }

                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public Users ValidationAdmin(string username, string password)
        {
            Users user = null;
            
            var findUser = sokoContext.Users.Where(p => p.Privilege == "Admin").FirstOrDefault(u => u.Email == username);

            if (findUser != null)
            {
                if (findUser.Password == password)
                {
                    user = findUser;
                }
            }

            return user;
        }

        public IEnumerable<Users> SearchUsersByLastname(string lastname)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> SearchUsersByPosition(string position)
        {
            throw new NotImplementedException();
        }
        
    }
}
