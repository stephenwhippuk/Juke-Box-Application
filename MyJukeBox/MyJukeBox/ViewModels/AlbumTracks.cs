using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJukeBox.ViewModels
{
    /// <summary>
    /// View Model to list the album details and the tracks on it.
    /// </summary>
    public class AlbumTracks
    {
        public String Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Models.Track> Tracks { get; set; }
    }
}
