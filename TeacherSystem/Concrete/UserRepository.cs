using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherSystem.Abstract;

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
            }
            catch (Exception e)
            {
                new Message(e.Message).ShowDialog();
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

        public IQueryable<Users> GetUserByLastame()
        {
            throw new NotImplementedException();
        }
    }
}
