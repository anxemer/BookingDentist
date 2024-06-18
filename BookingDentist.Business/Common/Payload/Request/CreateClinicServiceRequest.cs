using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class CreateClinicServiceRequest
    {
        public int ClinicId { get; set; }
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
    }
    public static class CreateClinicServiceExtention
    {
        public static ClinicServiceModel ToCinicServiceModel(this CreateClinicServiceRequest clinicServiceModel)
        {
            var csModel = new ClinicServiceModel
            {
                ClinicId = clinicServiceModel.ClinicId,
                ServiceId = clinicServiceModel.ServiceId,
                Description = clinicServiceModel.Description,
                Duration = clinicServiceModel.Duration,
            };
            return csModel;
        }
    }
}
