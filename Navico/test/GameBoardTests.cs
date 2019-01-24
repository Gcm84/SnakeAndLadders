using AutoFixture;
using AutoFixture.AutoMoq;
using Navico.Models;
using NUnit.Framework;

namespace Navico.test
{
    [TestFixture]
    public class GameBoardTests
    {
        private IFixture _fixture;

        [OneTimeSetUp]
        public void OneTimeSetUp() {

            _fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        [Test]
        public void GetTokenPosition_WhenMoveIsWithinBoard_MustReturnNewPosition()
        {
            //Arrange
            var gameBoard = _fixture.Create<GameBoard>();
            gameBoard._winnerSquare = 100;

            //Act
            var result = gameBoard.GetTokenPosition(70, 6);

            //Assert
            Assert.That(result, Is.EqualTo(76));
        }

        [Test]
        public void GetTokenPosition_WhenMoveOutOfBoard_MustReturnPlayersCurrentPosition()
        {
            //Arrange
            var gameBoard = _fixture.Create<GameBoard>();
            gameBoard._winnerSquare = 100;

            //Act
            var result = gameBoard.GetTokenPosition(95, 6);

            //Assert
            Assert.That(result, Is.EqualTo(95));
        }
    }
}
