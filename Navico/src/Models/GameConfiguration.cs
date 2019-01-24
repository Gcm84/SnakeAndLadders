using System.Collections.Generic;

namespace Navico.Models
{
    public class GameConfiguration: IGameConfiguration
    {
        public List<Player> Players { get => new List<Player>{
                    new Player{Name = "Player 1", CurrentSquare = 1 },
                    new Player{Name = "Player 2", CurrentSquare = 1 }
                };
        }

        public int NumberOfSquares { get => 100; }
        public int WinnerSquare { get => 100; }

        // For the next Features in the game, these properties (could potentially only be one property) would have the connections betweeen squares to go up and down.
        // This configuration would be used by the GameBoard
        //public List<Squares> Snakes;
        //public List<Squares> Ladders;

    }
}
