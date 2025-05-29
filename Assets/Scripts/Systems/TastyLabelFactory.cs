using UnityEngine;

namespace Systems
{
    public interface ITastyLabelFactory
    {
        void ShowTastyLabel(Transform parent);
    }
    public class TastyLabelFactory : ITastyLabelFactory
    {
        private readonly GameObject labelPrefab;

        public TastyLabelFactory()
        {
            labelPrefab = Resources.Load<GameObject>("Prefabs/TastyLabel");
        }

        public void ShowTastyLabel(Transform parent)
        {
            var instance = Object.Instantiate(labelPrefab, parent);
            instance.transform.localPosition = new Vector3(0, 1, 0);
            Object.Destroy(instance, 1f);
        }
    }
}