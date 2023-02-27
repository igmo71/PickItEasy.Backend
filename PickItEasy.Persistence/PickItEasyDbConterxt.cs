using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain;
using PickItEasy.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Persistence
{
    public class PickItEasyDbConterxt : DbContext, IPickItEasyDbContext
    {
        public PickItEasyDbConterxt(DbContextOptions<PickItEasyDbConterxt> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
