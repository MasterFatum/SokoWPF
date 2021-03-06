﻿using System;
using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Abstract
{
    interface IUserRepository
    {
        void AddUser(Users user);

        void DeleteUser(int id);

        void EditUser(int id, string lastname, string firstname, string middlename, string position, string email);

        void EditUser(int id, string lastname, string firstname, string middlename, string position, string email, string password, string privilege);

        IEnumerable<Users> GetAllUser();

        List<String> GetFioUsers();

        Users ValidationUser(string username, string password);

        Users ValidationAdmin(string username, string password);

        void SokoDispose();

        string GetAllUsersCount();

        int GetUserIdByFio(string lastname, string firstname, string middlename);

    }
}
