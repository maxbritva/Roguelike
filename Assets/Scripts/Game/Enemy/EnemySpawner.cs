using System;
using System.Collections;
using Game.Core.Pool;
using Game.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float _timeToSpawn;
        private WaitForSeconds _interval;
        private Coroutine _spawnCoroutine;
        private ObjectPool _enemyPool;
        private PlayerHealth _playerHealth;
        [Inject] private DiContainer _container; 
        private void Awake()
        {
            _enemyPool = new ObjectPool(_enemyPrefab, 5);
            _container.Inject(_enemyPool);
        }

        private void Start()
        {
            _interval = new WaitForSeconds(_timeToSpawn);
            Activate();
        }

        public void Activate() => _spawnCoroutine = StartCoroutine(Spawn());

        public void Deactivate() => StopCoroutine(_spawnCoroutine);

        [Inject] private void Construct(PlayerHealth playerHealth) => _playerHealth = playerHealth;

        private IEnumerator Spawn()
        {
            while (true)
            {
                GameObject newEnemy = _enemyPool.GetFromPool();
                newEnemy.transform.SetParent(transform);
                newEnemy.transform.position = GetRandomSpawnPoint();
                yield return _interval;
            }
        }

        private Vector3 GetRandomSpawnPoint() => (_playerHealth.transform.position * Random.insideUnitCircle).normalized * 45f;
    }
}