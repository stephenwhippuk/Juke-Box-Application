﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJukeBox.Models
{
    public class Track
    {
        public int TrackID { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public float Duration { get; set; }

        public string ImageURL { get; set; }
    }
}
