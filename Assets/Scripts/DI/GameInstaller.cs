using Game.Core;
using Game.Core.ExperienceSystem;
using Game.Core.LevelSystem;
using Game.Core.Loot;
using Game.Core.Upgrades;
using Game.FX.CountUpAnimator;
using Game.FX.DamageText;
using Game.Player;
using Game.UI;
using UnityEngine;
using Zenject;

namespace DI
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private DamageTextSpawner _damageTextSpawner;
		[SerializeField] private ExperienceSpawner _experienceSpawner;
		[SerializeField] private ExperienceSystem _experienceSystem;
		[SerializeField] private UpgradeWindow _upgradeWindow;
		[SerializeField] private PlayerUpgrade _playerUpgrade;
		[SerializeField] private LevelSystem _levelSystem;
		[SerializeField] private GameTimer _gameTimer;
		[SerializeField] private GamePause _gamePause;
		[SerializeField] private LootSpawner _lootSpawner;
		[SerializeField] private RandomSpawnPoint _randomSpawnPoint;
		[SerializeField] private CoinsUpdater _coinsUpdater;
		[SerializeField] private CountUp _countUp;

		public override void InstallBindings()
		{
			Container.Bind<DamageTextSpawner>().FromInstance(_damageTextSpawner).AsSingle().NonLazy();
			Container.Bind<GameTimer>().FromInstance(_gameTimer).AsSingle().NonLazy();
			Container.Bind<LevelSystem>().FromInstance(_levelSystem).AsSingle().NonLazy();
			Container.Bind<ExperienceSystem>().FromInstance(_experienceSystem).AsSingle().NonLazy();
			Container.Bind<ExperienceSpawner>().FromInstance(_experienceSpawner).AsSingle().NonLazy();
			Container.Bind<GamePause>().FromInstance(_gamePause).AsSingle().NonLazy();
			Container.Bind<UpgradeWindow>().FromInstance(_upgradeWindow).AsSingle().NonLazy();
			Container.Bind<PlayerUpgrade>().FromInstance(_playerUpgrade).AsSingle().NonLazy();
			Container.Bind<LootSpawner>().FromInstance(_lootSpawner).AsSingle().NonLazy();
			Container.Bind<RandomSpawnPoint>().FromInstance(_randomSpawnPoint).AsSingle().NonLazy();
			Container.Bind<CoinsUpdater>().FromInstance(_coinsUpdater).AsSingle().NonLazy();
			Container.Bind<CountUp>().FromInstance(_countUp).AsSingle().NonLazy();
		}
		
	}
}