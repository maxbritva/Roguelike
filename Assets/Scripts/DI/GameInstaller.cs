using Game.Core;
using Game.Core.ExperienceSystem;
using Game.Core.LevelSystem;
using Game.FX.DamageText;
using Game.Player;
using Game.Player.Weapons.Bow;
using Game.Player.Weapons.FrozenFire;
using Game.Player.Weapons.Shuriken;
using Game.Player.Weapons.Trap;
using UnityEngine;
using Zenject;

namespace DI
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private PlayerController _playerController;
		[SerializeField] private PlayerHealth _playerHealth;
		[SerializeField] private DamageTextSpawner _damageTextSpawner;
		[SerializeField] private GameTimer _gameTimer;
		[SerializeField] private LevelSystem _levelSystem;
		[SerializeField] private ExperienceSystem _experienceSystem;
		[SerializeField] private ExperienceSpawner _experienceSpawner;
		[SerializeField] private Bow _bow;
		[SerializeField] private ShurikenWeapon _shurikenWeapon;
		[SerializeField] private FrozenFire _frozenFire;
		[SerializeField] private TrapPlacer _trapPlacer;
		[SerializeField] private GamePause _gamePause;

		public override void InstallBindings()
		{
			PlayerBinds();
			Container.Bind<DamageTextSpawner>().FromInstance(_damageTextSpawner).AsSingle().NonLazy();
			Container.Bind<GameTimer>().FromInstance(_gameTimer).AsSingle().NonLazy();
			Container.Bind<LevelSystem>().FromInstance(_levelSystem).AsSingle().NonLazy();
			Container.Bind<ExperienceSystem>().FromInstance(_experienceSystem).AsSingle().NonLazy();
			Container.Bind<ExperienceSpawner>().FromInstance(_experienceSpawner).AsSingle().NonLazy();
			Container.Bind<GamePause>().FromInstance(_gamePause).AsSingle().NonLazy();
		}

		private void PlayerBinds()
		{
			Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle().NonLazy();
			Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle().NonLazy();
			Container.Bind<Bow>().FromInstance(_bow).AsSingle().NonLazy();
			Container.Bind<ShurikenWeapon>().FromInstance(_shurikenWeapon).AsSingle().NonLazy();
			Container.Bind<FrozenFire>().FromInstance(_frozenFire).AsSingle().NonLazy();
			Container.Bind<TrapPlacer>().FromInstance(_trapPlacer).AsSingle().NonLazy();
		}
	}
}