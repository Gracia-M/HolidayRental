using HoliDayRental.BLL.Entities;
using HoliDayRental.BLL.Handlers;
using HoliDayRental.Common.Repositories;
using HoliDayRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using B = HoliDayRental.BLL.Entities;
using D = HoliDayRental.DAL.Entities;

namespace HoliDayRental.BLL.Services
{
    public class MembreService : IMembreRepository<B.Membre>
    {
        private readonly IMembreRepository<D.Membre> _membreRepository;
        private readonly IPaysRepository<D.Pays> _paysRepository;

        public MembreService(IMembreRepository<D.Membre> membreRepository, IPaysRepository<D.Pays> paysRepository) 
        {
            _membreRepository = membreRepository;
            _paysRepository = paysRepository;
        }
        public int checkPassword(string login, string password)
        {
            return _membreRepository.checkPassword(login, password);
        }

        public void Delete(int id)
        {
            _membreRepository.Delete(id);
        }

        public B.Membre Get(int id)
        {
            B.Membre result = _membreRepository.Get(id).ToBLL();
            result.Pays = _paysRepository.Get(result.Pays_Id).ToBLL();
            return result;
        }

        public IEnumerable<B.Membre> Get()
        {
            return _membreRepository.Get().Select(d =>
            {
                B.Membre result = d.ToBLL();
                result.Pays = _paysRepository.Get(result.Pays_Id).ToBLL();
                return result;
            });
        }

        public int Insert(B.Membre entity)
        {
            return _membreRepository.Insert(entity.ToDAL());
        }
        public void Update(int id, B.Membre entity)
        {
            _membreRepository.Update(id, entity.ToDAL());
        }
    }
}

