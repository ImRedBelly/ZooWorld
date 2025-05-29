namespace Movement
{
    public interface IMovement
    {
        void Tick(float deltaTime);
        void ReverseDirection();
    }
}