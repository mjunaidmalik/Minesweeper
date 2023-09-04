namespace Minesweeper;

public interface IGameFactory
{
    Board GetNewBoard();
    Player GetNewPlayer();
}

public class GameFactory : IGameFactory
{
    private readonly AppSettings _appSettings;

    public GameFactory(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public Board GetNewBoard()
    {
        return new Board(_appSettings.Size, _appSettings.MineCount);
    }

    public Player GetNewPlayer()
    {
        return new Player(_appSettings.InitialLives);
    }
}