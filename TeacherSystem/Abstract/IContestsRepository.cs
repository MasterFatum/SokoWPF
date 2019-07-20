using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherSystem.Abstract
{
    interface IContestsRepository
    {
        void AddContests(Contests contests);

        void DeleteContests(int id, int userId);

        void EditContests(Contests contests);

        IEnumerable<Contests> GetAllContests();

        IEnumerable<Contests> GetContestsByUser(Users user);

    }
}
