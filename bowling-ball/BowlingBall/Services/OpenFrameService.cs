using System.Collections.Generic;

namespace BowlingBall.Services
{
    public class OpenFrameService : BaseFrameService
    {
        public OpenFrameService(List<int> attempts, int firstAttempt, int secondAttempt) : base(attempts)
        {
            attempts.Add(firstAttempt);
            attempts.Add(secondAttempt);
        }

        override public int Score()
        {
            return attempts[startingAttempt] + attempts[startingAttempt + 1];
        }

        override protected int FrameSize()
        {
            return 2;
        }
    }
}