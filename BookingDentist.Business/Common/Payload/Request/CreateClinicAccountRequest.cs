using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class CreateClinicAccountRequest
    {
        public int Id { get; set; }
        public int RegisterId { get; set; }
        public bool? Approved { get; set; }
        public int ClinicId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
    public static class ClinicAccountExtentionRequest 
    {
        public static ClinicAccountModel ToClinicAccountModel(this ClinicAccountModel model)
        {
            var clinicAccount = new ClinicAccountModel
            {
                Id = model.Id,
                Account = model.Account,
                Approved = model.Approved,
                ClinicId = model.ClinicId,
                CreateAt = model.CreateAt,
                IsDeleted = model.IsDeleted,
                RegisterId = model.RegisterId,
                UpdateAt = model.UpdateAt,

            };
            return clinicAccount;
        }
    }
}
