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
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MusicDbContext context):base(context)
        {
            
        }
        public async Task<IEnumerable<Artist>> GetAllMusicAsync()
        {
            return await MusicDbContext.Artists
                .Include(x=> x.Musics)
                .ToListAsync();
        }

        public Task<Artist> GetWithMusicByIdAsync(int id)
        {
            return MusicDbContext.Artists
                .Include(x=> x.Musics)
                .SingleOrDefaultAsync(x=> x.Id == id);
        }
        private MusicDbContext MusicDbContext
        {
            get { return Context as MusicDbContext; }
        }
    }
}
