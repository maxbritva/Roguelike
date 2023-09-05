using System.Collections.Generic;
using Game.Core;
using Game.Core.Upgrades;
using Game.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.UI
{
    public class UpgradeWindow : MonoBehaviour
    {
        [SerializeField] private List<CardHolder> _allCards = new List<CardHolder>();
        [Header("Weapons cards")]
        [SerializeField] private CardHolder _bow;
        [SerializeField] private CardHolder _frozenFire;
        [SerializeField] private CardHolder _shuriken;
        [SerializeField] private CardHolder _trap;
        [SerializeField] private CardHolder _spin;
        [SerializeField] private CardHolder _brightZone;
        private List<CardHolder> _cardsInPull = new List<CardHolder>();
        private PlayerUpgrade _playerUpgrade;
        private GamePause _gamePause;

        private void Start()
        {
            _allCards.Add(_bow);
            _allCards.Add(_frozenFire);
            _allCards.Add(_shuriken);
            _allCards.Add(_trap);
            _allCards.Add(_spin);
            _allCards.Add(_brightZone);
        }

        private void OnEnable()
        {
            _gamePause.SetPause(true);
            Clear();
            CheckWeaponLevels();
        }

        private void OnGUI() => GetRandomCards();

        private void CheckWeaponLevels()
        {
            if (_playerUpgrade.Bow.CurrentLevel >= 8) 
                _allCards.Remove(_bow);
        }

        private void OnDisable() => _gamePause.SetPause(false);

        public void Upgrade(int id)
        {
            switch (id)
            {
                case 1:
                    _playerUpgrade.UpgradeHealth();
                    break;
                case 2: 
                    _playerUpgrade.UpgradeSpeed();
                    break;
                case 3:
                    _playerUpgrade.UpgradeRegeneration();
                    break;
                case 4:
                    _playerUpgrade.UpgradeRangeExp();
                    break;
                case 5:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.Bow);
                    break;
                case 6:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.FrozenFire);
                    break;
                case 7:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.SpinWeapon);
                    break;
                case 8:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.BrightZoneWeapon);
                    break;
                case 9:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.Shuriken);
                    break;
                case 10:
                    _playerUpgrade.UpgradeWeapon(_playerUpgrade.Trap);
                    break;
            }
        }

        private void GetRandomCards()
        {
            while (_cardsInPull.Count < 3)
            {
                CardHolder randomCard = RandomCard();
                if (randomCard.gameObject.activeSelf) continue;
                _cardsInPull.Add(randomCard);
                randomCard.gameObject.SetActive(true);
            }
        }

        private void Clear()
        {
            _cardsInPull.Clear();
            for (int i = 0; i < _allCards.Count; i++) 
                _allCards[i].gameObject.SetActive(false);
        }

        private CardHolder RandomCard() => _allCards[Random.Range(0, _allCards.Count)];

        [Inject] private void Construct(GamePause gamePause, PlayerUpgrade playerUpgrade)
        {
            _gamePause = gamePause;
            _playerUpgrade = playerUpgrade;
        }
    }
}