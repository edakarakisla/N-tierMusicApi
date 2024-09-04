using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Core.Model
{
    public class Artist
    {
        public Artist()
        {
            Musics= new Collection<Track>();  // Garantiye alma
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public  ICollection<Track>Musics { get; set; }  // Bire-çok ilişki yaptık!! ?Nonable demek

    }
}
