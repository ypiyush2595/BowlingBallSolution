namespace BowlingBall.Contracts
{
    public interface IGameService
    {
        void Roll(int firstAttempt, int secondAttempt, int firstBonusAttempt = 0, int secondBonusAttempt = 0);

        int GetScore();

        void OpenFrame(int firstThrow, int secondThrow);

        void Spare(int firstThrow, int secondThrow);

        void Strike();

        void BonusRoll(int roll);
    }
}
