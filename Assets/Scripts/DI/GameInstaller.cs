using Game.Core.Pool;
using Game.Player;
using UnityEngine;
using Zenject;

namespace DI
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private PlayerController _playerController;
		[SerializeField] private PlayerHealth _playerHealth;
		[SerializeField] private ObjectPool _enemyPool;
		
		public override void InstallBindings()
		{
			Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle().NonLazy();
			Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle().NonLazy();
			Container.Bind<ObjectPool>().FromInstance(_enemyPool).AsSingle().NonLazy();
		}
	}
}