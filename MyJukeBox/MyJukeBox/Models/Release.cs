﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJukeBox.Models
{
    public enum ReleaseType { Single, EP, Album}
    public enum PerformanceTytpe { Studio, Live}
    public class Release
    {
        public int ReleaseID { get; set; }

        public string Title { get; set; }
        public DateTime releaseDate { get; set; }
        public ReleaseType releaseType { get; set; }
        public PerformanceTytpe performanceType { get; set; }

        public string ThumbnailURL { get; set; }
        public string CoverUrl { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
