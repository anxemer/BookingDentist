using BookingDentist.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessModel
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int PackageId { get; set; }
        public string TransMethod { get; set; }
        public string Status { get; set; }

        public Clinic Clinic { get; set; }
        public RegistrationPackage RegistrationPackage { get; set; }
    }
}
