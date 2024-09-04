
using Microsoft.EntityFrameworkCore;
using Music.Core;
using Music.Core.Services;
using Music.Data;
using MusicServices;

namespace Music.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MusicDbContext>(options =>
            {
                options.UseSqlServer
                (builder.Configuration.GetConnectionString
                ("connectionString"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  // HER AYRI KULLANICIDA ÇALIÞIYOR
            builder.Services.AddTransient<IMusicService, MusicService>();
            builder.Services.AddTransient<IArtistService, ArtistService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
