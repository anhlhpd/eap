using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongResource_181213.Models
{
    public class Playlist
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SongPlaylist> SongPlaylists { get; set; }
    }
}
