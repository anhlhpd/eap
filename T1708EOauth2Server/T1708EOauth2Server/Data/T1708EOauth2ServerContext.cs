using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using T1708EOauth2Server.Models;

namespace T1708EOauth2Server.Data
{
    public class T1708EOauth2ServerContext : DbContext
    {
        public T1708EOauth2ServerContext (DbContextOptions<T1708EOauth2ServerContext> options)
            : base(options)
        {
        }

        public DbSet<T1708EOauth2Server.Models.Account> Account { get; set; }
        public DbSet<T1708EOauth2Server.Models.UserInformation> UserInformation { get; set; }

        public DbSet<T1708EOauth2Server.Models.Credential> Credential { get; set; }

        public DbSet<T1708EOauth2Server.Models.RegisterApplication> RegisterApplication { get; set; }
    }
}
