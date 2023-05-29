using GameList.Application.Common.Models;
using GameList.Domain.Entities;

namespace GameList.Application.Common.Interfaces
{
    public interface IGamesDbService
    {
        Task<PaginatedList<Game>> GetGamesPageAsync(int page, int pageSize, string search);

        Task<Game> GetGameAsync(int gameId);
    }
}
