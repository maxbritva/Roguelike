using Game.FX.DamageText;
using UnityEngine;
using Zenject;

namespace Game.Player.Weapons.Bow
{
	public sealed class Arrow : Throw
	{
		private Bow _bow;
		protected override void OnEnable()
		{
			base.OnEnable();
			Timer = new WaitForSeconds(_bow.Duration);
			Damage = _bow.Damage;
		}
		private void Update() => transform.position += transform.up * (-1 * (_bow.Speed * Time.deltaTime));
		
		[Inject] private void Construct(Bow bow, DamageTextSpawner damageTextSpawner) => _bow = bow;
	}
}