using Game.Core.ExperienceSystem;
using Game.Core.LevelSystem;
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
		[SerializeField] private ExperienceSystem _experienceSystem;
		[SerializeField] private ExperienceSpawner _experienceSpawner;

		public override void InstallBindings()
		{
			Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle().NonLazy();
			Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle().NonLazy();
			Container.Bind<DamageTextSpawner>().FromInstance(_damageTextSpawner).AsSingle().NonLazy();
			Container.Bind<GameTimer>().FromInstance(_gameTimer).AsSingle().NonLazy();
			Container.Bind<LevelSystem>().FromInstance(_levelSystem).AsSingle().NonLazy();
			Container.Bind<ExperienceSystem>().FromInstance(_experienceSystem).AsSingle().NonLazy();
			Container.Bind<ExperienceSpawner>().FromInstance(_experienceSpawner).AsSingle().NonLazy();
		}
	}
}