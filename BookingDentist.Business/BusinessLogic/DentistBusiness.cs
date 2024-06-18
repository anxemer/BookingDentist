using AutoMapper;
using BookingDentist.Business.BusinessModel;
using BookingDentist.DataAccess;
using BookingDentist.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessLogic
{
    public class DentistBusiness
    {
        private readonly IRepository<Dentist, int> _repository;
        private readonly IMapper _mapper;

        public DentistBusiness(IRepository<Dentist,int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<DentistModel>> GetAllDentist()
        {
            var dentist = _repository.GetAll();
            var dentsitList = _mapper.Map<List<DentistModel>>(dentist).ToList();
            return dentsitList;
        }
        public async Task<DentistModel> GetDentistById(int id)
        {
            var dentist = await _repository.GetByIdAsync(id);
            if(dentist == null)
            {
                throw new ArgumentException("Dentist not found");
            }
            var dentistModel = _mapper.Map<DentistModel>(dentist);
            return dentistModel;
        }
        public async Task<DentistModel> GetDentistByName(string name)
        {
            var dentist = _repository.FindByCondition(d => d.Name == name).FirstOrDefault();
            return _mapper.Map<DentistModel>(dentist);
        }
        public async Task<DentistModel> CreateDentist(DentistModel dentistModel)
        {
            var dentistEntity = _mapper.Map<Dentist>(dentistModel);
            var dentistExist = _repository.FindByCondition(d => d.Name == dentistModel.Name);
            if(dentistExist is not null)
            {
                throw new ArgumentException("Detist already exist");
            }
            dentistEntity = await _repository.AddAsync(dentistEntity);
            var result = await _repository.Commit();
            if(result > 0)
            {
                return dentistModel;
            }else return null;

        }
    }
}
