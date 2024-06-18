using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class UpdateClinicAccountRequest
    {
        public int RegisterId { get; set; }
        public bool? Approved { get; set; }
        public int ClinicId { get; set; }
    }
    public static class UpdateClinicAccountRequestExtention
    {
        public static ClinicAccountModel ToClinicModel(this UpdateClinicAccountRequest request)
        {
            var model = new ClinicAccountModel
            {
                RegisterId = request.RegisterId,
                Approved = request.Approved,
                ClinicId = request.ClinicId,
            };
            return model;
        }
    }
}
