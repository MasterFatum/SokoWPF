using System;
using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Abstract
{
    interface IUserRepository
    {
        void AddUser(Users user);

        void DeleteUser(int id);

        void EditUser(int id, string lastname, string firstname, string middlename, string position, string email);

        void EditUser(int id, string lastname, string firstname, string middlename, string position, string email, string password);

        IEnumerable<Users> GetAllUser();

        List<String> GetFioUsers();

        Users ValidationUser(string username, string password);

        Users ValidationAdmin(string username, string password);

        IEnumerable<Users> SearchUsersByLastname(string lastname);

        IEnumerable<Users> SearchUsersByPosition(string position);

        void SokoDispose();




    }
}
