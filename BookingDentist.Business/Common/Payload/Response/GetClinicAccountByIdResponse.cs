using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Response
{
    public class GetClinicAccountByIdResponse
    {
        public ClinicAccountModel ClinicAccount { get; set; }
    }
}
