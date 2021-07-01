using System.Collections.Generic;

namespace BowlingBall.Services
{
    abstract public class BaseFrameService
    {
        protected List<int> attempts;
        protected int startingAttempt;

        public BaseFrameService(List<int> attempts)
        {
            startingAttempt = attempts.Count;
            this.attempts = attempts;
        }

        abstract public int Score();

        abstract protected int FrameSize();

        protected int FirstBonusBall()
        {
            return attempts[startingAttempt + FrameSize()];
        }

        protected int SecondBonusBall()
        {
            return attempts[startingAttempt + FrameSize() + 1];
        }
    }
}