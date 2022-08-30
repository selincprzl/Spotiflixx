using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotiflixx
{
    internal class Series
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string? WWW { get; set; }

        public List<Episode> EpisodesList { get; set; } = new();
    }
   

    internal class Episode
    {
        public string? Title { get; set; }
        public DateTime RelaseDate { get; set; }
        public int Season { get; set; }
        public int EpisodeNum { get; set; } 
        public DateTime Length { get; set; }

    }
}
