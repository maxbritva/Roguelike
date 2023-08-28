using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Core.Pool
{
	public class ObjectPool: MonoBehaviour, IFactory<GameObject>
	{
		[SerializeField] private GameObject _prefab;
		private List<GameObject> _objectsPool = new List<GameObject>();
		[Inject] private DiContainer _container;

		private void Awake() => Create();

		private void SetActiveObject(GameObject objectToRelease, bool value) => objectToRelease.gameObject.SetActive(value);

		public GameObject GetFromPool()
		{
			for (int i = 0; i < _objectsPool.Count; i++)
			{
				if (_objectsPool[i].activeInHierarchy) continue;
				SetActiveObject(_objectsPool[i], true);
				return _objectsPool[i];
			}
			GameObject gameObject = Create();
			SetActiveObject(gameObject, true);
			return gameObject;
		}
        
		public GameObject Create()
		{
			GameObject newObject = _container.InstantiatePrefab(_prefab);
			// GameObject newObject = Object.Instantiate(_prefab);
			// _container.InjectGameObject(newObject);              
			SetActiveObject(newObject, false);
			_objectsPool.Add(newObject);
			return newObject;
		}
	}
}