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
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService artistService;
        private readonly IMapper mapper;
        public ArtistController(IArtistService _artistservice, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.artistService = _artistservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> GetAllArtist()
        {
            var artist = await this.artistService.GetAllArtists();
            var artistResources = mapper.Map<IEnumerable<Artist>,
                IEnumerable<ArtistDTO>>(artist);
            return Ok(artistResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDTO>> GetArtistById(int id)
        {
            var artist = await artistService.GetArtistById(id);
            if (artist == null)
                return NotFound();
            var artisResources = mapper.Map<Artist, ArtistDTO>
                (artist);
            return Ok(artisResources);
        }
        [HttpPost]
        public async Task<ActionResult<ArtistDTO>> CreateArtist([FromBody] SaveArtistDTO SaveartistResources)
        {
            var validator = new SaveArtistResourcesValidator();
            var validatorResult = await validator.ValidateAsync(SaveartistResources);
            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);
            var artistTocreate = mapper.Map<SaveArtistDTO, Artist>(SaveartistResources);
            var newArtist = await artistService.CreateArtist(artistTocreate);
            var artist = await artistService.GetArtistById(newArtist.Id);
            var artistResources = mapper.Map<Artist, ArtistDTO>(artist);
            return Ok(artistResources);


        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArtistDTO>> updateArtist(int id, SaveArtistDTO saveArtistResources)
        {
            var validator = new SaveArtistResourcesValidator();
            var validatorResult = await validator.ValidateAsync(saveArtistResources);
            if (!validatorResult.IsValid) return BadRequest();
            var artistToUpdate = await artistService.GetArtistById(id);
            if (artistToUpdate == null) return NotFound();
            var artist = mapper.Map<SaveArtistDTO, Artist>(saveArtistResources);
            await artistService.UpdateArtist(artistToUpdate, artist);
            var updatedArtist = await artistService.GetArtistById(artist.Id);
            var updatedArtistResource = mapper.Map<Artist, ArtistDTO>(updatedArtist);
            return Ok(updatedArtistResource);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await artistService.GetArtistById(id);
            if (artist == null) return NotFound();
            await artistService.DeleteArtist(artist);
            return NoContent();
        }








    }
}
