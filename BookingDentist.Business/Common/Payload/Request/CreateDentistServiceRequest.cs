using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class CreateDentistServiceRequest
    {
        public int DentistId { get; set; }
        public int ServiceId { get; set; }
    }
    public static class CreateDentistServiceExtentio
    {
        public static DentistServiceModel ToDentistServiceModel(this CreateDentistServiceRequest serviceRequest)
        {
            var dentistService = new DentistServiceModel
            {
                DentistId = serviceRequest.DentistId,
                ServiceId = serviceRequest.ServiceId,
            };
            return dentistService;
        }
    }
}
