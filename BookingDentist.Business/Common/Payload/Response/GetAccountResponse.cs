using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Response
{
    public class GetAccountResponse
    {
        public IEnumerable<AccountModel> Account { get; set; } = new List<AccountModel>();
    }
}
