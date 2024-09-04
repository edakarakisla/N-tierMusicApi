using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Music.Core.Model;
using Music.Data.Configiration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {

           

        }
        public DbSet<Track>Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfigiration());

        }

    }
}
