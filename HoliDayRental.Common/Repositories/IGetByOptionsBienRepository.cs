using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.Common.Repositories
{
    public interface IGetByOptionsBienRepository<TEntity>
    {
        public TEntity GetByOptionsId(int optionsId);
    }
}
