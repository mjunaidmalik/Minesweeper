namespace Minesweeper.Tests;

public class GameTests
{
    private readonly IGameFactory _gameFactory;

    public GameTests()
    {
        _gameFactory = new GameFactory(new AppSettings(){InitialLives = 2, MineCount = 10, Size = 8});
    }

    [Fact]
    public void Game_InitializesCorrectly()
    {
        var game = new Game(_gameFactory);

        Assert.NotNull(game);
    }

    [Fact]
    public void Game_DetectsVictory()
    {
        var game = new Game(_gameFactory);

        for (int i = 0; i < 7; i++)
        {
            game.SimulateMove("down");
        }

        Assert.True(game.HasReachedEnd());
    }
}