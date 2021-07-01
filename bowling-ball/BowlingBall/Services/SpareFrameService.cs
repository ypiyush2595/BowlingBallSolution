using System.Collections.Generic;

namespace BowlingBall.Services
{
    public class SpareFrameService : BaseFrameService
    {
        public SpareFrameService(List<int> attempts, int firstAttempt, int secondAttempt) : base(attempts)
        {
            attempts.Add(firstAttempt);
            attempts.Add(secondAttempt);
        }

        private int NextBall()
        {
            return attempts[startingAttempt + 2];
        }

        override public int Score()
        {
            return 10 + NextBall();
        }

        override protected int FrameSize()
        {
            return 2;
        }
    }
}