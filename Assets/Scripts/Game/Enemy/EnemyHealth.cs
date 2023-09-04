using System;
using System.Collections;
using Game.Core;
using Game.Core.ExperienceSystem;
using Game.FX.DamageText;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Enemy
{
	public class EnemyHealth : ObjectHealth
	{
		private ExperienceSpawner _experienceSpawner;
		private DamageTextSpawner _damageTextSpawner;
		private WaitForSeconds _tick = new WaitForSeconds(0.5f);
		public override void TakeDamage(float damage)
		{
			base.TakeDamage(damage);
			_damageTextSpawner.Activate(transform,(int)damage);
			if (CurrentHealth < 0 == false) return;
			gameObject.SetActive(false);
			if(Random.Range(1f,100f) <=30)
				_experienceSpawner.Spawn(transform.position);
		}

		public void Burn(float damage) => StartCoroutine(GetBurn(damage));
		[Inject] private void Construct(ExperienceSpawner experienceSpawner, DamageTextSpawner damageTextSpawner)
		{
			_experienceSpawner = experienceSpawner;
			_damageTextSpawner = damageTextSpawner;
		}

		private IEnumerator GetBurn(float damage)
		{
			if(gameObject.activeSelf == false)
				yield break;
			float tickDamage = damage / 3;
			if (tickDamage < 1)
				tickDamage = 1;
			for (int i = 0; i < 5; i++)
			{
				TakeDamage(tickDamage);
				_damageTextSpawner.Activate(transform,(int)tickDamage);
				yield return _tick;
			}
		}
	}
}