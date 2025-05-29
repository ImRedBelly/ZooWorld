using UnityEngine;

namespace Systems
{
    public interface IBoundaryController
    {
        bool IsWithinBounds(Vector3 position);
        Vector3 GetRandomPosition();
    }

    public class BoundaryController : IBoundaryController
    {
        private Vector2 boundsMin;
        private Vector2 boundsMax;

        public BoundaryController()
        {
            CalculateBounds();
        }

        private void CalculateBounds()
        {
            var mainCamera = Camera.main;
            if (mainCamera != null)
            {
                float cameraHeight = mainCamera.transform.position.y;

                Vector3 bottomLeftWorld = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, cameraHeight));
                Vector3 topRightWorld =
                    mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraHeight));

                boundsMin = new Vector2(
                    Mathf.Min(bottomLeftWorld.x, topRightWorld.x),
                    Mathf.Min(bottomLeftWorld.z, topRightWorld.z));

                boundsMax = new Vector2(
                    Mathf.Max(bottomLeftWorld.x, topRightWorld.x),
                    Mathf.Max(bottomLeftWorld.z, topRightWorld.z));
            }
        }

        public bool IsWithinBounds(Vector3 position)
        {
            return position.x >= boundsMin.x && position.x <= boundsMax.x &&
                   position.z >= boundsMin.y && position.z <= boundsMax.y;
        }

        public Vector3 GetRandomPosition()
        {
            return new Vector3(
                Random.Range(boundsMin.x, boundsMax.x),
                0,
                Random.Range(boundsMin.y, boundsMax.y));
        }
    }
}