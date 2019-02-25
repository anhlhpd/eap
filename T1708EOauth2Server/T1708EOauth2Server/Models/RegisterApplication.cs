using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1708EOauth2Server.Models
{
    public class RegisterApplication
    {
        public RegisterApplication()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = 1;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string RedirectUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int Status { get; set; }

        
    }
}
