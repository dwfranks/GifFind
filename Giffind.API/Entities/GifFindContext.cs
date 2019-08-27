using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace GifFind.API.Entities
{
    public class GifFindContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SavedImage> SavedImages { get; set; }
        public DbSet<SavedOriginal> SavedOriginals { get; set; }
        public DbSet<SavedOriginalStill> SavedOriginalStills { get; set; }
        public DbSet<SavedPreviewGif> SavedPreviewGifs { get; set; }

        public GifFindContext(DbContextOptions<GifFindContext> options) 
            : base(options)
        {}


    }
}
