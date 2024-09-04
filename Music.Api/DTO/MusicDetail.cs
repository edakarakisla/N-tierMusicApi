namespace Music.Api.DTO
{
    public class MusicDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ArtistDTO Artist { get; set; }
    }
}
