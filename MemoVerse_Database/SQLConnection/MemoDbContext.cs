using MemoVerse_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoVerse_Database.SQLConnection;

public class MemoDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }
    public MemoDbContext(DbContextOptions<MemoDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
