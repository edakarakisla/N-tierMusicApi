using Music.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Core.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<Track>> GetAllWithArtist();
        Task<Track> GetMusicById(int id);
        Task<IEnumerable<Track>> GetMusicByArtistId(int artisid);
        Task<Track>CreateMusic(Track NewTrack);
        Task UpdateTrack(Track trackToBeupdate, Track track);
        Task Delete(Track track);
    }
}
