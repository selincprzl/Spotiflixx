using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotiflixx
{
    internal class Data
    {
        public List<Movie> MovieList { get; set; } = new();
       public List<Series> SeriesList { get; set; } = new();
        public List<Music> AlbumList { get; set; } = new();


    }
}
