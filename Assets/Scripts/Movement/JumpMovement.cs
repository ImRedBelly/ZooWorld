using Settings;
using UnityEngine;
using Zenject;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class JumpMovement : MonoBehaviour, IMovement
    {
        private float interval;
        private float distance;
        private float timer;
        private Vector3 direction;
        private Rigidbody rb;

        [Inject]
        private void Construct(AnimalSettings settings)
        {
            interval = settings.FrogJumpInterval;
            distance = settings.FrogJumpDistance;
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            SetRandomDirection();
        }

        public void Tick(float deltaTime)
        {
            timer += deltaTime;
            if (timer >= interval)
            {
                timer = 0;
                Vector3 jump = direction * distance + Vector3.up * distance;
                rb.AddForce(jump, ForceMode.Impulse);
            }
        }

        public void ReverseDirection()
        {
            direction = -direction;
            rb.linearVelocity = Vector3.zero;
        }

        private void SetRandomDirection()
        {
            direction = Random.insideUnitSphere;
            direction.y = 0;
            direction.Normalize();
        }
    }
}