using System;
using Game.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
	public class CoinsUpdater : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _coinsText;
		public Action OnCountChanged;
		private PlayerData _playerData;

		private void OnEnable()
		{
			OnCountChanged += _playerData.AddCoins;
			OnCountChanged += UpdateCoinsText;
		}

		private void OnDisable()
		{
			OnCountChanged -= _playerData.AddCoins;
			OnCountChanged -= UpdateCoinsText;
		}
		private void UpdateCoinsText() => _coinsText.text = _playerData.Coins.ToString();

		[Inject] private void Construct(PlayerData playerData) => _playerData = playerData;
	}
}