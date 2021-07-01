using BowlingBall.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameTest
    {
        private IGameService _gameService;

        [TestInitialize]
        public void TestInitialise()
        {
            _gameService = new GameService();
        }

        [TestMethod]
        public void GutterBallsTest()
        {
            Roll(10, 0, 0);
            var score = _gameService.GetScore();
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void ThreesTest()
        {
            Roll(10, 3, 3);
            var score = _gameService.GetScore();
            Assert.AreEqual(60, score);
        }

        [TestMethod]
        public void SpareTest()
        {
            _gameService.Spare(4, 6);
            _gameService.OpenFrame(3, 5);
            Roll(8, 0, 0);
            var score = _gameService.GetScore();
            Assert.AreEqual(21, score);
        }

        [TestMethod]
        public void StrikeTest()
        {
            _gameService.Strike();
            _gameService.OpenFrame(5, 3);
            Roll(8, 0, 0);
            var score = _gameService.GetScore();
            Assert.AreEqual(26, score);
        }

        [TestMethod]
        public void FinalFrameStrikeTest()
        {
            Roll(9, 0, 0);
            _gameService.Strike();
            _gameService.BonusRoll(5);
            _gameService.BonusRoll(3);
            var score = _gameService.GetScore();
            Assert.AreEqual(18, score);
        }

        [TestMethod]
        public void FinalFrameSpareTest()
        {
            Roll(9, 0, 0);
            _gameService.Spare(4, 6);
            _gameService.BonusRoll(5);
            var score = _gameService.GetScore();
            Assert.AreEqual(15, score);
        }

        [TestMethod]
        public void PerfectFrameTest()
        {
            for (int i = 0; i < 10; i++)
                _gameService.Strike();
            _gameService.BonusRoll(10);
            _gameService.BonusRoll(10);
            var score = _gameService.GetScore();
            Assert.AreEqual(300, score);
        }


        #region Some Additional Test Cases

        [TestMethod]
        public void GutterBallsTestWithNewApproach()
        {
            var times = 10;
            for (int i = 0; i < times; i++)
            {
                var bonusAttempt = 0;
                if (i == times - 1)
                    bonusAttempt = 5;

                _gameService.Roll(0, 0, bonusAttempt);
            }
            var score = _gameService.GetScore();
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void ThreesTestWithNewApproach()
        {
            var times = 10;
            for (int i = 0; i < times; i++)
            {
                var bonusAttempt = 0;
                if (i == times - 1)
                    bonusAttempt = 5;

                _gameService.Roll(3, 3, bonusAttempt);
            }
            var score = _gameService.GetScore();
            Assert.AreEqual(60, score);
        }

        [TestMethod]
        public void FivesTestWithNewApproach()
        {
            var times = 10;
            for (int i = 0; i < times; i++)
            {
                var bonusAttempt = 0;
                if (i == times - 1)
                    bonusAttempt = 5;

                _gameService.Roll(5, 5, bonusAttempt);
            }
            var score = _gameService.GetScore();
            Assert.AreEqual(150, score);
        }

        [TestMethod]
        public void PerfectFrameTestWithNewApproach()
        {
            var times = 10;
            for (int i = 0; i < times; i++)
            {
                var firstBonusAttempt = 0;
                var secondBonusAttempt = 0;
                if (i == times - 1)
                {
                    firstBonusAttempt = 10;
                    secondBonusAttempt = 10;
                }
                _gameService.Roll(10, 0, firstBonusAttempt, secondBonusAttempt);
            }
            var score = _gameService.GetScore();
            Assert.AreEqual(300, score);
        }

        #endregion Some Additional Cases

        #region Private Methods

        private void Roll(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                _gameService.OpenFrame(firstThrow, secondThrow);
        }

        #endregion Private Methods
    }
}