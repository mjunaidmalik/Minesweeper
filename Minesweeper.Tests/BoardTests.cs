namespace Minesweeper.Tests;

public class BoardTests
{

    private readonly AppSettings _appSettings;

    public BoardTests()
    {
        _appSettings= new AppSettings(){InitialLives = 2, MineCount = 10, Size = 8};
    }

    [Fact]
    public void Board_InitializesCorrectly_WithCorrectMineCount()
    {
        int size = _appSettings.Size;
        int minesCount = _appSettings.MineCount;
        var board = new Board(size, minesCount);
        Assert.Equal("A1", board.PlayerPosition.ToString());
        Assert.Equal(minesCount, board.Mines.Count);
    }

    [Fact]
    public void Board_MovesPlayer_And_DetectsMinesCorrectly()
    {
        var board = new Board(8, 10);
        bool hitMine = board.MovePlayer("down");
        Assert.Equal("A2", board.PlayerPosition.ToString());
    }
}