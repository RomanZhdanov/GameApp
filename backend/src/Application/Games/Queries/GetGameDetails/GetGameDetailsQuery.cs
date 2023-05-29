using GameList.Application.Common.Interfaces;
using GameList.Domain.Entities;
using MediatR;

namespace GameList.Application.Games.Queries.GetGameDetails
{
    public sealed record GetGameDetailsQuery : IRequest<Game>
    {
        public int GameId { get; set; }
    }

    public sealed class GetGameDetailsQueryHandler : IRequestHandler<GetGameDetailsQuery, Game>
    {
        private readonly IGamesDbService _gamesDb;

        public GetGameDetailsQueryHandler(IGamesDbService gamesDb)
        {
            _gamesDb = gamesDb;
        }

        public async Task<Game> Handle(GetGameDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _gamesDb.GetGameAsync(request.GameId);
        }
    }
}
