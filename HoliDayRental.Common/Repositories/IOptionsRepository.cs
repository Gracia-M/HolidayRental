using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.Common.Repositories
{
    public interface IOptionsRepository<TOptions> : IRepository<TOptions, int>,
        IGetByOptionsBienRepository<TOptions>
    {
        IEnumerable<TOptions> GetByCriteria(int criteria);
        IEnumerable<TOptions> GetByValue(int value);
    }
}
