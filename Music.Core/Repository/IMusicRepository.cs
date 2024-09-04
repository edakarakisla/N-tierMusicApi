using Music.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Core.Repository
{
    public interface IMusicRepository : IRepository<Track>
    {
        Task<IEnumerable<Track>> GetAllWithArtistAsync();
        Task <Track>GetWithArtistByIdAsync(int id);
        Task<IEnumerable<Track>> GetAllWithArtistByartistIdAsync(int artistid);

    }
}
