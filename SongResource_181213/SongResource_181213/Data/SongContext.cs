using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SongResource_181213.Models
{
    public class SongContext : DbContext
    {
        public SongContext (DbContextOptions<SongContext> options)
            : base(options)
        {
        }

        public DbSet<SongResource_181213.Models.Song> Song { get; set; }
    }
}
