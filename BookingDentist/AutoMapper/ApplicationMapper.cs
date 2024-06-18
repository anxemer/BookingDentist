using AutoMapper;
using BookingDentist.Business.BusinessModel;
using BookingDentist.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.API.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Account, AccountModel>().ReverseMap();
            CreateMap<Clinic, ClinicModel>().ReverseMap();
            CreateMap<ClinicService, ClinicServiceModel>().ReverseMap();
            CreateMap<ClinicAccount, ClinicAccountModel>().ReverseMap();
            CreateMap<Dentist, DentistModel>().ReverseMap();
            CreateMap<DentistService, DentistServiceModel>().ReverseMap();
            CreateMap<Service, ServiceModel>().ReverseMap();
            CreateMap<Appointment, AppointmentModel>().ReverseMap();
            CreateMap<Transaction, TransactionModel>().ReverseMap();
            CreateMap<RegistrationLicense, RegistrationLicenseModel>().ReverseMap();
            CreateMap<RegistrationPackage, RegistrationPackageModel>().ReverseMap();
        }
    }
}
