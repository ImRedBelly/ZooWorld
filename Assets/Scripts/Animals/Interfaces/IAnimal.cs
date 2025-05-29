using UnityEngine;

namespace Animals.Interfaces
{
    public interface IAnimal
    {
        bool IsDead { get; }
        Transform Transform { get; }
        void Die();
    }
}