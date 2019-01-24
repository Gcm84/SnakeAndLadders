using System.Collections.Generic;

namespace Navico.Models
{
    public interface IGameConfiguration
    {
        List<Player> Players { get; }
        int NumberOfSquares { get; }
        int WinnerSquare { get; }
        //public List<Squares> Snakes;
        //public List<Squares> Ladders;
    }
}