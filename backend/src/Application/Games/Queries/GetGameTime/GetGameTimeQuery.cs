using GameApp.Application.Common.Interfaces;
using MediatR;

namespace GameApp.Application.Games.Queries.GetGameTime
{
    public record GetGameTimeQuery : IRequest<string>
    {
        public string GameName { get; set; }
    }

    public class GetGameTimeQueryHandler : IRequestHandler<GetGameTimeQuery, string>
    {
        private readonly IHowLongToBeatService _howLongToBeat;
        
        public GetGameTimeQueryHandler(IHowLongToBeatService howLongToBeat)
        {
            _howLongToBeat = howLongToBeat;
        }

        public Task<string> Handle(GetGameTimeQuery request, CancellationToken cancellationToken)
        {
            var value = _howLongToBeat.GetGame(request.GameName);

            return Task.FromResult(value);
        }
    }
}
