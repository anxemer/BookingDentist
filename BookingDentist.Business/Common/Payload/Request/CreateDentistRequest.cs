using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class CreateDentistRequest
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseState { get; set; }
        public string Specialties { get; set; }
        public int YearsOfExperience { get; set; }
        public string Education { get; set; }
        public string ProfessionalAffiliations { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
    public static class CreateDentistExtention
    {
        public static DentistModel ToDentistModel(this CreateDentistRequest createDentist)
        {
            var model = new DentistModel
            {
                Image = createDentist.Image,
                Name = createDentist.Name,
                Phone = createDentist.Phone,
                DOB = createDentist.DOB,
                Gender = createDentist.Gender,
                Address = createDentist.Address,
                Email = createDentist.Email,
                LicenseNumber = createDentist.LicenseNumber,
                CreateAt = createDentist.CreateAt,
                LicenseState = createDentist.LicenseState,
                Education = createDentist.Education,
                Specialties = createDentist.Specialties,
                IsDeleted = createDentist.IsDeleted,
                ProfessionalAffiliations = createDentist.ProfessionalAffiliations,
                UpdateAt = createDentist.UpdateAt,
                YearsOfExperience = createDentist.YearsOfExperience,

            };
            return model;
        }
    }
}
