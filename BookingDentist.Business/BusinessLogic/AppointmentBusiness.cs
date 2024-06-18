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
    public class AppointmentBusiness
    {
        private readonly IRepository<Appointment, int> _repository;
        private readonly IMapper _mapper;
        private readonly ServiceBusiness _serviceBusiness;
        private readonly AccountBussiness _accountBussiness;
        private readonly DentistBusiness _dentistBusiness;

        public AppointmentBusiness(IRepository<Appointment,int> repository,IMapper mapper,ServiceBusiness serviceBusiness,AccountBussiness accountBussiness,DentistBusiness dentistBusiness )
        {
           _mapper = mapper;
           _serviceBusiness = serviceBusiness;
           _repository = repository;
           _accountBussiness = accountBussiness;
           _dentistBusiness = dentistBusiness;
        }
        public async Task<AppointmentModel> CreateAppointment(AppointmentModel model)
        {
            var appNew = _mapper.Map<Appointment>(model);
            var accountExist = _accountBussiness.GetAccountById(appNew.AccountId);
            var serviceExist = _serviceBusiness.GetServiceById(appNew.ServiceId);
            var denExist = _dentistBusiness.GetDentistById(appNew.DentistId);
            if(accountExist == null)
            {
                throw new ArgumentException("account not found");
            }
            if(serviceExist == null)
            {
                throw new ArgumentException("service not found");
            }
            if ( denExist == null )
            {
                throw new ArgumentException("dentist not found");
            }
            await _repository.AddAsync(appNew);
            var result = await _repository.Commit();
            if(result > 0)
            {
                return model;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<AppointmentModel>> GetAllAppointment()
        {
            var appointment =   _repository.GetAll();
            if(appointment == null)
            {
                return null;
            }
            var appoModel = _mapper.Map<List<AppointmentModel>>(appointment);
            return appoModel;
        }
        public async Task<AppointmentModel> GetAppointmentById(int id)
        {
            var appo = await _repository.GetByIdAsync(id);
            if(appo == null)
            {
                throw new ArgumentException("Appointment not found");
            }
            return _mapper.Map<AppointmentModel>(appo);
        }
        public async Task<AppointmentModel> UpdateAppointment(int id, AppointmentModel model)
        {
            var appoExist = await _repository.GetByIdAsync(id);
            if( appoExist == null)
            {
                throw new ArgumentException("Appointment not found");
            }
            appoExist.UpdateAt = DateTime.Now;
            appoExist.Status = model.Status;
            appoExist.AccountId = model.AccountId;
            appoExist.DentistId = model.DentistId;
            appoExist.ServiceId = model.ServiceId;
            appoExist.Time = model.Time;
            appoExist.Date = model.Date;
            _repository.Update(appoExist);
            var result = await _repository.Commit();
            if (result > 0  )
            {
                return model;
            }
            else return null;
        }
        public async Task<bool> DeleteApponitment(int id)
        {
            var appoExist = await _repository.GetByIdAsync(id);
            _repository.Remove(id);
            var result = await _repository.Commit();
            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
