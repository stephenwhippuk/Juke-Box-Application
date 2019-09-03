using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJukeBox.ViewModels
{
    public class SelectedArtist
    {
        public IEnumerable<Models.Artist> Artists { get; set; }
       public string SelectedName{ get; set; }
        public int SelectedId { get; set; }

    }
}
