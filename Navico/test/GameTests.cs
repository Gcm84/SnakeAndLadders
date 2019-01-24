using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using Navico.Models;
using NUnit.Framework;

namespace Navico.test
{
    [TestFixture]
    public class GameTests
    {
        private IFixture _fixture;
        private Mock<IGameController> _gameControllerMock;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _gameControllerMock = _fixture.Freeze<Mock<IGameController>>();
        }

        [Test]
        public void Start_WhenCalled_MustGoThroghThePhasesOfTheGame()
        {
            //Arrange     
            var game = _fixture.Create<Game>();
            game.Initialize(new GameConfiguration());
            _gameControllerMock.SetupSequence(x => x.IsEndOfGame(It.IsAny<int>()))
                .Returns(false)
                .Returns(true);
            
            //Act
            game.Start();

            //Assert
            _gameControllerMock.Verify(x=> x.GetStartingPlayer(), Times.AtLeastOnce);
            _gameControllerMock.Verify(x => x.MoveToken(It.IsAny<IPlayer>(), It.IsAny<int>()), Times.AtLeastOnce);
            _gameControllerMock.Verify(x => x.IsEndOfGame(It.IsAny<int>()), Times.AtLeastOnce);
            _gameControllerMock.Verify(x => x.NextPlayer(It.IsAny<IPlayer>()), Times.AtLeastOnce);
        }
    }
}
