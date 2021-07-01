using System.Collections.Generic;

namespace BowlingBall.Services
{
    public class BonusRollService : BaseFrameService
    {
        public BonusRollService(List<int> attempts, int firstAttempt) : base(attempts)
        {
            attempts.Add(firstAttempt);
        }

        override public int Score()
        {
            return 0;
        }

        override protected int FrameSize()
        {
            return 0;
        }
    }
}