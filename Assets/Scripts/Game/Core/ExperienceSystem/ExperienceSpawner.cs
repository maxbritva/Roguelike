using Game.Core.Pool;
using UnityEngine;

namespace Game.Core.ExperienceSystem
{
	public class ExperienceSpawner : MonoBehaviour
	{
		[SerializeField] private ObjectPool _objectPool;
		
		public void Spawn(Vector3 position)
		{
			GameObject exp = _objectPool.GetFromPool();
			exp.transform.SetParent(transform);
			exp.transform.position = position;
		}
	}
}