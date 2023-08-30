using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Player.Weapons
{
	public class SpinWeapon : BaseWeapon
	{
		[SerializeField] private float _rotationSpeed;
		[SerializeField] private float _hideTimer;
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private Collider2D _collider;
		private WaitForSeconds _interval = new WaitForSeconds(2.2f);
		private Coroutine _coroutine;
		[Inject] private DiContainer _container;

		private void Awake() => _container.Inject(this);

		private void Start() => Activate();

		private void Update() => transform.Rotate(0,0,_rotationSpeed * Time.deltaTime);
		private void Activate() => _coroutine = StartCoroutine(LifeCycle());
		

		private void Deactivate() => StopCoroutine(_coroutine);

		private IEnumerator LifeCycle()
		{
			while (true)
			{
				_spriteRenderer.enabled = !_spriteRenderer.enabled;
				_collider.enabled = !_collider.enabled;
				_collider.isTrigger = !_collider.isTrigger;
				yield return _interval;
			}
		}
		
	}
}