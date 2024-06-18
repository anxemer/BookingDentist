using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class CreateClinicRequest
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ClinicPhone { get; set; }
        public string License { get; set; }
        public DateTime ExpDate { get; set; }
        public string OperationHours { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public int RegistrationPackageId { get; set; }
    }
    public static class CreateClinicRequestExtention
    {
        public static ClinicModel ToClinicModel(this CreateClinicRequest request)
        {
            var model = new ClinicModel
            {
                Id = request.Id,
                Image = request.Image,
                Name = request.Name,
                Address = request.Address,
                ClinicPhone = request.ClinicPhone,
                License = request.License,
                OperationHours = request.OperationHours,
                Status = request.Status,
                CreateAt = request.CreateAt,
                UpdateAt = request.UpdateAt,
                IsDeleted = request.IsDeleted,
                RegistrationPackageId = request.RegistrationPackageId,
                ExpDate = request.ExpDate,
            };
            return model;
        }
    }
}
