using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exam_Q1.Model;

namespace Exam_Q1.Models
{
    public class Exam_Q1Context : DbContext
    {
        public Exam_Q1Context(DbContextOptions<Exam_Q1Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(new Currency() {
                Id = "USD",
                Ratio = 23260
            },
            new Currency()
            {
                Id = "EUR",
                Ratio = 27061
            },
            new Currency()
            {
                Id = "AUD",
                Ratio = 16798
            },
            new Currency()
            {
                Id = "JPY",
                Ratio = 20704
            }
            );
        } 

        public DbSet<Exam_Q1.Model.Currency> Currency { get; set; }
    }
}
