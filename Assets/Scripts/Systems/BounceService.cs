using Animals.Interfaces;
using UnityEngine;

namespace Systems
{
    public interface IBounceService
    {
        void Bounce(IAnimal a, IAnimal b, float force);
    }

    public class BounceService : IBounceService
    {
        public void Bounce(IAnimal firstAnimal, IAnimal secondAnimal, float force)
        {
            if (TryGetRigidbody(firstAnimal, out var firstRigidbody) &&
                TryGetRigidbody(secondAnimal, out var secondRigidbody))
            {
                Vector3 direction = (firstAnimal.Transform.position - secondAnimal.Transform.position).normalized;
                firstRigidbody.AddForce(direction * force, ForceMode.Impulse);
                secondRigidbody.AddForce(-direction * force, ForceMode.Impulse);
            }
        }

        private bool TryGetRigidbody(IAnimal animal, out Rigidbody rb)
        {
            rb = animal.Transform.GetComponent<Rigidbody>();
            return rb != null;
        }
    }
}