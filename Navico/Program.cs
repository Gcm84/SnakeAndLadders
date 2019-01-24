using Microsoft.Extensions.DependencyInjection;
using Navico.Models;

namespace Navico.src
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {

            SetUpDependencyInjection();
            var game = _serviceProvider.GetService<IGame>();
            game.Start();
        }

        static void SetUpDependencyInjection()
        {

            _serviceProvider = new ServiceCollection()
                .AddSingleton<IGameController, GameController>()
                .AddSingleton<IGameBoard, GameBoard>()
                .AddSingleton<IGameConfiguration, GameConfiguration>()
                .AddSingleton<IGame, Game>()
            .BuildServiceProvider();

        }
    }
}
