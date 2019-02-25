using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongResource_181213.Models
{
    public class Song
    {
        public Song()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = SongStatus.Active;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Singer { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Link { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public SongStatus Status { get; set; }
        public ICollection<SongPlaylist> SongPlaylists { get; set; }
    }
    public enum SongStatus
    {
        Active = 1,
        Inactive = 0
    }
}
