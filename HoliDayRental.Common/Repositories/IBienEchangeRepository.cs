using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.Common.Repositories
{
    public interface IBienEchangeRepository<TBienEchange>: IRepository<TBienEchange, int>, 
        IGetByOptionsBienRepository<TBienEchange>
    {
        IEnumerable<TBienEchange> GetByCapacity(int nbrPerson);
        IEnumerable<TBienEchange> GetByCountry(int country_id);
        IEnumerable<TBienEchange> GetByOptionsBien(int option_id, string choice);
        IEnumerable<TBienEchange> GetByOption(int option_id);
       
    }
}
