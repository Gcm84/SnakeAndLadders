namespace Navico.Models
{
    public interface IGame
    {
        void Initialize(IGameConfiguration gameConfiguration);
        void Start();
    }
}
