using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class UpdateServiceRequest
    {
        public string ServiceName { get; set; }

    }
    public static class UpdateServiceExtention {
        public static ServiceModel ToServiceModel(this ServiceModel serviceModel)
        {
            var service = new ServiceModel
            {
                ServiceName = serviceModel.ServiceName
            };
            return service;
        }
    }
}
