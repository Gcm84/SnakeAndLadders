using System;

namespace Navico.Models
{
    public class Game : IGame
    {
        public IPlayer _currentPlayer;
        public bool _isEndOfGame { get; private set; }

        private IGameController _gameController;
        private IDice _dice;

        public Game(IGameConfiguration gameConfiguration, IGameController gameController)
        {
            _gameController = gameController;
            _isEndOfGame = false;
            Initialize(gameConfiguration); 
        }

        public void Start()
        {
            while (!_isEndOfGame)
            {
                DisplayPlayersTurn();
                _gameController.MoveToken(_currentPlayer, _dice.Roll());
                DisplayPlayersPosition();
                _isEndOfGame = _gameController.IsEndOfGame(_currentPlayer.CurrentSquare);

                if (_isEndOfGame)
                {
                    DisplayEndOfGameMessage();
                    Console.ReadLine();
                }
                else
                {
                    _currentPlayer = _gameController.NextPlayer(_currentPlayer);
                    Console.WriteLine();
                }
            }
        }

        public void Initialize(IGameConfiguration gameConfiguration)
        {
            _gameController.Initialise(gameConfiguration);
            _dice = new Dice(1, 6);
            _currentPlayer = _gameController.GetStartingPlayer();
        }

        private void DisplayEndOfGameMessage()
        {
            Console.WriteLine($"{_currentPlayer.Name} wins the game");
        }

        private void DisplayPlayersTurn()
        {
            Console.WriteLine($"It is {_currentPlayer.Name} turn");
        }

        private void DisplayPlayersPosition()
        {
            Console.WriteLine($"{_currentPlayer.Name} is at square {_currentPlayer.CurrentSquare}");
        }
    }
}
