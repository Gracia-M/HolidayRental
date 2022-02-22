using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.Common.Repositories
{
    public interface IBienEchangeRepository<TBienEchange>: IRepository<TBienEchange, int>, 
        IGetByCountryRepository<TBienEchange>
    {
        IEnumerable<TBienEchange> GetByCountry(int country);
        IEnumerable<TBienEchange> GetByCapacity(int nbrPerson);
    }
}
