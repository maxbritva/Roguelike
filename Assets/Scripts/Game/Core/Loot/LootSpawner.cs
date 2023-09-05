using Game.Core.Pool;
using UnityEngine;

namespace Game.Core.Loot
{
	public class LootSpawner : MonoBehaviour
	{
		[SerializeField] private Transform _spawnContainer;
		[SerializeField] private ObjectPool _coinPool;
		[SerializeField] private ObjectPool _treasurePool;
		[SerializeField] private ObjectPool _heartPool;

		public void Spawn(Vector3 spawnPoint)
		{
			float random = Random.Range(1f,100f);
			GameObject newLoot = random switch
			{
				<= 30 => _heartPool.GetFromPool(),
				>= 90 => _treasurePool.GetFromPool(),
				_ => _coinPool.GetFromPool()
			};
			newLoot.transform.position = spawnPoint;
			newLoot.transform.SetParent(_spawnContainer);
		}
	}
}