using GameApp.Application.Common.Interfaces;
using GameApp.Application.Common.Models;
using GameApp.Domain.Entities;
using MediatR;

namespace GameApp.Application.Games.Queries.GetGamesWithPagination
{
    public sealed record GetGamesWithPaginationQuery : IRequest<PaginatedList<Game>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Search { get; set; }
    }

    public sealed class GetGamesWithPaginationQueryHandler : IRequestHandler<GetGamesWithPaginationQuery, PaginatedList<Game>>
    {
        private readonly IGamesDbService _gamesDb;

        public GetGamesWithPaginationQueryHandler(IGamesDbService gamesDb)
        {
            _gamesDb = gamesDb;
        }

        public async Task<PaginatedList<Game>> Handle(GetGamesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _gamesDb.GetGamesPageAsync(
                request.Page,
                request.PageSize,
                request.Search);
        }
    }
}
