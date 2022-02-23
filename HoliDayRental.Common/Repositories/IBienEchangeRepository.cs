using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.Common.Repositories
{
    public interface IBienEchangeRepository<TBienEchange>: IRepository<TBienEchange, int>
    {
        IEnumerable<TBienEchange> GetByCapacity(int nbrPerson);

        IEnumerable<TBienEchange> GetByCountry(int country_id);
    }
}
