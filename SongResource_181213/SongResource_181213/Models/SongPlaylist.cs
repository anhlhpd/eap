using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongResource_181213.Models
{
    public class SongPlaylist
    {
        public long Id { get; set; }
        public Song Song { get; set; }
        public Playlist Playlist { get; set; }
    }
}
