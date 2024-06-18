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
    public class ClinicAccountBusiness
    {
        private readonly IRepository<ClinicAccount, int> _repository;
        private readonly IMapper _mapper;

        public ClinicAccountBusiness(IRepository<ClinicAccount,int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ClinicAccountModel>> GetAllClinicAccount()
        {
            var clinicAccount = _repository.GetAll();
            var clinicAccountList = _mapper.Map<List<ClinicAccountModel>>(clinicAccount);
            return clinicAccountList;
        }
        public async Task<ClinicAccountModel> GetClinicAccountById(int id)
        {
            var clinicAccount = await _repository.GetByIdAsync(id);
            if(clinicAccount == null)
            {
                return null;
            }
            var clinicAccountModel = _mapper.Map<ClinicAccountModel>(clinicAccount);
            return clinicAccountModel;
        }
        public async Task<ClinicAccountModel> CreateClinicAccount(ClinicAccountModel model)
        {
            var clinicAcount = _mapper.Map<ClinicAccount>(model);
            if(clinicAcount == null)
            {
                return null;
            }
            await _repository.AddAsync(clinicAcount);
            var result = _repository.Commit();
            if(result != null)
            {
                return null;
            }
            return model;
        }
        public async Task<ClinicAccountModel> UpdateClinicAccount(int id, ClinicAccountModel model)
        {
            var ClinicAccountExisted = await _repository.GetByIdAsync(id);
            if(ClinicAccountExisted == null)
            {
                return null;
            }
            ClinicAccountExisted.UpdateAt = DateTime.Now;
            ClinicAccountExisted.RegisterId = model.Id;
            ClinicAccountExisted.Approved = model.Approved;
            ClinicAccountExisted.ClinicId = model.ClinicId;
            var result = await _repository.Commit();
            if(result > 0)
            {
                return _mapper.Map<ClinicAccountModel>(model);
            }
            return null;
        }
    }
}
