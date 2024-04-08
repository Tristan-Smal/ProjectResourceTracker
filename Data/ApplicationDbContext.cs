using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResourceTracker.Models;

namespace ResourceTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ResourceTracker.Models.Project>? Project { get; set; }
        public DbSet<ResourceTracker.Models.Resource>? Resource { get; set; }
    }
}