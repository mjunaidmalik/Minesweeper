
namespace Minesweeper;

public class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        // Convert 0-based index to chess notation (e.g., A1, B2)
        char column = (char)(65 + X);
        return $"{column}{Y + 1}";
    }

    public void Move(string direction)
    {
        switch (direction.ToLower())
        {
            case "up":
                if (Y > 0) Y--;
                break;
            case "down":
                if (Y < 7) Y++;
                break;
            case "left":
                if (X > 0) X--;
                break;
            case "right":
                if (X < 7) X++;
                break;
        }
    }
}