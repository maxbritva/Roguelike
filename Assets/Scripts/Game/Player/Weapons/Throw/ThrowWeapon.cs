using System.Collections;
using Game.Core.Pool;
using UnityEngine;
using Zenject;

namespace Game.Player.Weapons.Throw
{
	public class ThrowWeapon : BaseWeapon
	{
		[SerializeField] private ObjectPool _objectPool;
		[SerializeField] private Transform _targetContainer;
		private WaitForSeconds _timeBetweenAttack = new WaitForSeconds(2f);
		[Inject] private PlayerController _playerController;
		private Coroutine _attackRoutine;
		private float _speed = 5f;
		public float Speed => _speed;
		public Vector3 _direction;
		private void OnEnable() => Activate();
		private void Activate()
		{
			SetStats(0);
			_attackRoutine = StartCoroutine(StartThrow());
		}
		private void Deactivate() => StopCoroutine(_attackRoutine);
		
		private IEnumerator StartThrow()
		{
			while (true)
			{
				if (_playerController.Movement != Vector3.zero)
				{
					GameObject thowFromPool = _objectPool.GetFromPool();
					thowFromPool.transform.SetParent(_targetContainer);
					_direction = _playerController.Movement.normalized;
					//float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Deg2Rad;
					//angle -= 90;
					thowFromPool.transform.position = transform.position;
					thowFromPool.transform.eulerAngles = _direction;
				}
				yield return _timeBetweenAttack;
			}
		}

		
	}
}