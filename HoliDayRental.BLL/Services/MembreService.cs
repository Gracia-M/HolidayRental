using HoliDayRental.BLL.Entities;
using HoliDayRental.BLL.Handlers;
using HoliDayRental.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoliDayRental.BLL.Services
{
    public class MembreService : IMembreRepository<Membre>
    {
        private readonly IMembreRepository<DAL.Entities.Membre> _membreRepository;
        private readonly IPaysRepository<DAL.Entities.Pays> _paysRepository;

        public MembreService(IMembreRepository<DAL.Entities.Membre> membreRepository, IPaysRepository<DAL.Entities.Pays> paysRepository)
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

        public Membre Get(int id)
        {
            Membre result = _membreRepository.Get(id).ToBLL();
            result.Pays = _paysRepository.Get(result.Pays).ToBLL();
            return result;
        }

        public IEnumerable<Membre> Get()
        {
            return _membreRepository.Get().Select(d =>
            {
                Membre result = d.ToBLL();
                result.Pays = _paysRepository.Get(result.Pays).ToBLL();
                return result;
            });
        }

        public int Insert(Membre entity)
        {
            return _membreRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, Membre entity)
        {
            _membreRepository.Update(id, entity.ToDAL());
        }
    }
}
