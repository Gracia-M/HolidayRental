using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.Common.Repositories
{
    public interface IGetByCountryRepository<TEntity>
    {
        public TEntity GetByCountryId(int countryId);
    }
}
