using System;
using System.Collections;
using Game.Core.Pool;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float _timeToSpawn;
        private WaitForSeconds _interval;
        private Coroutine _spawnCoroutine;
        private ObjectPool _enemyPool;

        private void Awake() => _enemyPool = new ObjectPool(_enemyPrefab, 5);
        private void Start() => _interval = new WaitForSeconds(_timeToSpawn);

        public void Activate() => _spawnCoroutine = StartCoroutine(Spawn());

        public void Deactivate() => StopCoroutine(_spawnCoroutine);

        private IEnumerator Spawn()
        {
            while (true)
            {
                GameObject newEnemy = _enemyPool.GetFromPool();
                newEnemy.transform.SetParent(transform);
                
                yield return _interval;
            }
        }
    }
}