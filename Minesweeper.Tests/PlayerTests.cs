namespace Minesweeper.Tests;

public class PlayerTests
{
    [Fact]
    public void Player_UpdatesMoveCountAndLivesCorrectly()
    {
        var player = new Player(3);
        Assert.Equal(0, player.Moves);
        Assert.Equal(3, player.Lives);
        
        player.Move();
        Assert.Equal(1, player.Moves);
        
        player.HitMine();
        Assert.Equal(2, player.Lives);
    }
}