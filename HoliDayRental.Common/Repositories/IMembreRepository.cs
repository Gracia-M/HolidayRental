using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.Common.Repositories
{
    public interface IMembreRepository<TMembre> : IRepository<TMembre, int>
    {
        public int checkPassword(string login, string password);
    }

}
