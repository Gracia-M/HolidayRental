using HoliDayRental.BLL.Entities;
using HoliDayRental.BLL.Handlers;
using HoliDayRental.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using B = HoliDayRental.BLL.Entities;
using D = HoliDayRental.DAL.Entities;

namespace HoliDayRental.BLL.Services
{
    public class PaysService : IPaysRepository<B.Pays>
    {
        private readonly IPaysRepository<D.Pays> _paysRepository;

        public PaysService(IPaysRepository<D.Pays> paysRepository)
        {
            _paysRepository = paysRepository;
        }

        public void Delete(int id)
        {
            _paysRepository.Delete(id);
        }

        public B.Pays Get(int id)
        {
            return _paysRepository.Get(id).ToBLL();
        }

        public IEnumerable<B.Pays> Get()
        {
            return _paysRepository.Get().Select(p => p.ToBLL());
        }

        public int Insert(B.Pays entity)
        {
            return _paysRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, B.Pays entity)
        {
            _paysRepository.Update(id, entity.ToDAL());
        }
    }
}
