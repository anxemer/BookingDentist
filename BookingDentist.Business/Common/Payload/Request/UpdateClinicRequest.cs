using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class UpdateClinicRequest
    {
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ClinicPhone { get; set; }
        public string? License { get; set; }
        public DateTime ExpDate { get; set; }
        public string? OperationHours { get; set; }
        public string? Status { get; set; }
        public bool IsDeleted { get; set; }
    }
    public static class UpdateClinicRequestExtention
    {
        public static ClinicModel ToClinicModel(this UpdateClinicRequest request)
        {
            var model = new ClinicModel
            {
                Image = request.Image,
                Name = request.Name,
                Address = request.Address,
                ClinicPhone = request.ClinicPhone,
                License = request.License,
                OperationHours = request.OperationHours,
                Status = request.Status,
                IsDeleted = request.IsDeleted,
                ExpDate = request.ExpDate,
            };
            return model;
        }
    }
}
