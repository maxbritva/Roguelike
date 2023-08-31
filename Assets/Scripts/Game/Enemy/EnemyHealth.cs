using Game.Core;
using Game.Core.ExperienceSystem;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
	public class EnemyHealth : ObjectHealth
	{
		private ExperienceSpawner _experienceSpawner;
		public override void TakeDamage(float damage)
		{
			base.TakeDamage(damage);
			if (CurrentHealth < 0 == false) return;
			gameObject.SetActive(false);
			if(Random.Range(1f,100f) <=30)
				_experienceSpawner.Spawn(transform.position);
		}
		[Inject] private void Construct(ExperienceSpawner experienceSpawner) => _experienceSpawner = experienceSpawner;
	}
}