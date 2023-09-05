using Game.Player.Weapons;
using Game.Player.Weapons.Bow;
using Game.Player.Weapons.FrozenFire;
using Game.Player.Weapons.Shuriken;
using Game.Player.Weapons.Trap;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerUpgrade : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private PlayerController _playerController;
        [Header("Weapons")]
        private BrightZoneWeapon _brightZoneWeapon;
        private FrozenFire _frozenFire;
        private SpinWeapon _spinWeapon;
        private ShurikenWeapon _shurikenWeapon;
        private TrapPlacer _trap;
        private Bow _bow;
        public Bow Bow => _bow;
        public BrightZoneWeapon BrightZoneWeapon => _brightZoneWeapon;
        public FrozenFire FrozenFire => _frozenFire;
        public SpinWeapon SpinWeapon => _spinWeapon;
        public ShurikenWeapon Shuriken => _shurikenWeapon;
        public TrapPlacer Trap => _trap;

        public float RangeExp { get; private set; }

        private void Start() => RangeExp = 1.5f;

        public void UpgradeRegeneration() => _playerHealth.RegenerationUpgrade();
        public void UpgradeSpeed() => _playerController.UpgradeSpeed();
        public void UpgradeHealth() => _playerHealth.UpgradeHealth();
        public void UpgradeRangeExp() => RangeExp += 0.5f;

        public void UpgradeWeapon(BaseWeapon target)
        {
            if(target.gameObject.activeSelf)
                target.LevelUp();
            else
                ActivateWeapon(target);
        }

        private void ActivateWeapon(BaseWeapon target) => target.gameObject.SetActive(true);

        [Inject] private void Construct(PlayerHealth health, PlayerController controller, Bow bow, SpinWeapon spin, 
            FrozenFire frozen, ShurikenWeapon shuriken, TrapPlacer trap, BrightZoneWeapon bright)
        {
            _playerController = controller;
            _brightZoneWeapon = bright;
            _playerHealth = health;
            _shurikenWeapon = shuriken;
            _frozenFire = frozen;
            _spinWeapon = spin;
            _trap = trap;
            _bow = bow;
        }
    }
}