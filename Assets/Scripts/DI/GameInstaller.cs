using Game.Core.LevelSystem;
using Game.Enemy.Spawners;
using Game.FX.DamageText;
using Game.Player;
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
		[SerializeField] private SlimeSpawner _slimeSpawner;
		[SerializeField] private PumaSpawner _pumaSpawner;

		public override void InstallBindings()
		{
			Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle().NonLazy();
			Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle().NonLazy();
			Container.Bind<DamageTextSpawner>().FromInstance(_damageTextSpawner).AsSingle().NonLazy();
			Container.Bind<GameTimer>().FromInstance(_gameTimer).AsSingle().NonLazy();
			Container.Bind<LevelSystem>().FromInstance(_levelSystem).AsSingle().NonLazy();
			Container.Bind<SlimeSpawner>().FromInstance(_slimeSpawner).AsSingle().NonLazy();
			Container.Bind<PumaSpawner>().FromInstance(_pumaSpawner).AsSingle().NonLazy();
		}
	}
}