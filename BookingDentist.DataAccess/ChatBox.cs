using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.DataAccess
{
    public class ChatBox
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Account Account { get; set; }

        public int DentistId { get; set; }
        [ForeignKey("DentistId")]
        public Dentist Dentist { get; set; }
        
        public string ChatContent { get; set; }
        public string Time { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }

    }
}
