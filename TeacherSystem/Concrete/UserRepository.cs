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
        public void AddUser(Users user)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IQueryable<Users> GetUserByLastame()
        {
            throw new NotImplementedException();
        }
    }
}
