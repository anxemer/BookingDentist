using BookingDentist.Business.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.Common.Payload.Request
{
    public class CreateAccountRequest
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CCCDIdentificationNumber { get; set; }
        public string CCCDFrontImage { get; set; }
        public string CCCDBackImage { get; set; }
        public DateTime CCCDDateRegistration { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
    public static class AccountRequestExtension
    {
        public static AccountModel ToAccountModel(this CreateAccountRequest model)
        {
            var accountModel = new AccountModel()
            {
                Image = model.Image,
                Name = model.Name,
                Phone = model.Phone,
                DOB = model.DOB,
                Gender = model.Gender,
                Address = model.Address,
                Email = model.Email,
                UserName = model.UserName,
                Password = model.Password,
                CCCDBackImage = model.CCCDBackImage,
                CCCDDateRegistration = model.CCCDDateRegistration,
                Role = model.Role,
                Status = model.Status,
                CCCDFrontImage = model.CCCDFrontImage,
                CCCDIdentificationNumber = model.CCCDFrontImage,
                CreateAt = DateTime.Now,
                IsDeleted = model.IsDeleted,
                UpdateAt = DateTime.Now,

            };
            return accountModel;
        }
    }
}
