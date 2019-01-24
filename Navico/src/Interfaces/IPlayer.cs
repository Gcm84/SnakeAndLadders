namespace Navico.Models
{
    public interface IPlayer
    {
        int CurrentSquare { get; set; }
        string Name { get; set; }
        void MoveToken(int squaresToMove);
    }
}