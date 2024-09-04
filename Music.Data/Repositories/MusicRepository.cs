using Microsoft.EntityFrameworkCore;
using Music.Core.Model;
using Music.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data.Repositories
{
    public class MusicRepository : Repository<Track>, IMusicRepository
    {
        public MusicRepository(MusicDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Track>> GetAllWithArtistAsync()
        {
            return await MusicDbContext.Musics
                  .Include(x => x.Artist)
                  .ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetAllWithArtistByartistIdAsync(int artistid)
        {
            return await MusicDbContext.Musics
                  .Include(x => x.Artist)
                  .Where(x => x.ArtistID == artistid).ToListAsync();

        }

        public async Task<Track> GetWithArtistByIdAsync(int id)
        {
            return await MusicDbContext.Musics
               .Include(x => x.Artist)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        private MusicDbContext MusicDbContext
        {
            get
            {
                return Context as MusicDbContext;    //Cast ediyoruz

            }
        }
    }
}
