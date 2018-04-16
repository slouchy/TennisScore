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
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 1 });
            ScoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Thirty_All()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 2, SecondPlayerScore = 2 });
            ScoreShouldBe("Thirty All");
        }

        [TestMethod]
        public void Deuce1()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 3 });
            ScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void Deuce2()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 8, SecondPlayerScore = 8 });
            ScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 0 });
            ScoreShouldBe("Fifteen Love");
        }
        [TestMethod]
        public void Thirty_Fifteen()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 2, SecondPlayerScore = 1 });
            ScoreShouldBe("Thirty Fifteen");
        }

        [TestMethod]
        public void Forty_Fifteen()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 1 });
            ScoreShouldBe("Forty Fifteen");
        }

        [TestMethod]
        public void Fifteen_Forty()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 1, SecondPlayerScore = 3 });
            ScoreShouldBe("Fifteen Forty");
        }

        [TestMethod]
        public void FirstPlayer_Advance()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 4, SecondPlayerScore = 3, FirstPlayerName = "Joey" });
            ScoreShouldBe("Joey Adv");
        }

        [TestMethod]
        public void SecondPlayer_Advance()
        {
            GivenTennisGame(new Game { Id = gameId, FirstPlayerScore = 3, SecondPlayerScore = 4, SecondPlayerName = "Tom" });
            ScoreShouldBe("Tom Adv");
        }

        private void GivenTennisGame(Game game)
        {
            _repository.GetGame(gameId).Returns(game);
        }

        private void InitATennisGame()
        {
            _TennisGame = new TennisGame(_repository);
        }
        private void ScoreShouldBe(string excepted)
        {
            Assert.AreEqual(excepted, _TennisGame.ScoreResult(gameId));
        }

    }
}