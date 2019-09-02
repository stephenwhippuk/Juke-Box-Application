using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// add additional EF DEPENDENCOES
using Microsoft.EntityFrameworkCore;

namespace MyJukeBox.Models
{
    public class JukeBoxContext :DbContext
    {
        public JukeBoxContext(DbContextOptions<JukeBoxContext> options) : base(options)
        {}

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Release> Releases { get; set; }
    }
}
