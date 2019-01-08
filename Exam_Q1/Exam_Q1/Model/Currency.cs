using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Q1.Model
{
    public class Currency
    {
        [Key]
        public string Id { get; set; }
        public decimal Ratio { get; set; }
    }
}
