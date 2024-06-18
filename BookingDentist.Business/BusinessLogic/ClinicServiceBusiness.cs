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
    public class ClinicServiceBusiness
    {
        private readonly IRepository<ClinicService, int> _repository;
        private readonly IMapper _mapper;
        private readonly ClinicBusiness _clinicBusiness;
        private readonly ServiceBusiness _serviceBusiness;

        public ClinicServiceBusiness(IRepository<ClinicService, int> repository, IMapper mapper, ClinicBusiness clinicBusiness, ServiceBusiness serviceBusiness)
        {
            _repository = repository;
            _mapper = mapper;
            _clinicBusiness = clinicBusiness;
            _serviceBusiness = serviceBusiness;
        }
        public async Task<List<ClinicServiceModel>> GetAllClinicService()
        {
            var clnic =  _repository.GetAll();
            if (clnic == null)
            {
                throw new ArgumentException("List null");
            }
            var clinicserviceList = _mapper.Map<List<ClinicServiceModel>>(clnic).ToList();
            return clinicserviceList;
        }
        public async Task<ClinicServiceModel> GetClinicServiceById(int id)
        {
            var clinic = await _repository.GetByIdAsync(id);
            if (clinic == null)
            {
                throw new ArgumentException("Clinic service not found");
            }
            var csModel = _mapper.Map<ClinicServiceModel>(clinic);
            return csModel;
        }
        public async Task<ClinicServiceModel> CreateClinicService(ClinicServiceModel clinicServiceModel)
        {
            var csNew = _mapper.Map<ClinicService>(clinicServiceModel);
            var cliniExist = await _clinicBusiness.GetClinicById(csNew.ClinicId);
            var serviceExist = await _serviceBusiness.GetServiceById(csNew.ServiceId);
            if(serviceExist == null)
            {
                throw new ArgumentException("Service not exist");
            }
            if(cliniExist == null)
            {
                throw new ArgumentException("Clinic not exist");
            }
            await _repository.AddAsync(csNew);
            return clinicServiceModel;
        }
        public async Task<ClinicServiceModel> UpdateClinicService(int id,ClinicServiceModel clinicServiceModel)
        {
            var csExist = await _repository.GetByIdAsync(id);
            if(csExist == null)
            {
                throw new ArgumentException("Clinic Sercice not found");
            }
            csExist.Duration = clinicServiceModel.Duration;
            csExist.ServiceId = clinicServiceModel.ServiceId;
            csExist.ClinicId = clinicServiceModel.ClinicId;
            csExist.Price = clinicServiceModel.Price;
            csExist.Description = clinicServiceModel.Description;

            _repository.Update(csExist);
            var result = await _repository.Commit();
            if(result> 0)
            {
                return clinicServiceModel;
            }
            return null;
            
        }
    }
}
