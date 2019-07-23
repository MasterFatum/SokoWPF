﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherSystem.Abstract;

namespace TeacherSystem.Concrete
{
    class ContestsRepository : IContestsRepository
    {
        SokoContext sokoContext = new SokoContext();

        public void AddContests(Contests contests)
        {
            try
            {
                sokoContext.Contests.Add(contests);
                sokoContext.SaveChanges();
                new Message("Категория успешно добавлена!").ShowDialog();
            }
            catch (Exception e)
            {
                new Message(e.Message).ShowDialog();
            }
            
        }

        public void DeleteContests(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public void EditContests(Contests contests)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contests> GetAllContests()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contests> GetContestsByUserId(int userId)
        {
            IEnumerable<Contests> contestses = sokoContext.Contests.Where(u => u.UserId == userId).ToList();

            return contestses;
        }

        public IEnumerable<Contests> GetContestsByUser(Users user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contests> GetContestsByPosition(string position)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contests> GetContestsByFirstname(string firstname)
        {
            throw new NotImplementedException();
        }
    }
}
