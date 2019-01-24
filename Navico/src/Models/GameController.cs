using System.Collections.Generic;

namespace Navico.Models
{
    public class GameController : IGameController
    {
        private IGameBoard _gameBoard;
        private int _winnerSquare { get; set; }
        private Queue<IPlayer> _players { get; set; }

        public GameController(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public void Initialise(IGameConfiguration gameConfiguration)
        {
            _winnerSquare = gameConfiguration.WinnerSquare;
            _players = new Queue<IPlayer>(gameConfiguration.Players);
            _gameBoard.Initialise(gameConfiguration);
        }

        public bool IsEndOfGame(int playerSquare)
        {
            return playerSquare == _winnerSquare;
        }

        public void MoveToken(IPlayer player, int diceRoll)
        {
            var newPosition = _gameBoard.GetTokenPosition(player.CurrentSquare, diceRoll);
            player.MoveToken(newPosition);
        }

        /// <summary>
        /// If there is only one player, we queue the current player before dequeing the next one.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public IPlayer NextPlayer(IPlayer player)
        {
            _players.Enqueue(player);
            return _players.Dequeue();
        }

        /// <summary>
        /// This method could be used in other Features to have a more random way of selecting the player who plays first
        /// </summary>
        /// <returns></returns>
        public IPlayer GetStartingPlayer()
        {
            return _players.Dequeue();
        }
    }
}
