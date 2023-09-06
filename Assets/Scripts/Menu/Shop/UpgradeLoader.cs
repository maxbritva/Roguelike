using System.Collections.Generic;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Menu.Shop
{
	public class UpgradeLoader : MonoBehaviour
	{
		[SerializeField] private List<ItemShop> _maxHealthLevels = new List<ItemShop>();
		[SerializeField] private List<ItemShop> _speedLevels = new List<ItemShop>();
		[SerializeField] private List<ItemShop> _regenLevels = new List<ItemShop>();
		[SerializeField] private List<ItemShop> _rangeExpLevels = new List<ItemShop>();
		public ItemShop MaxHealthCurrentLevel { get; private set; }
		public ItemShop SpeedCurrentLevel { get; private set; }
		public ItemShop RegenCurrentLevel { get; private set; }
		public ItemShop RangeExpCurrentLevel { get; private set; }
		private PlayerData _playerData;
		private SaveProgress _saveProgress;

		private void Awake()
		{
			_saveProgress.LoadData();
			LoadCurrentLevels();
		}

		public void LoadCurrentLevels() {
			MaxHealthCurrentLevel = _maxHealthLevels[_playerData.MaxHealthUpgradeIndex -1];
			SpeedCurrentLevel = _speedLevels[_playerData.SpeedUpgradeIndex -1];
			RegenCurrentLevel = _regenLevels[_playerData.RegenUpgradeIndex -1];
			RangeExpCurrentLevel = _rangeExpLevels[_playerData.RangeExpUpgradeIndex -1];
		}

		[Inject] private void Construct(PlayerData playerData, SaveProgress save)
		{
			_playerData = playerData;
			_saveProgress = save;
		}
	}
}