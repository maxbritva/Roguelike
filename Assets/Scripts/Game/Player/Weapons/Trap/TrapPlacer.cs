using System.Collections;
using Game.Core.Pool;
using UnityEngine;

namespace Game.Player.Weapons.Trap
{
	public class TrapPlacer : BaseWeapon
	{
		[SerializeField] private ObjectPool _objectPool;
		[SerializeField] private Transform _targetContainer;
		private WaitForSeconds _timeBetweenAttack;
		private Coroutine _attackRoutine;
		private float _duration;
		public float Duration => _duration;

		private void OnEnable() => Activate();

		private void Activate()
		{
			SetStats(0);
			_attackRoutine = StartCoroutine(StartThrow());
		}

		private void Deactivate() => StopCoroutine(_attackRoutine);

		protected override void SetStats(int value)
		{
			base.SetStats(CurrentLevel - 1);
			_timeBetweenAttack = new WaitForSeconds(WeaponStats[CurrentLevel - 1].TimeBetweenAttack);
			_duration = WeaponStats[CurrentLevel - 1].Duration;
		}

		private IEnumerator StartThrow()
		{
			while (true)
			{
				GameObject throwFromPool = _objectPool.GetFromPool();
				throwFromPool.transform.SetParent(_targetContainer);
				throwFromPool.transform.position = transform.position;
				yield return _timeBetweenAttack;
			}
		}
	}
}