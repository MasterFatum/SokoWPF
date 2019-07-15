using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherSystem.Abstract;
using TeacherSystem.Entities;

namespace TeacherSystem.Concrete
{
    class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUserByLastame()
        {
            throw new NotImplementedException();
        }
    }
}
