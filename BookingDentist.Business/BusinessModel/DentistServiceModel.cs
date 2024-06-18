using BookingDentist.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessModel
{
    public class DentistServiceModel
    {
        public int Id { get; set; }
        public int DentistId { get; set; }
        public int ServiceId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }

        public Dentist Dentist { get; set; }
        public Service Service { get; set; }
    }
}
