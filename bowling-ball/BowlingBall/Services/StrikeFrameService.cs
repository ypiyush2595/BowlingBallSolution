using System.Collections.Generic;

namespace BowlingBall.Services
{
    internal class StrikeFrameService : BaseFrameService
    {
        public StrikeFrameService(List<int> attempts) : base(attempts)
        {
            attempts.Add(10);
        }

        override public int Score()
        {
            return 10 + FirstBonusBall() + SecondBonusBall();
        }

        override protected int FrameSize()
        {
            return 1;
        }
    }
}