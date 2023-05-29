using GameApp.Application.Common.Models;
using GameApp.Domain.Entities;

namespace GameApp.Application.Common.Interfaces
{
    public interface IGamesDbService
    {
        Task<PaginatedList<Game>> GetGamesPageAsync(int page, int pageSize, string search);

        Task<Game> GetGameAsync(int gameId);
    }
}
