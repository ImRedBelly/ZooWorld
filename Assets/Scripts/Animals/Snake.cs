using Animals.Interfaces;
using UnityEngine;

namespace Animals
{
    public class Snake : Animal, IPredator
    {
        public void Eat(IAnimal other)
        {
            if (other.IsDead)
            {
                return;
            }

            if (other is IPrey prey)
            {
                prey.OnEaten();
            }
            else if (other is IPredator)
            {
                if (Random.value > 0.5f)
                {
                    other.Die();
                }
                else
                {
                    Die();
                }
            }
        }
    }
}