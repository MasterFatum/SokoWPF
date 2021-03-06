﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;
using BLL.Entities;

namespace BLL.Abstract
{
    interface ICourseRepository
    {
        void AddCourse(Courses courses, TextBox title, TextBox description, TextBox hyperlink, TextBox dataFileName);

        void DeleteCourse(int id, int userId);

        void EditCourse(Courses courses);

        IEnumerable<Courses> GetAllCategory();

        IEnumerable<Courses> GetCoursesByUserId(int userId);

        IEnumerable<Courses> GetCoursesByCategory(int userId, string position);

        IEnumerable<Courses> GetCoursesByFio(string lastname, string firstname, string middlename);

        IEnumerable<Courses> GetCoursesByFio(string lastname, string firstname, string middlename, string category);

        void SetRatingCourse(int userId, int id, int rating, string evaluating);

        string AllRating(int userId);

        void SendFileToDb(int userId, string ipAddress, string filePath, string fileNameGuid);

        void DeleteFileToDb(int userId, string ipAddress, string fileNameGuid);

        void DownloadFileToDb(string ipAddress, int userId, string filename, string newFilename);

        IEnumerable<Courses> GetSummaryStatementByFio(string lastname, string firstname, string middlename);

    }
}
