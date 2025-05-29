using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "AnimalSettings", menuName = "ZooWorld/AnimalSettings")]
    public class AnimalSettings : ScriptableObject
    {
        [field: SerializeField] public float FrogJumpInterval { get; private set; } = 1f;
        [field: SerializeField] public float FrogJumpDistance { get; private set; } = 2f;
        [field: SerializeField] public float SnakeSpeed { get; private set; } = 3f;
    }
}