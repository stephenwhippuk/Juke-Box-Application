using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJukeBox.ViewModels
{
    public class ArtistReleases
    {
        public string Artist { get; set; }
        public ICollection<Models.Release> Releases { get; set; }
    }
}
