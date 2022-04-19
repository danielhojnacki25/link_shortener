using LinkShortener.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Link> Links { get; set; } = null!;
}