namespace Minesweeper;

public class Board
{
    public int Size { get; }
    public Position PlayerPosition { get; private set; }
    public HashSet<Position> Mines { get; }

    public Board(int size, int minesCount)
    {
        Size = size;
        PlayerPosition = new Position(0, 0); // Start at top-left
        Mines = GenerateMines(minesCount);
    }

    private HashSet<Position> GenerateMines(int minesCount)
    {
        var mines = new HashSet<Position>();
        var random = new Random();

        while (mines.Count < minesCount)
        {
            int x = random.Next(0, Size);
            int y = random.Next(0, Size);

            var position = new Position(x, y);
            if (!position.Equals(PlayerPosition))
            {
                mines.Add(position);
            }
        }

        return mines;
    }

    public bool MovePlayer(string direction)
    {
        PlayerPosition.Move(direction);
        return Mines.Contains(PlayerPosition);
    }
}