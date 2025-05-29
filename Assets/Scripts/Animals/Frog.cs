using Animals.Interfaces;

namespace Animals
{
    public class Frog : Animal, IPrey
    {
        public void OnEaten()
        {
            Die();
        }
    }
}