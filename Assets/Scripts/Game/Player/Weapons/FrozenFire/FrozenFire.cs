using System.Collections;
using System.Collections.Generic;
using Game.Core.Pool;
using UnityEngine;

namespace Game.Player.Weapons.FrozenFire
{
	public class FrozenFire : BaseWeapon
	{
		[SerializeField] private ObjectPool _objectPool;
		[SerializeField] private Transform _targetContainer;
		[SerializeField] private List<Transform> _shootPoints = new List<Transform>();
		private WaitForSeconds _timeBetweenAttack;
		private Coroutine _attackRoutine;
		private float _duration;
		private float _speed;
		private Vector3 _direction;
		public float Duration => _duration;
		public float Speed => _speed;

		private void OnEnable() => Activate();
		
		private void Activate()
		{
			SetStats(0);
			_attackRoutine = StartCoroutine(StartThrow());
		}
		
		private void Deactivate() => StopCoroutine(_attackRoutine);
		
		protected override void SetStats(int value)
		{
			base.SetStats(CurrentLevel-1);
			_timeBetweenAttack = new WaitForSeconds(WeaponStats[CurrentLevel-1].TimeBetweenAttack);
			_speed = WeaponStats[CurrentLevel-1].Speed;
			_duration = WeaponStats[CurrentLevel-1].Duration;
		}
		
		private IEnumerator StartThrow()
		{
			while (true)
			{
				for (int i = 0; i < _shootPoints.Count; i++)
				{
					_direction = (_shootPoints[i].position - transform.position).normalized;
					float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
					GameObject throwFromPool = _objectPool.GetFromPool();
					throwFromPool.transform.SetParent(_targetContainer);
					throwFromPool.transform.position = transform.position;
					throwFromPool.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				}
				yield return _timeBetweenAttack;
			}
		}
	}
}