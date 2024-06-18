using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class UpdateAccountRequest
    {
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public DateTime DOB { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? CCCDIdentificationNumber { get; set; }
        public string? CCCDFrontImage { get; set; }
        public string? CCCDBackImage { get; set; }
        public DateTime CCCDDateRegistration { get; set; }
        public string?  Role { get; set; }
    }
}
