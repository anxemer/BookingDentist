using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.DataAccess
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClinicId { get; set; }
        [ForeignKey("ClinicId")]
        public Clinic Clinic { get; set; }

        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public RegistrationPackage RegistrationPackage { get; set; }

        public string TransMethod { get; set; }
        public string Status { get; set; }

    }
}
