namespace Navico.Models
{
    public interface IGameBoard
    {
        int _numberOfSquares { get; set; }
        int _winnerSquare { get; set; }
        void Initialise(IGameConfiguration configuration);
        int GetTokenPosition(int CurrentSquare, int DiceRoll);
    }
}