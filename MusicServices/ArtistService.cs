using Music.Core;
using Music.Core.Model;
using Music.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServices
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork unitOfWork;
        public ArtistService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Artist> CreateArtist(Artist Newartist)
        {
            await unitOfWork.Artists.AddAsync(Newartist);
            return Newartist;
        }

        public async Task DeleteArtist(Artist artist)
        {
            unitOfWork.Artists.Remove(artist);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
           return await unitOfWork.Artists.GetAllAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            return await unitOfWork.Artists.GetByIDAsync(id);
        }

        public async Task UpdateArtist(Artist ArtistToBeUpdate, Artist artist)
        {
            ArtistToBeUpdate.Name= artist.Name;
            await unitOfWork.CommitAsync();
        }
    }
}
