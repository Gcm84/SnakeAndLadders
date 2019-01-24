using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using Navico.Models;
using NUnit.Framework;

namespace Navico.test
{
    [TestFixture]
    public class GameControllerTests
    {
        private IFixture _fixture;
        private Mock<IGameBoard> _gameBoardMock;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _gameBoardMock = _fixture.Freeze<Mock<IGameBoard>>();
        }

        [Test]
        public void IsEndOfGame_WhenPlayerIsOnWinnerSquare_MustReturnTrue()
        {
            //Arrange
            var gameController = _fixture.Create<GameController>();
            gameController.Initialise(new GameConfiguration());

            //Act
            var result = gameController.IsEndOfGame(100);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsEndOfGame_WhenPlayerIsNotOnWinnerSquare_MustReturnFalse()
        {
            //Arrange
            var gameController = _fixture.Create<GameController>();
            gameController.Initialise(new GameConfiguration());

            //Act
            var result = gameController.IsEndOfGame(60);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void MoveToken_WhenCalled_CallsGetTokenPosition()
        {
            //Arrange
            var gameController = _fixture.Create<GameController>();

            var newPosition = 15;
            gameController.Initialise(new GameConfiguration());
            var player = _fixture.Create<Player>();
            player.CurrentSquare = 10;
            _gameBoardMock.Setup(x => x.GetTokenPosition(player.CurrentSquare, 5)).Returns(newPosition);

            //Act
            gameController.MoveToken(player, 5);

            //Assert
            _gameBoardMock.Verify(x => x.GetTokenPosition(It.IsAny<int>(),It.IsAny<int>()), Times.Once);
            Assert.That(player.CurrentSquare, Is.EqualTo(newPosition));
        }
    }
}
