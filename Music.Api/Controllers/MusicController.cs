using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Api.DTO;
using Music.Api.Validators;
using Music.Core.Model;
using Music.Core.Services;

namespace Music.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService musicService;
        private readonly IMapper mapper;
        public MusicController(IMusicService _musicService, IMapper _mapper)
        {
            this.musicService = _musicService;
            this.mapper = _mapper;
        }


        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MusicDetail>>> GetAllMusics()
        {
            var music = await musicService.GetAllWithArtist();
            var musicResourse = mapper.Map<IEnumerable<Track>>(music);
            return Ok(musicResourse);


        }
       [HttpGet("{id}")]
        public async Task<ActionResult<MusicDetail>> GetMusicById(int id)
        {
            var track = await musicService.GetMusicById(id);
            var musicResources = mapper.Map<Track, MusicDetail>(track);
            return Ok(musicResources);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<MusicDetail>> CreateMusic(SaveMusic savemusicResources)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(savemusicResources);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var musicToCreate = mapper.Map<SaveMusic, Track>(savemusicResources);

            var newMusic = await musicService.CreateMusic(musicToCreate);
            var music = await musicService.GetMusicById(newMusic.Id);

            var musicResources = mapper.Map<Track, MusicDetail>(music);
            return Ok(musicResources);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<MusicDetail>> UpdateMusic(int id, SaveMusic saveMusicResources)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResources);
            var requestisInValid = id == 0 || !validationResult.IsValid;
            if (requestisInValid)
                return BadRequest(validationResult.Errors);
            var musicToBeUpdate = await musicService.GetMusicById(id);
            if (musicToBeUpdate == null)
                return NotFound();

            var music = mapper.Map<SaveMusic, Track>(saveMusicResources);
            await musicService.UpdateTrack(musicToBeUpdate, music);
            var updateMusic = await musicService.GetMusicById(id);
            var updateMusicResource = mapper.Map<Track, MusicDetail>(updateMusic);
            return Ok(updateMusicResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            if (id == 0)
                return BadRequest();
            var music = await musicService.GetMusicById(id);
            if (music == null)
                return NotFound();

            await musicService.Delete(music);
            return NoContent();
        }
    }
}
