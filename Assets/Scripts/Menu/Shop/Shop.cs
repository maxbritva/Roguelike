using Game.Player;
using Menu.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.Shop
{
	public class Shop : MonoBehaviour
	{
		[Header("Cost texts")]
		[SerializeField] private TextMeshProUGUI _maxHealthCostText;
		[SerializeField] private TextMeshProUGUI _speedCostText;
		[SerializeField] private TextMeshProUGUI _regenCostText;
		[SerializeField] private TextMeshProUGUI _rangeExpCostText;
		[Header("Upgrade buttons")]
		[SerializeField] private Button _maxHealthButton;
		[SerializeField] private Button _speedButton;
		[SerializeField] private Button _regenButton;
		[SerializeField] private Button _rangeExpButton;
		private UpgradeLoader _upgradeLoader;
		private PlayerData _playerData;
		private MenuUIUpdater _menuUIUpdater;
		private SaveProgress _saveSystem;

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
			_menuUIUpdater.UpdateUI();
		}
		
		public void TryUpgrade(int id)
		{
			switch (id)
			{
				case 1:
				{
					SpendCoins(_upgradeLoader.MaxHealthCurrentLevel);
					if (_playerData.MaxHealthUpgradeIndex < 5) 
						_playerData.SetUpgradeIndex(_playerData.MaxHealthUpgradeIndex + 1,1);
					CheckAvailableButtons();
					ShowPrice();
					_upgradeLoader.LoadCurrentLevels();
					break;
				}
				case 2:
				{
					SpendCoins(_upgradeLoader.SpeedCurrentLevel);
					if (_playerData.SpeedUpgradeIndex < 5) 
						_playerData.SetUpgradeIndex(_playerData.SpeedUpgradeIndex + 1,2);
					CheckAvailableButtons();
					ShowPrice();
					_upgradeLoader.LoadCurrentLevels();
					break;
				}
				case 3:
				{
					SpendCoins(_upgradeLoader.RegenCurrentLevel);
					if (_playerData.RegenUpgradeIndex < 5) 
						_playerData.SetUpgradeIndex(_playerData.RegenUpgradeIndex + 1,2);
					CheckAvailableButtons();
					ShowPrice();
					_upgradeLoader.LoadCurrentLevels();
					break;
				}	
				case 4:
				{
					SpendCoins(_upgradeLoader.RangeExpCurrentLevel);
					if (_playerData.RangeExpUpgradeIndex < 5) 
						_playerData.SetUpgradeIndex(_playerData.RangeExpUpgradeIndex + 1,2);
					CheckAvailableButtons();
					ShowPrice();
					_upgradeLoader.LoadCurrentLevels();
					break;
				}	
			}
		}
		
		private void SpendCoins(ItemShop target) {
			_playerData.TrySpendCoins(-target.Cost);
			_saveSystem.SaveData();
			_menuUIUpdater.UpdateUI();
		}
		
		[Inject] private void Construct(UpgradeLoader loader, PlayerData data, SaveProgress save, MenuUIUpdater UIUpdater)
		{
			_upgradeLoader = loader;
			_playerData = data;
			_menuUIUpdater = UIUpdater;
			_saveSystem = save;
		}

		private void CheckAvailableButtons()
		{
			_maxHealthButton.interactable = _playerData.Coins >= _upgradeLoader.MaxHealthCurrentLevel.Cost && _playerData.MaxHealthUpgradeIndex < 5;
			_speedButton.interactable = _playerData.Coins >= _upgradeLoader.SpeedCurrentLevel.Cost && _playerData.SpeedUpgradeIndex < 5;
			_regenButton.interactable = _playerData.Coins >= _upgradeLoader.RegenCurrentLevel.Cost && _playerData.RegenUpgradeIndex < 5;
			_rangeExpButton.interactable = _playerData.Coins >= _upgradeLoader.RangeExpCurrentLevel.Cost && _playerData.RangeExpUpgradeIndex < 5;
		}
	}
}