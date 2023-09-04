namespace Minesweeper.Tests;

public class PositionTests
{
    [Fact]
    public void Position_InitializesCorrectly_And_ToString_Works()
    {
        var position = new Position(2, 3);
        Assert.Equal(2, position.X);
        Assert.Equal(3, position.Y);
        Assert.Equal("C4", position.ToString());
    }

    [Theory]
    [InlineData("up", 2, 2)]
    [InlineData("down", 2, 4)]
    [InlineData("left", 1, 3)]
    [InlineData("right", 3, 3)]
    public void Position_MovesCorrectly(string direction, int expectedX, int expectedY)
    {
        var position = new Position(2, 3);
        position.Move(direction);
        Assert.Equal(expectedX, position.X);
        Assert.Equal(expectedY, position.Y);
    }
}