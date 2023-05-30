using GameApp.Application.Common.Interfaces;
using GameApp.Application.Common.Models;
using GameApp.Domain.Entities;
using RawgSharp;

namespace GameApp.Infrastructure.Services;

public class GamesDbService : IGamesDbService
{
    private readonly IRawgApi _rawgApi;

    public GamesDbService(IRawgApi rawgApi)
    {
        _rawgApi = rawgApi;
    }

    public async Task<Game> GetGameAsync(int gameId)
    {
        var game = await _rawgApi.GetGameDetails(gameId);

        return new Game
        {
            Id = game.Id,
            Title = game.Name
        };
    }

    public async Task<PaginatedList<Game>> GetGamesPageAsync(int page, int pageSize, string search)
    {
        var response = await _rawgApi.GetListOfGamesAsync(page, pageSize, search);
        var items = response.Results.Select(r => new Game
        {
            Id = r.Id,
            Title = r.Name
        });
        return new PaginatedList<Game>(
            items,
            response.Count,
            page,
            pageSize);
    }
}
