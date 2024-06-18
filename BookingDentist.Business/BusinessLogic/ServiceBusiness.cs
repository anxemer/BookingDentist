using AutoMapper;
using BookingDentist.Business.BusinessModel;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.DataAccess;
using BookingDentist.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessLogic
{
    public class ServiceBusiness
    {
        private readonly IRepository<Service, int> _repository;
        private readonly IMapper _mapper;

        public ServiceBusiness(IRepository<Service,int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ServiceModel>> GetAllService()
        {
            var service = _repository.GetAll();
            if(service == null)
            {
                return null;
            }
            var serviceList = _mapper.Map<List<ServiceModel>>(service).ToList();
            return serviceList;
        }
        public async Task<ServiceModel> GetServiceById(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            if(service == null)
            {
                throw new ArgumentException("Service not found");
            }
            var serviceModel = _mapper.Map<ServiceModel>(service);
            return serviceModel;
        }
        public async Task<ServiceModel> GetServiceByName(string name)
        {
            var service =  _repository.FindByCondition(s => s.ServiceName == name).FirstOrDefault();
            if(service == null)
            {
                throw new ArgumentException("Service not found");
            }
            return _mapper.Map<ServiceModel>(service);  
        }
        public async Task<ServiceModel> CreateService(ServiceModel model)
        {
            var service = _mapper.Map<Service>(model);
            var serviceExist = _repository.FindByCondition(s => s.ServiceName == service.ServiceName).FirstOrDefault();
            if( serviceExist is not null)
            {
                throw new ArgumentException("Service already exist");
            }
            await _repository.AddAsync(service);
            var result = await _repository.Commit();
            if (result > 0)
            {
                return model;
            }
            else return null;
        }
        public async Task<ServiceModel> UpdateService(int id,UpdateServiceRequest model)
        {
            var serviceExxit = await _repository.GetByIdAsync(id);
            if (serviceExxit == null)
            {
                throw new ArgumentException("Service not found");
            }
            serviceExxit.ServiceName = model.ServiceName;
            var service =  _repository.Update(serviceExxit);
            var result = await _repository.Commit();
            if (result > 0)
            {
                return _mapper.Map<ServiceModel>(serviceExxit);
            }
            else return null;
                 
        }
    }
}
