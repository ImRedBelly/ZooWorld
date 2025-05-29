using System;

namespace Systems
{
    public interface IEatScoreService
    {
        event Action UpdatePreyDead;
        event Action UpdatePredatorDead;
        int PreyDead { get; }
        int PredatorDead { get; }
        void IncrementDeadPrey();
        void IncrementDeadPredator();
    }

    public class EatScoreService : IEatScoreService
    {
        public event Action UpdatePreyDead;
        public event Action UpdatePredatorDead;
        public int PreyDead { get; private set; }
        public int PredatorDead { get; private set; }

        public void IncrementDeadPrey()
        {
            PreyDead++;
            UpdatePreyDead?.Invoke();
        }

        public void IncrementDeadPredator()
        {
            PredatorDead++;
            UpdatePredatorDead?.Invoke();
        }
    }
}