using Game.Player;
using Menu;
using Menu.Shop;
using Menu.UI;
using UnityEngine;
using Zenject;

namespace DI
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private Shop _shop;
        [SerializeField] private UpgradeLoader _upgradeLoader;
        [SerializeField] private SaveProgress _saveProgress;
        [SerializeField] private MenuUIUpdater _menuUIUpdater;
        [SerializeField] private PlayerData _playerData;
        public override void InstallBindings()
        {
            Container.Bind<Shop>().FromInstance(_shop).AsSingle().NonLazy();
            Container.Bind<UpgradeLoader>().FromInstance(_upgradeLoader).AsSingle().NonLazy();
            Container.Bind<SaveProgress>().FromInstance(_saveProgress).AsSingle().NonLazy();
            Container.Bind<MenuUIUpdater>().FromInstance(_menuUIUpdater).AsSingle().NonLazy();
            Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle().NonLazy();
        }
    }
}