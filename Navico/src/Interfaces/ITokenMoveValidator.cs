namespace Navico.Models
{
    /// <summary>
    /// Code not in use but left as an example of having different validators for the token move
    /// </summary>
    public interface ITokenMoveValidator
    {
        bool IsMoveValid(IPlayer player, int DiceRoll);
    }
}
