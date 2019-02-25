using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace T1708ESongResource.Models
{
    public class T1708ESongResourceContext : DbContext
    {
        public T1708ESongResourceContext (DbContextOptions<T1708ESongResourceContext> options)
            : base(options)
        {
        }

        public DbSet<T1708ESongResource.Models.Song> Song { get; set; }
    }
}
