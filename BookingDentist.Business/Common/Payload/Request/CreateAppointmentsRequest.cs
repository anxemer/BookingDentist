using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class CreateAppointmentsRequest
    {
        public int ServiceId { get; set; }
        public int AccountId { get; set; }
        public int DentistId { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
    public static class CreateAppointmentsExtention
    {
        public static AppointmentModel ToAppointmentModel(this CreateAppointmentsRequest model)
        {
            var appModel = new AppointmentModel
            {
                ServiceId = model.ServiceId,
                AccountId = model.AccountId,
                DentistId = model.DentistId,
                Time = model.Time,
                Status = model.Status,
                Date = model.Date,
            };
            return appModel;

        }
    }
}
