using System;
using System.Collections;
using Game.Player.Weapons;
using UnityEngine;
using Zenject;

namespace Game.Core.Loot
{
	public class LootBox : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private BoxCollider2D _collider;
		private WaitForSeconds _interval = new WaitForSeconds(1f);
		private LootSpawner _lootSpawner;

		private void OnEnable() => _collider.enabled = true;
		private void OnTriggerEnter2D(Collider2D col)
		{
			if (!col.TryGetComponent(out BaseWeapon weapon)) return;
			_animator.SetTrigger("Break");
			StartCoroutine(GetRandomLoot());
			_collider.enabled = false;
		}

		private IEnumerator GetRandomLoot()
		{
			_lootSpawner.Spawn(transform.position);
			yield return _interval;
			gameObject.SetActive(false);
		}

		[Inject] private void Construct(LootSpawner lootSpawner) => _lootSpawner = lootSpawner;
	}
}