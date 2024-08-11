using Microsoft.EntityFrameworkCore;

namespace GumroadDotNet.Data;

public class GumroadDotNetContext : DbContext
{
    public GumroadDotNetContext (DbContextOptions<GumroadDotNetContext> options)
            : base(options)
        {
        }
        public DbSet<GumroadDotNet.Models.Product> Product { get; set; } = default!;
}