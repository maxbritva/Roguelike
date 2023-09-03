using UnityEngine;
using Zenject;

namespace Game.Player.Weapons.Shuriken
{
	public class Shuriken : Throw
	{
		[SerializeField] private Transform _sprite;
		private ShurikenWeapon _shurikenWeapon;

		protected override void OnEnable()
		{
			base.OnEnable();
			Timer = new WaitForSeconds(_shurikenWeapon.Duration);
			Damage = _shurikenWeapon.Damage;
		}

		private void Update()
		{
			_sprite.transform.Rotate(0, 0, 500f * Time.deltaTime);
			transform.position += transform.up * (_shurikenWeapon.Speed * Time.deltaTime);
		}

		[Inject] private void Construct(ShurikenWeapon shurikenWeapon) => _shurikenWeapon = shurikenWeapon;
	}
}