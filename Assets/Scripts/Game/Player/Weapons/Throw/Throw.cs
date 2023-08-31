using System;
using System.Collections;
using Game.Enemy;
using Game.FX.DamageText;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Player.Weapons.Throw
{
	public class Throw : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D _rigidbody2D;
		private DamageTextSpawner _damageTextSpawner;
		private PlayerController _playerController;
		private ThrowWeapon _throwWeapon;
		private WaitForSeconds _timer;
		private float _duration = 2f;
		private float _damage;
		private float _speed;

		//private void FixedUpdate() => _rigidbody2D.AddForce(_throwWeapon._direction * (_speed * Time.deltaTime), ForceMode2D.Impulse);

		private void Update()
		{
			transform.position += _throwWeapon._direction * (_speed * Time.deltaTime);
		}

		
		private void OnEnable()
		{
			_timer = new WaitForSeconds(_duration);
			_damage = _throwWeapon.Damage;
			_speed = _throwWeapon.Speed;
			StartCoroutine(TimerToHide());
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.gameObject.TryGetComponent(out EnemyHealth health));
			{
				if(health == null) return;
				float damage = Random.Range(_damage / 1.5f, _damage * 1.8f);
				health.TakeDamage(damage);
				_damageTextSpawner.Activate(transform,(int)damage);
			}
		}

		[Inject] private void Construct(ThrowWeapon throwWeapon, DamageTextSpawner damageTextSpawner, PlayerController playerController)
		{
			_throwWeapon = throwWeapon;
			_damageTextSpawner = damageTextSpawner;
			_playerController = playerController;
		}
		private IEnumerator TimerToHide()
		{
			yield return _timer;
			gameObject.SetActive(false);
		}
	}
}