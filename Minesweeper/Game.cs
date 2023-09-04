
namespace Minesweeper;

public class Game : IGame
{
    private readonly Board _board;
    private readonly Player _player;

    public Game(IGameFactory factory)
    {
        _board = factory.GetNewBoard();
        _player = factory.GetNewPlayer();
    }

    public void Run()
    {
        Console.WriteLine($"Welcome to Minesweeper! Start at {_board.PlayerPosition}.");
        Console.WriteLine($"You have {_player.Lives} lives. Reach the other side to win.");

        while (_player.Lives > 0 && !HasReachedEnd())
        {
            Console.Write("Enter move direction (up, down, left, right): ");
            var move = Console.ReadLine();

            bool hitMine = _board.MovePlayer(move);
            _player.Move();

            if (hitMine)
            {
                _player.HitMine();
                Console.WriteLine($"You hit a mine at {_board.PlayerPosition}! Lives left: {_player.Lives}");
            }

            if (_player.Lives == 0)
            {
                Console.WriteLine($"Game Over! Total moves: {_player.Moves}");
                break;
            }

            if (HasReachedEnd())
            {
                Console.WriteLine($"Congratulations! You reached the other side in {_player.Moves} moves!");
            }
        }
    }

    public void SimulateMove(string move)
    {
        bool hitMine = _board.MovePlayer(move);
        _player.Move();

        if (hitMine)
        {
            _player.HitMine();
        }
    }

    public bool HasReachedEnd()
    {
        return _board.PlayerPosition.Y == _board.Size - 1;
    }
}