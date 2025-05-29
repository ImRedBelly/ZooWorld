using Animals.Interfaces;
using Movement;
using Systems;
using UnityEngine;
using Zenject;

namespace Animals
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Animal : MonoBehaviour, IAnimal
    {
        public bool IsDead { get; private set; }
        public Transform Transform => transform;

        private IMovement _movement;
        private IBoundaryController _boundaryController;

        [Inject]
        protected void Construct(IBoundaryController boundary)
        {
            _boundaryController = boundary;
        }

        public void Die()
        {
            if (IsDead)
            {
                return;
            }

            IsDead = true;
            Destroy(gameObject);
        }

        private void Start()
        {
            _movement = GetComponent<IMovement>();
        }

        private void Update()
        {
            if (IsDead)
            {
                return;
            }

            _movement.Tick(Time.deltaTime);

            if (!_boundaryController.IsWithinBounds(transform.position))
            {
                _movement.ReverseDirection();
            }
        }
    }
}