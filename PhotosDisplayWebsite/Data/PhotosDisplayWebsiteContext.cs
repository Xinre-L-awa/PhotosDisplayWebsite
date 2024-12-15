using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotosDisplayWebsite.Models;

namespace PhotosDisplayWebsite.Data
{
    public class PhotosDisplayWebsiteContext : DbContext
    {
        public PhotosDisplayWebsiteContext (DbContextOptions<PhotosDisplayWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<PhotosDisplayWebsite.Models.Image> Image { get; set; } = default!;
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
