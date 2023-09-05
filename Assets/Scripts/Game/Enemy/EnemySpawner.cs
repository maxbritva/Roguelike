using System.Collections;
using Game.Core;
using Game.Core.Pool;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _timeToSpawn;
        [SerializeField] private Transform _minPoint,_maxPoint;
        [SerializeField] private Transform _enemyContainer;
        [SerializeField] private ObjectPool _enemyPool;
        private PlayerController _playerController;
        private RandomSpawnPoint _randomSpawnPoint;
        private WaitForSeconds _interval;
        private Coroutine _spawnCoroutine;

        private void Start() => _interval = new WaitForSeconds(_timeToSpawn);

        public void Activate() => _spawnCoroutine = StartCoroutine(Spawn());
        public void Deactivate() => StopCoroutine(_spawnCoroutine);

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
                GameObject newEnemy = _enemyPool.GetFromPool();
                newEnemy.transform.SetParent(_enemyContainer);
                newEnemy.transform.position = _randomSpawnPoint.GetRandomSpawnPoint(_minPoint, _maxPoint);
                yield return _interval;
            }
        }
    }
}