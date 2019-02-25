using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1708EOauth2Server.Models
{
    public class AuthorizationCode
    {
        public AuthorizationCode(Credential credential)
        {
            this.Code = Guid.NewGuid().ToString();
            this.Credential = credential;
            this.CreatedAt = DateTime.Now;
            this.ExpiredAt = DateTime.Now.AddMinutes(5);
        }
        public string Code { get; set; }
        public Credential Credential { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
