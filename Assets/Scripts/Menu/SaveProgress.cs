using Game.Player;
using UnityEngine;
using Zenject;

namespace Menu
{
    public class SaveProgress : MonoBehaviour
    {
        private PlayerData _playerData;

        [Inject] private void Construct(PlayerData playerData) => _playerData = playerData;

        public void SaveData()
        {
            PlayerPrefs.SetInt("Coins", _playerData.Coins);
            PlayerPrefs.SetInt("HealthUpgrade", _playerData.MaxHealthUpgradeIndex);
            PlayerPrefs.SetInt("SpeedUpgrade", _playerData.SpeedUpgradeIndex);
            PlayerPrefs.SetInt("RegenUpgrade", _playerData.RegenUpgradeIndex);
            PlayerPrefs.SetInt("RangeUpgrade", _playerData.RangeExpUpgradeIndex);
        }

        public void LoadData()
        {
            _playerData.AddRewardCoins(PlayerPrefs.GetInt("Coins"));
            _playerData.SetUpgradeIndex(PlayerPrefs.GetInt("HealthUpgrade"),1);
            if (PlayerPrefs.GetInt("HealthUpgrade") == 0)
                _playerData.SetUpgradeIndex(1,1);
            _playerData.SetUpgradeIndex(PlayerPrefs.GetInt("SpeedUpgrade"),2);
            if (PlayerPrefs.GetInt("SpeedUpgrade") == 0)
                _playerData.SetUpgradeIndex(1,2);
            _playerData.SetUpgradeIndex(PlayerPrefs.GetInt("RegenUpgrade"),3);
            if (PlayerPrefs.GetInt("RegenUpgrade") == 0)
                _playerData.SetUpgradeIndex(1,3);
            _playerData.SetUpgradeIndex(PlayerPrefs.GetInt("RangeUpgrade"),4);
            if (PlayerPrefs.GetInt("RangeUpgrade") == 0)
                _playerData.SetUpgradeIndex(1,4);
        }
    }
}