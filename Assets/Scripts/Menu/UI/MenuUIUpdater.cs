using Game.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Menu.UI
{
    public class MenuUIUpdater : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        private PlayerData _playerData;

        [Inject] private void Construct(PlayerData playerData) => _playerData = playerData;

        public void UpdateUI() => _coinsText.text = "COINS: " + _playerData.Coins;
    }
    }