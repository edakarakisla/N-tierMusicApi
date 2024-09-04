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
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MusicService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            
        }


        public async Task<Track> CreateMusic(Track NewTrack)
        {
            await _unitOfWork.Musics.AddAsync(NewTrack);
            await _unitOfWork.CommitAsync();
            return NewTrack;
        }

        public async Task Delete(Track track)
        {
            _unitOfWork.Musics.Remove(track);
            await _unitOfWork.CommitAsync();
            

        }

        public async Task<IEnumerable<Track>> GetAllWithArtist()
        {
               return await _unitOfWork.Musics.GetAllWithArtistAsync();
        }

        public async Task<IEnumerable<Track>> GetMusicByArtistId(int artisid)
        {
            return await _unitOfWork.Musics.GetAllWithArtistByartistIdAsync(artisid);
        }

        public async Task<Track> GetMusicById(int id)
        {
           return await _unitOfWork.Musics.GetByIDAsync(id);
        }

        public async Task UpdateTrack(Track trackToBeupdate, Track track)
        {
            trackToBeupdate.Name=track.Name;
            trackToBeupdate.ArtistID=track.ArtistID;
            await _unitOfWork.CommitAsync();
        }
    }
}
