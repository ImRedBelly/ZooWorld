using Animals.Interfaces;
using Systems;
using UnityEngine;
using Zenject;

namespace Animals.Components
{
    [RequireComponent(typeof(Animal))]
    public class AnimalCollisionHandler : MonoBehaviour
    {
        private IAnimal self;
        private IInteractionResolver resolver;

        [Inject]
        private void Construct(IInteractionResolver interactionResolver)
        {
            resolver = interactionResolver;
        }

        private void Awake()
        {
            self = GetComponent<IAnimal>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (self.IsDead)
            {
                return;
            }

            if (collision.collider.TryGetComponent<IAnimal>(out var other))
            {
                if (!other.IsDead)
                {
                    resolver.ResolveInteraction(self, other);
                }
            }
        }
    }
}