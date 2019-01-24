namespace Navico.Models
{
    public interface IGameController
    {
        void Initialise(IGameConfiguration gameConfiguration);
        bool IsEndOfGame(int playerSquare);
        IPlayer NextPlayer(IPlayer player);
        void MoveToken(IPlayer player, int DiceRoll);
        IPlayer GetStartingPlayer();
    }
}