using GameApp.Application.Common.Interfaces;
using GameApp.Domain.Entities;
using MediatR;

namespace GameApp.Application.GameLists.Commands;

public sealed record CreateGameListCommand : IRequest<GameList>
{
    public string Title { get; set; }

    public string Description { get; set; }
}

public sealed class CreateGameListCommandHandler : IRequestHandler<CreateGameListCommand, GameList>
{
    private readonly IApplicationDbContext _context;

    public CreateGameListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GameList> Handle(CreateGameListCommand request, CancellationToken cancellationToken)
    {
        var gameList = new GameList()
        {
            Title = request.Title,
            Description = request.Description,
        };

        _context.GameLists.Add(gameList);
        await _context.SaveChangesAsync(cancellationToken);

        return gameList;
    }
}
