using BookingDentist.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessModel
{
    public class ClinicAccountModel
    {
        public int Id { get; set; }
        public int RegisterId { get; set; }
        public bool? Approved { get; set; }
        public int ClinicId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }

        public Account Account { get; set; }
        public Clinic Clinic { get; set; }
    }
}
