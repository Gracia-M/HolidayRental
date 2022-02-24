using HoliDayRental.BLL.Entities;
using HoliDayRental.BLL.Handlers;
using HoliDayRental.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoliDayRental.BLL.Services
{
    public class OptionsBienService : IOptionsBienRepository<OptionsBien>
    {
        private readonly IOptionsBienRepository<DAL.Entities.OptionsBien> _optionBienRepository;
        private readonly IOptionsRepository<DAL.Entities.Options> _optionRepository;
        private readonly IBienEchangeRepository<DAL.Entities.BienEchange> _bienRepository;

        public OptionsBienService(
            IOptionsBienRepository<DAL.Entities.OptionsBien> optionBienRepository,
            IOptionsRepository<DAL.Entities.Options> optionRepository,
            IBienEchangeRepository<DAL.Entities.BienEchange> bienRepository)
        {
            _optionBienRepository = optionBienRepository;
            _optionRepository = optionRepository;
            _bienRepository = bienRepository;
        }
        public void Delete(int id)
        {
            _optionBienRepository.Delete(id);
        }

        public IEnumerable<OptionsBien> GetByValue(int value)
        {
            return _optionRepository.GetByValue(value).Select(op => {
                OptionsBien result = op.ToBLL();
                result.Bien = _bienRepository.Get(result.idBien).ToBLL();
                result.Option = _optionRepository.Get(result.idOption).ToBLL();
                return result;
            });
        }

        public OptionsBien Get(int id)
        {
            OptionsBien result = _optionBienRepository.Get(id).ToBLL();
            result.Bien = _bienRepository.Get(result.idBien).ToBLL();        
            result.Option = _optionRepository.Get(result.idOption).ToBLL();
            return result;
        }

        public IEnumerable<OptionsBien> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OptionsBien> GetByBienId(int bien_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OptionsBien> GetByOptionId(int option_id)
        {
            return _optionBienRepository.GetByOptionId(option_id).Select(opt => {
                OptionsBien result = opt.ToBLL();
                result.Bien = _bienRepository.Get(result.idBien).ToBLL();
                result.Option = _optionRepository.Get(result.idOption).ToBLL();
                return result;
            });

        }

        public int Insert(OptionsBien entity)
        {
            return _optionBienRepository.Insert(entity.ToDAL());
        }

        public void Update(int id, OptionsBien entity)
        {
            _optionBienRepository.Update(id, entity.ToDAL());
        }
    }

}
