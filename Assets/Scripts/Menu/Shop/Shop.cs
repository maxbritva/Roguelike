using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.Shop
{
	public class Shop : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _maxHealthCostText;
		[SerializeField] private TextMeshProUGUI _speedCostText;
		[SerializeField] private TextMeshProUGUI _regenCostText;
		[SerializeField] private TextMeshProUGUI _rangeExpCostText;

		[SerializeField] private Button _damageButton;
		[SerializeField] private Button _speedButton;
		private UpgradeLoader _upgradeLoader;
		private PlayerData _playerData;
		//private MenuUIUpdater _menuUIUpdater;
		//private SaveSystem _saveSystem;

		private void OnEnable()
		{
			ShowPrice();
			CheckAvailableButtons();
		}

		public void ShowPrice()
		{
			_maxHealthCostText.text = "Cost: " + _upgradeLoader.MaxHealthCurrentLevel.Cost;
			_speedCostText.text = "Cost: " + _upgradeLoader.SpeedCurrentLevel.Cost;
			_regenCostText.text = "Cost: " + _upgradeLoader.RegenCurrentLevel.Cost;
			_rangeExpCostText.text = "Cost: " + _upgradeLoader.RangeExpCurrentLevel.Cost;
			//_menuUIUpdater.UpdateUpgradeWindowCoins();
		}
		
		public void TryUpgrade(int id)
		{
			switch (id)
			{
				case 1:
				{
					SpendCredits(_upgradeLoader.DamageCurrentLevel);
					if (_playerData.DamageUpgradeIndex < 5) 
						_playerData.DamageUpgrade();
					CheckAvailableButtons();
					ShowPrice();
					_upgradeLoader.LoadCurrentLevels();
					break;
				}
				case 2:
				{
					SpendCredits(_upgradeLoader.SpeedCurrentLevel);
					if (_playerData.SpeedUpgradeIndex < 5) 
						_playerData.SpeedUpgrade();
					CheckAvailableButtons();
					ShowPrice();
					_upgradeLoader.LoadCurrentLevels();
					break;
				}
			}
		}
		
		private void SpendCredits(ItemShop target) {
			if (_playerData.Coins >= target.Cost)
				_playerData.AddSpendCoins(-target.Cost);
			_saveSystem.SaveData();
		}
		
		[Inject] private void Construct(UpgradeLoader upgradeLoader, PlayerData playerData, MenuUIUpdater menuUIUpdater, SaveSystem saveSystem)
		{
			_upgradeLoader = upgradeLoader;
			_playerData = playerData;
			_menuUIUpdater = menuUIUpdater;
			_saveSystem = saveSystem;
		}

		private void CheckAvailableButtons()
		{
			_damageButton.interactable = _playerData.Coins >= _upgradeLoader.DamageCurrentLevel.Cost && _playerData.DamageUpgradeIndex < 5;
			_speedButton.interactable = _playerData.Coins >= _upgradeLoader.SpeedCurrentLevel.Cost && _playerData.SpeedUpgradeIndex < 5;
		}
	}
}