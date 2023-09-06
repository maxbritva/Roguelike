using System.Collections;
using Game.Core.Pool;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Core.Loot
{
	public class LootBoxSpawner : MonoBehaviour
	{
		[SerializeField] private ObjectPool _lootBoxPool;
		[SerializeField] private float _timeToSpawn;
		[SerializeField] private Transform _minPoint,_maxPoint;
		[SerializeField] private Transform _lootBoxContainer;
		private PlayerController _playerController;
		private RandomSpawnPoint _randomSpawnPoint;
		private WaitForSeconds _interval;
		private Coroutine _spawnCoroutine;

		private void Awake() => Activate();
		private void Start() => _interval = new WaitForSeconds(_timeToSpawn);

		public void Activate() => _spawnCoroutine = StartCoroutine(Spawn());
		public void Deactivate()
		{
			if(_spawnCoroutine !=null)
				StopCoroutine(_spawnCoroutine);
		}

		[Inject] private void Construct(PlayerController playerController, RandomSpawnPoint randomSpawnPoint)
		{
			_playerController = playerController;
			_randomSpawnPoint = randomSpawnPoint;
		}

		private IEnumerator Spawn()
		{
			while (true)
			{
				transform.position = _playerController.transform.position;
				GameObject newLootBox = _lootBoxPool.GetFromPool();
				newLootBox.transform.SetParent(_lootBoxContainer);
				newLootBox.transform.position = _randomSpawnPoint.GetRandomSpawnPoint(_minPoint, _maxPoint);
				yield return _interval;
			}
		}
	}
	}
