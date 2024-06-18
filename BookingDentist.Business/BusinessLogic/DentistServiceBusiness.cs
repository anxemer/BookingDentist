using AutoMapper;
using BookingDentist.Business.BusinessModel;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.DataAccess;
using BookingDentist.DataAccess.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessLogic
{
    public class DentistServiceBusiness
    {
        private readonly IRepository<DentistService, int> _repository;
        private readonly DentistBusiness _dentistBusiness;
        private readonly ServiceBusiness _serviceBusiness;
        private readonly IMapper _mapper;

        public DentistServiceBusiness(IRepository<DentistService,int> repository,DentistBusiness dentistBusiness,ServiceBusiness serviceBusiness,IMapper mapper)
        {
            _repository = repository;
            _dentistBusiness = dentistBusiness;
            _serviceBusiness = serviceBusiness;
            _mapper = mapper;
        }
        public async Task<List<DentistServiceModel>> GetAllDentistService()
        {
            var dentist =  _repository.GetAll();
           if(dentist == null)
            {
                throw new ArgumentException("Nothing to show");
            }
           var dentistList = _mapper.Map<List<DentistServiceModel>>(dentist);
            return dentistList;
        }
        public async Task<DentistServiceModel> GetDentistServiceById(int id)
        {
            var dentist = await _repository.GetByIdAsync(id);
            if(dentist == null)
            {
                throw new ArgumentException("Dentist service not found");
            }
            var dentistModel = _mapper.Map<DentistServiceModel>(dentist);
            return dentistModel;
        }
        //public async Tasl<DentistServiceModel> GetDentistServiceByName(string name)
        //{
        //    var dentist = _repository.FindByCondition(d => d.)
        //}
        public async Task<DentistServiceModel> CraeteDentistService(DentistServiceModel dentistService)
        {
            var dsModel = _mapper.Map<DentistService>(dentistService);
            var dentist = _dentistBusiness.GetDentistById(dsModel.DentistId);
            var service = _serviceBusiness.GetServiceById(dsModel.ServiceId);
            if(dentist == null)
            {
                throw new ArgumentException("dentist not found");
            }
            if(service == null)
            {
                throw new ArgumentException("service not found");
            }
            var dsNew = await _repository.AddAsync(dsModel);
            return dentistService;
        }
        public async Task<DentistServiceModel> UpdateDentistService(int id,UpdateDentistServiceRequest updateDentist)
        {
            var dsExist = await _repository.GetByIdAsync(id);
            if(dsExist == null)
            {
                throw new ArgumentException("Dentist Service not found");
            }
            dsExist.DentistId = updateDentist.DentistId;
            dsExist.ServiceId = updateDentist.ServiceId;
            _repository.Update(dsExist);
            var result = await _repository.Commit();
            if (result > 0)
            {
                return _mapper.Map<DentistServiceModel>(result);
            }
            return null;
        }
    }
}
