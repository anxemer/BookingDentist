using BookingDentist.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessModel
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int AccountId { get; set; }
        public int DentistId { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }

        public Account Account { get; set; }
        public Service Service { get; set; }
        public Dentist Dentist { get; set; }
    }
}
