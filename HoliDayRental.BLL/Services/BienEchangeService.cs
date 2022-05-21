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
    public class BienEchangeService : IBienEchangeRepository<B.BienEchange>
    {
        private readonly IBienEchangeRepository<D.BienEchange> _bienEchangeRepository;
        private readonly IMembreRepository<D.Membre> _membreRepository;
        private readonly IPaysRepository<D.Pays> _paysRepository;
        public BienEchangeService(IBienEchangeRepository<D.BienEchange> repository, IMembreRepository<D.Membre> membreRepository, IPaysRepository<D.Pays> paysRepository)
        {
            _bienEchangeRepository = repository;
            _membreRepository = membreRepository;
            _paysRepository = paysRepository;
        }

        public void Delete(int id)
        {
            _bienEchangeRepository.Delete(id);
        }

        public B.BienEchange Get(int id)
        {
            B.BienEchange result = _bienEchangeRepository.Get(id).ToBLL();
            result.Membre = _membreRepository.Get(result.idMembre).ToBLL();
            result.Country = _paysRepository.Get(result.Pays_Id).ToBLL();
            return result;
        }

        public IEnumerable<B.BienEchange> Get()
        {
            return _bienEchangeRepository.Get().Select(d =>
            {
                B.BienEchange result = d.ToBLL();
                result.Membre = _membreRepository.Get(result.idMembre).ToBLL();
                result.Country = _paysRepository.Get(result.Pays_Id).ToBLL();
                return result;
            });
        }

        public int Insert(B.BienEchange entity)
        {
            return _bienEchangeRepository.Insert(entity.ToDAL());
        }

        public IEnumerable<B.BienEchange> LastFiveBiens()
        {
            return _bienEchangeRepository.LastFiveBiens().Select(d =>
            {
                B.BienEchange result = d.ToBLL();
                result.Membre = _membreRepository.Get(result.idMembre).ToBLL();
                result.Country = _paysRepository.Get(result.Pays_Id).ToBLL();
                return result;
            });
        }

        public void Update(int id, B.BienEchange entity)
        {
            _bienEchangeRepository.Update(id, entity.ToDAL());
        }

    }
}

