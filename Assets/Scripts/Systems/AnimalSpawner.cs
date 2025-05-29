using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class AnimalSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> animalPrefabs;
        [SerializeField] private float spawnInterval = 1.5f;

        private IBoundaryController _boundaryController;

        private float _timer;

        [Inject]
        private void Construct(IBoundaryController boundaryController)
        {
            _boundaryController = boundaryController;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= spawnInterval)
            {
                _timer = 0;
                var prefab = animalPrefabs[Random.Range(0, animalPrefabs.Count)];
                Instantiate(prefab, _boundaryController.GetRandomPosition(), Quaternion.identity);
            }
        }
    }
}