using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Extensions.Configuration;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace T1708ESongResource.Models
{
    public class Song
    {
        public Song ()
        {
            this.Status = SongStatus.Active;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public SongStatus Status { get; set; }
    }
}
