using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T1708EOauth2Server.Models
{
    public class UserInformation
    {
        [Key]
        public long AccountId { get; set; }
        public string FullName { get; set; }
        [Display(Name = "Birthday")]
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }

        public Account Account { get; set; }
    }
}
