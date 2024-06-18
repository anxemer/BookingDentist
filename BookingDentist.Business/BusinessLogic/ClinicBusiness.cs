using AutoMapper;
using BookingDentist.Business.BusinessModel;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.DataAccess;
using BookingDentist.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessLogic
{
    public class ClinicBusiness
    {
        private readonly IRepository<Clinic, int> _repository;
        private readonly IMapper _mapper;

        public ClinicBusiness(IRepository<Clinic,int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ClinicModel>> GetAllClinic()
        {
            var clinic =  _repository.GetAll();
            var clinicList = _mapper.Map<List<ClinicModel>>(clinic);
            return clinicList;
        } 
        public async Task<ClinicModel> GetClinicById(int id)
        {
            var clinic = await _repository.GetByIdAsync(id);
            if(clinic == null)
            {
                return null;
            }
            var clinicVew =  _mapper.Map<ClinicModel>(clinic);
            return clinicVew;
        }
        public async Task<ClinicModel> GetClinicByName(string name)
        {
            var clinic =  _repository.FindByCondition(c => c.Name == name).FirstOrDefault();
            if(clinic == null)
            {
                return null;
            }
            var clinicView = _mapper.Map<ClinicModel>(clinic);
            return clinicView;

        }
        public async Task<ClinicModel> CreateClinic(ClinicModel clinicModel)
        {
            var clinic = _mapper.Map<Clinic>(clinicModel);
            if(clinic == null)
            {
                return null;
            }
            await _repository.AddAsync(clinic);
            int result = await _repository.Commit();
            if(result > 0)
            {
                return clinicModel;
            }
            return null;
        }
        public async Task<ClinicModel> UpdateClinic(int id,UpdateClinicRequest updateClinic) 
        {
            var clinicExist = await _repository.GetByIdAsync(id);
            if(clinicExist == null)
            {
                return null;
            }
            clinicExist.Image = updateClinic.Image;
            clinicExist.Name = updateClinic.Name;
            clinicExist.Address = updateClinic.Address;
            clinicExist.ClinicPhone = updateClinic.ClinicPhone;
            clinicExist.License = updateClinic.License;
            clinicExist.UpdateAt = DateTime.UtcNow;
            var clinic = _repository.Update(clinicExist);
            var result = await _repository.Commit();
            if (result > 0)
            {
                return _mapper.Map<ClinicModel>(clinicExist);
            }
            else return null;

        }
        public async Task<bool> ChangeStatus(int id,string status)
        {
            var clinicExist = await _repository.GetByIdAsync(id);
            if(clinicExist == null)
            {
                throw new ArgumentException("Clinit not found");
            }
            clinicExist.Status = status;
            _repository.Update(clinicExist);
            var result = await _repository.Commit();
           return result > 0;
        }
        public async Task<bool> DeleteClinic(int id)
        {
            var clinicDelete = await _repository.GetByIdAsync(id);
            if (clinicDelete is not null)
            {
                _repository.Remove(id);
                var result = await _repository.Commit();
                return result > 0;
            }
            else throw new ArgumentException("Clinic Not Found");
        }
    }
}
