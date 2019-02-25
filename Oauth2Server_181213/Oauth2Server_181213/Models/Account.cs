using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oauth2Server_181213.Models
{
    public class Account
    {
        public Account()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = AccountStatus.Active;
        }
        [Key]
        public long Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public AccountStatus Status { get; set; }
        public UserInformation UserInformation { get; set; }
    }

    public enum AccountStatus
    {
        Active = 1,
        Deactive = 0
    }

    public PasswordEncrypt()
    {
        this.
    }
}
