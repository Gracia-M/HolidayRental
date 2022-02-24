using HoliDayRental.BLL.Entities;
using HoliDayRental.BLL.Handlers;
using HoliDayRental.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoliDayRental.BLL.Services
{
    public class BienEchangeService : IBienEchangeRepository<BienEchange>
    {
        private readonly IBienEchangeRepository<DAL.Entities.BienEchange> _bienEchangeRepository;
        public BienEchangeService(IBienEchangeRepository<DAL.Entities.BienEchange> repository)
        {
            _bienEchangeRepository = repository;
        }
        public void Delete(int id)
        {
            _bienEchangeRepository.Delete(id);
        }

        public BienEchange Get(int id)
        {
            return _bienEchangeRepository.Get(id).ToBLL();
        }

        public IEnumerable<BienEchange> Get()
        {
            return _bienEchangeRepository.Get().Select(b => b.ToBLL());
        }

        public IEnumerable<BienEchange> GetByCapacity(int nbrPerson)
        {
            return _bienEchangeRepository.GetByOption(nbrPerson).Select(b => b.ToBLL());
        }

        public IEnumerable<BienEchange> GetByCountry(int country_id)
        {
            return _bienEchangeRepository.GetByOption(country_id).Select(b => b.ToBLL());
        }

        public IEnumerable<BienEchange> GetByOption(int option_id)
        {
            return _bienEchangeRepository.GetByOption(option_id).Select(b => b.ToBLL());
        }

        public IEnumerable<BienEchange> GetByOptionsBien(int option_id, string choice)
        {
            return _bienEchangeRepository.GetByOptionsBien(option_id, choice).Select(b => b.ToBLL());
        }

        public BienEchange GetByOptionsId(int optionsId)
        {
            return _bienEchangeRepository.GetByOptionsId(optionsId).ToBLL();
        }

        public int Insert(BienEchange entity)
        {
            return _bienEchangeRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, BienEchange entity)=>
            _bienEchangeRepository.Update(id, entity.ToDAL());
        }
    }
}

