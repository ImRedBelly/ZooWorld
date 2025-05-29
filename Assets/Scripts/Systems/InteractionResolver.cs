using Animals.Interfaces;

namespace Systems
{
    public interface IInteractionResolver
    {
        void ResolveInteraction(IAnimal self, IAnimal other);
    }

    public class InteractionResolver : IInteractionResolver
    {
        private readonly IEatScoreService _eatScoreService;
        private readonly ITastyLabelFactory _labelFactory;
        private readonly IBounceService _bounceService;

        public InteractionResolver(
            IEatScoreService eatScoreService,
            ITastyLabelFactory labelFactory,
            IBounceService bounceService)
        {
            _eatScoreService = eatScoreService;
            _labelFactory = labelFactory;
            _bounceService = bounceService;
        }

        public void ResolveInteraction(IAnimal self, IAnimal other)
        {
            if (self is IPredator predator)
            {
                predator.Eat(other);

                switch (other)
                {
                    case IPredator:
                        _eatScoreService.IncrementDeadPredator();
                        break;
                    case IPrey:
                        _eatScoreService.IncrementDeadPrey();
                        break;
                }

                _labelFactory.ShowTastyLabel(self.Transform);
            }
            else if (self is IPrey && other is IPredator predatorOther)
            {
                predatorOther.Eat(self);
                _eatScoreService.IncrementDeadPrey();
                _labelFactory.ShowTastyLabel(other.Transform);
            }
            else
            {
                _bounceService.Bounce(self, other, 2.0f);
            }
        }
    }
}