using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherSystem.Entities;

namespace TeacherSystem.Abstract
{
    interface IUserRepository
    {
        void AddUser(User user);

        void DeleteUser(int id);

        void EditUser(User user);

        IEnumerable<User> GetAllUser();

        IQueryable<User> GetUserByLastame();

    }
}
