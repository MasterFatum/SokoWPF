using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeacherSystem.Abstract;
using TeacherSystem.Entities;

namespace TeacherSystem.Concrete
{
    class UserRepository : IUserRepository
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

        public void EditUser(Users user)
        {
            throw new NotImplementedException();
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
