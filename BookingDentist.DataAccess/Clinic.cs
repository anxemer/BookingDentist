using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.DataAccess
{
    public class Clinic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [ForeignKey("RegistrationPackageId")]
        public RegistrationPackage RegistrationPackage { get; set; }

    }
}
