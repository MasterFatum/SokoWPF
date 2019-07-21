using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherSystem.Abstract
{
    interface IUserRepository
    {
        void AddUser(Users user);

        void DeleteUser(int id);

        void EditUser(Users user);

        IEnumerable<Users> GetAllUser();

        Users ValidationUser(string username, string password);

        IEnumerable<Users> SearchUsersByLastname(string lastname);

        IEnumerable<Users> SearchUsersByPosition(string position);
    }
}
