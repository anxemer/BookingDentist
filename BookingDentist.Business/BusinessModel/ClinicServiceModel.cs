using BookingDentist.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessModel
{
    public class ClinicServiceModel
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }

        public Clinic Clinic { get; set; }
        public Service Service { get; set; }
    }
}
