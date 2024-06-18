using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class UpdateClinicServiceRequest
    {
        public int ClinicId { get; set; }
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
    }
    public static class UpdateClinicServiceExtention
    {
        public static ClinicServiceModel ToClinicServiceModel(this UpdateClinicServiceRequest request)
        {
            var csModel = new ClinicServiceModel
            {
                ClinicId = request.ClinicId,
                ServiceId = request.ServiceId,
                Description = request.Description,
                Price = request.Price,
                Duration = request.Duration,
            };
            return csModel;
        }
    }
}
