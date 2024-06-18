using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class CreateServiceRequest
    {
        public string ServiceName { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
    public static class CreateServiceExtention
    {
        public static ServiceModel ToServiceModel(this CreateServiceRequest request)
        {
            var serviceModel = new ServiceModel
            {
                ServiceName = request.ServiceName,
            };
            return serviceModel;
        }
    }
}
