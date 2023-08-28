using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Core.Pool
{
    public class ObjectPool: IFactory<GameObject>
    {
        private GameObject _prefab;
        private List<GameObject> _objectsPool;
        [Inject] private DiContainer _container;

        public ObjectPool(GameObject prefab, int prewarmCountObjects)
        {
            _prefab = prefab;
            _objectsPool = new List<GameObject>();
            for (int i = 0; i < prewarmCountObjects; i++) 
                Create();
        }

        private static void SetActiveObject(GameObject objectToRelease, bool value) => objectToRelease.gameObject.SetActive(value);

        private GameObject GetFromPool()
        {
            var newObject = _objectsPool.FirstOrDefault(
                x => x.gameObject.activeInHierarchy == false);
            if (newObject == null)
                Create();
            SetActiveObject(newObject, true);
            return newObject;
        }
        
        public GameObject Create()
        {
            GameObject newObject = _container.InstantiatePrefab(_prefab);
            SetActiveObject(newObject,false);
            _objectsPool.Add(newObject);
            return newObject;
        }
    }
}