using BookingDentist.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessModel
{
    public class DentistModel
    {
        public int Id { get; set; }
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

        public ICollection<DentistService> DentistServices { get; set; }
    }
}
