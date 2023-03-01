using Microsoft.EntityFrameworkCore;
using PickItEasy.Domain;

namespace PickItEasy.Application.Interfaces
{
    public interface IPickItEasyDbContext
    {
        public DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
