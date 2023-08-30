using System.Collections;
using Game.Core.Pool;
using Game.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Enemy
{
    public abstract class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _timeToSpawn;
        [SerializeField] private Transform _minPoint,_maxPoint;
        [SerializeField] private Transform _enemyContainer;
        [SerializeField] private ObjectPool _enemyPool;
        private PlayerController _playerController;
        private WaitForSeconds _interval;
        private Coroutine _spawnCoroutine;

        private void Start() => _interval = new WaitForSeconds(_timeToSpawn);

        public void Activate() => _spawnCoroutine = StartCoroutine(Spawn());
        public void Deactivate() => StopCoroutine(_spawnCoroutine);

        [Inject] private void Construct(PlayerController playerController) => _playerController = playerController;

        private IEnumerator Spawn()
        {
            while (true)
            {
                transform.position = _playerController.transform.position;
                GameObject newEnemy = _enemyPool.GetFromPool();
                newEnemy.transform.SetParent(_enemyContainer);
                newEnemy.transform.position = GetRandomSpawnPoint();
                yield return _interval;
            }
        }

        private Vector3 GetRandomSpawnPoint()
        {
            Vector3 spawnPoint = Vector3.zero;
            bool verticalSpawn = Random.Range(0f,1f) > 0.5f;
            if (verticalSpawn)
            {
                spawnPoint.y = Random.Range(_minPoint.position.y,_maxPoint.position.y);
                spawnPoint.x = Random.Range(0f, 1f) > 0.5f ? _minPoint.position.x : _maxPoint.position.x;
            }
            else
            {
                spawnPoint.x = Random.Range(_minPoint.position.x,_maxPoint.position.x);
                spawnPoint.y = Random.Range(0f, 1f) > 0.5f ? _minPoint.position.y : _maxPoint.position.y;
            }
            return spawnPoint;
        }
    }
}