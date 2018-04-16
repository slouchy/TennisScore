using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private const int gameId = 1;
        private IRepository<Game> _repository = Substitute.For<IRepository<Game>>();
        private TennisGame _TennisGame;

        [TestInitialize]
        public void TestInit()
        {
            InitATennisGame();
        }

        [TestMethod]
        public void Love_All()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 0, SecondPlayerScore = 0 });
            scoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 1 });
            scoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Thirty_All()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 2, SecondPlayerScore = 2 });
            scoreShouldBe("Thirty All");
        }

        private void GivenTennisGame(Game game)
        {
            _repository.GetGame(gameId).Returns(game);
        }

        private void InitATennisGame()
        {
            _TennisGame = new TennisGame(_repository);
        }
        private void scoreShouldBe(string excepted)
        {
            Assert.AreEqual(excepted, _TennisGame.ScoreResult(gameId));
        }

    }
}