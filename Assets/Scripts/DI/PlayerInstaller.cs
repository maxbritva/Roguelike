using Game.Player;
using Game.Player.Weapons;
using Game.Player.Weapons.Bow;
using Game.Player.Weapons.FrozenFire;
using Game.Player.Weapons.Shuriken;
using Game.Player.Weapons.Trap;
using UnityEngine;
using Zenject;

namespace DI
{
	public class PlayerInstaller : MonoInstaller
	{
		[SerializeField] private PlayerController _playerController;
		[SerializeField] private PlayerHealth _playerHealth;
		[SerializeField] private PlayerData _playerData;
		[Header("Weapons")]
		[SerializeField] private BrightZoneWeapon _brightZoneWeapon;
		[SerializeField] private ShurikenWeapon _shurikenWeapon;
		[SerializeField] private FrozenFire _frozenFire;
		[SerializeField] private TrapPlacer _trapPlacer;
		[SerializeField] private SpinWeapon _spinWeapon;
		[SerializeField] private Bow _bow;
		
		public override void InstallBindings()
		{
			Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle().NonLazy();
			Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle().NonLazy();
			Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle().NonLazy();
			Container.Bind<Bow>().FromInstance(_bow).AsSingle().NonLazy();
			Container.Bind<ShurikenWeapon>().FromInstance(_shurikenWeapon).AsSingle().NonLazy();
			Container.Bind<FrozenFire>().FromInstance(_frozenFire).AsSingle().NonLazy();
			Container.Bind<TrapPlacer>().FromInstance(_trapPlacer).AsSingle().NonLazy();
			Container.Bind<SpinWeapon>().FromInstance(_spinWeapon).AsSingle().NonLazy();
			Container.Bind<BrightZoneWeapon>().FromInstance(_brightZoneWeapon).AsSingle().NonLazy();
		}
	}
}