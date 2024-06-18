using BookingDentist.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessModel
{
    public class ClinicModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ClinicPhone { get; set; }
        public string License { get; set; }
        public DateTime ExpDate { get; set; }
        public string OperationHours { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public int RegistrationPackageId { get; set; }

        public RegistrationPackage RegistrationPackage { get; set; }
        public ICollection<ClinicService> ClinicServices { get; set; }
    }
}
