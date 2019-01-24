namespace Navico.Models
{
    public class GameBoard : IGameBoard
    {

        public int _numberOfSquares { get; set; }
        public int _winnerSquare { get; set; }

        //There could be more than one ITokenMoveValidators, we would iterate through them to check if the move is valid.
        //private ITokenMoveValidator _tokenMoveValidator;

        public GameBoard(IGameConfiguration gameConfiguration)
        {
            Initialise(gameConfiguration);
        }

        /// <summary>
        /// Method for initialising the snakes and ladders on the board as well as the NumberOfSquares and the WinnerSquare.
        /// </summary>
        /// <param name="configuration"></param>
        public void Initialise(IGameConfiguration configuration)
        {
            _winnerSquare = configuration.NumberOfSquares;
            //This method would also need to include the initializaion of snakes and ladders
        }

        /// <summary>
        ///This method would check the square where the token is and determine if it's a snake, ladder or normal square and return the new position the token would need to move to
        /// </summary>
        /// <param name="player"></param>
        /// <param name="diceRoll"></param>
        /// <returns></returns>
        public int GetTokenPosition(int currentSquare, int diceRoll)
        {
            // We could potentially use the ITokenMoveValidators here to determine where the token needs to go.
            // Since for Feature 1 we don't need to take into account Snakes and Ladders, this method just returns the current position plus dice roll.
            // We could have different strategies depending on the type of square the player lands on.
            var newPosition = currentSquare + diceRoll;
            return newPosition > _winnerSquare ? currentSquare : newPosition;     
        }
    }
}
