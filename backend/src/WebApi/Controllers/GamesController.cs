using GameList.Application.Common.Models;
using GameList.Application.Games.Queries.GetGameDetails;
using GameList.Application.Games.Queries.GetGamesWithPagination;
using GameList.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameList.WebApi.Controllers
{
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
}
