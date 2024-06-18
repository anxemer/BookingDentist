using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class UpdateDentistServiceRequest
    {
        public int DentistId { get; set; }
        public int ServiceId { get; set; }
    }
    public static class UpdateDentistSericeExtention
    {
        public static DentistServiceModel ToDentistServiceModel(this UpdateDentistServiceRequest dentistServiceModel)
        {
            var dentist = new DentistServiceModel
            {
                DentistId = dentistServiceModel.DentistId,
                ServiceId = dentistServiceModel.ServiceId,
            };
            return dentist;
        }
    }
}
