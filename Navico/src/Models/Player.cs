namespace Navico.Models
{
    public class Player : IPlayer
    {
        public int CurrentSquare { get; set; }
        public string Name { get; set; }

        public void MoveToken(int squareToMove)
        {
            CurrentSquare = squareToMove;
        }
    }
}
