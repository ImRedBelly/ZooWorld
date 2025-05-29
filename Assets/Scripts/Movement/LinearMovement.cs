using Settings;
using UnityEngine;
using Zenject;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class LinearMovement : MonoBehaviour, IMovement
    {
        private Vector3 direction;
        private Rigidbody rb;
        private float speed;

        [Inject]
        private void Construct(AnimalSettings settings)
        {
            speed = settings.SnakeSpeed;
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            SetRandomDirection();
            rb.linearVelocity = direction * speed;
        }

        public void Tick(float deltaTime)
        {
            rb.linearVelocity = direction * speed;
        }

        public void ReverseDirection()
        {
            direction = -direction;
            rb.linearVelocity = direction * speed;
        }

        private void SetRandomDirection()
        {
            Vector2 random2D = Random.insideUnitCircle.normalized;
            direction = new Vector3(random2D.x, 0, random2D.y);
        }
    }
}