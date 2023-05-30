namespace GameApp.Domain.Entities;

public sealed class GameList
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IList<Game> Games { get; set; }
}
