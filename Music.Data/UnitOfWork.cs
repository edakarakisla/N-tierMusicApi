using Music.Core;
using Music.Core.Repository;
using Music.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicDbContext context;
        private IMusicRepository musicRepository;
        private IArtistRepository artistRepository;

        public UnitOfWork(MusicDbContext _context)
        {
            this.context = _context;
        }


        public IMusicRepository Musics =>  musicRepository = musicRepository ?? new MusicRepository(context);  

        public IArtistRepository Artists => artistRepository = artistRepository ?? new ArtistRepository(context);

        public async Task<int> CommitAsync()  // SAVE CHANGE METODU İÇİN
        {
            return await context.SaveChangesAsync();  
        }

        public void Dispose()
        {
          
        }
    }
}
