
namespace Minesweeper;

public class Player
{
    public int Lives { get; private set; }
    public int Moves { get; private set; }

    public Player(int initialLives = 3)
    {
        Lives = initialLives;
        Moves = 0;
    }

    public void Move()
    {
        Moves++;
    }

    public void HitMine()
    {
        Lives--;
    }
}