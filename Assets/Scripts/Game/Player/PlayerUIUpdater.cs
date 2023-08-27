using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Player
{
	public class PlayerUIUpdater : MonoBehaviour
	{
		[SerializeField] private Image _playerHealthFill;
		private PlayerHealth _playerHealth;

		private void OnEnable() => _playerHealth.OnHealthChanged += UpdateUI;
		private void OnDisable() => _playerHealth.OnHealthChanged -= UpdateUI;
		[Inject] private void Construct(PlayerHealth playerHealth) => _playerHealth = playerHealth;
		private void UpdateUI() => UpdateHealthBar();

		private void UpdateHealthBar()
		{
			_playerHealthFill.fillAmount = _playerHealth.CurrentHealth / _playerHealth.MaxHealth;
			_playerHealthFill.fillAmount = Mathf.Clamp01(_playerHealthFill.fillAmount);
		}
	}
}