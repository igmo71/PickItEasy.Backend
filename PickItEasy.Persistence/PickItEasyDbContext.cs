using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain;
using PickItEasy.Persistence.EntityTypeConfigurations;

namespace PickItEasy.Persistence
{
    public class PickItEasyDbContext : DbContext, IPickItEasyDbContext
    {
        public PickItEasyDbContext(DbContextOptions<PickItEasyDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
