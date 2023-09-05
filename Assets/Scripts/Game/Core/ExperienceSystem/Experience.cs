using System;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Core.ExperienceSystem
{
	public class Experience : MonoBehaviour
	{
		[SerializeField] private int _value;
		private ExperienceSystem _experienceSystem;
		private float _distanceToPickup = 1.5f;
		private PlayerUpgrade _playerUpgrade;
		private PlayerHealth _playerHealth;

		private void OnEnable() => _distanceToPickup = _playerUpgrade.RangeExp;

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.TryGetComponent(out PlayerHealth playerHealth) == false) return;
			if(playerHealth == null) return;
			_experienceSystem.OnExperiencePickedUp?.Invoke(_value);
			gameObject.SetActive(false);
		}

		private void Update()
		{
			if (Vector3.Distance(transform.position, _playerHealth.transform.position) < _distanceToPickup)
				transform.position = Vector3.MoveTowards(transform.position, _playerHealth.transform.position,
					2f * Time.deltaTime);
		}

		[Inject] private void Construct(ExperienceSystem experienceSystem, PlayerHealth playerHealth, PlayerUpgrade playerUpgrade)
		{
			_experienceSystem = experienceSystem;
			_playerHealth = playerHealth;
			_playerUpgrade = playerUpgrade;
		}
	}
}