using GameApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Game> Games { get; }

    DbSet<GameList> GameLists { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
