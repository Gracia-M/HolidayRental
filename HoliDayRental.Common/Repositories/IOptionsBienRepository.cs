using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.Common.Repositories
{
    public interface IOptionsBienRepository<TOptionsBien> : IRepository<TOptionsBien, int>
    {
        IEnumerable<TOptionsBien> GetByValue(int value);
        IEnumerable<TOptionsBien> GetByBienId(int bien_id);
        IEnumerable<TOptionsBien> GetByOptionId(int option_id);
    }
        
   
}
