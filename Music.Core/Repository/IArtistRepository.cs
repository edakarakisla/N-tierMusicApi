using Music.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Core.Repository
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllMusicAsync();
        Task<Artist> GetWithMusicByIdAsync(int id);

    }
}
