using BowlingBall.Contracts;
using BowlingBall.Services;
using System.Collections.Generic;

namespace BowlingBall
{
    public class GameService : IGameService
    {
        private readonly List<BaseFrameService> frames = null;
        private readonly List<int> attempts = null;

        public GameService()
        {
            frames = new List<BaseFrameService>();
            attempts = new List<int>();
        }

        public void Roll(int firstAttempt, int secondAttempt, int firstBonusAttempt = 0, int secondBonusAttempt = 0)
        {
            var totalKnockedPins = firstAttempt + secondAttempt;
            if (totalKnockedPins < 10)
            {
                OpenFrame(firstAttempt, secondAttempt);
            }
            else if (firstAttempt == 10)
            {
                Strike();
                if (firstBonusAttempt > 0)
                    BonusRoll(firstBonusAttempt);
                if (secondBonusAttempt > 0)
                    BonusRoll(secondBonusAttempt);
            }
            else if (totalKnockedPins == 10)
            {
                Spare(firstAttempt, secondAttempt);
                if (firstBonusAttempt > 0)
                    BonusRoll(firstAttempt);
            }
        }

        public int GetScore()
        {
            int totalScore = 0;
            foreach (var frame in frames)
            {
                totalScore += frame.Score();
            }
            return totalScore;
        }

        public void OpenFrame(int firstAttempt, int secondAttempt)
        {
            var frame = new OpenFrameService(attempts, firstAttempt, secondAttempt);
            frames.Add(frame);
        }

        public void Spare(int firstAttempt, int secondAttempt)
        {
            frames.Add(new SpareFrameService(attempts, firstAttempt, secondAttempt));
        }

        public void Strike()
        {
            frames.Add(new StrikeFrameService(attempts));
        }

        public void BonusRoll(int roll)
        {
            frames.Add(new BonusRollService(attempts, roll));
        }
    }
}