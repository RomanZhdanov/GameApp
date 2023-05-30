using GameApp.Application.Common.Models;
using GameApp.Application.Games.Queries.GetGameDetails;
using GameApp.Application.Games.Queries.GetGamesWithPagination;
using GameApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.WebApi.Controllers;

public class GamesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<Game>>> GetPage(int page, int pageSize)
    {
        return await Mediator.Send(new GetGamesWithPaginationQuery
        {
            Page = page,
            PageSize = pageSize
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var game = await Mediator.Send(new GetGameDetailsQuery
        {
            GameId = id
        });

        if (game == null)
        {
            return NotFound();
        }

        return game;
    }

    [HttpGet("search")]
    public async Task<ActionResult<PaginatedList<Game>>> Search(string search, int page, int pageSize)
    {
        return await Mediator.Send(new GetGamesWithPaginationQuery
        {
            Page = page,
            PageSize = pageSize,
            Search = search
        });
    }
}
