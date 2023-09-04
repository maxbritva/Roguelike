using System.Collections;
using System.Collections.Generic;
using Game.Enemy;
using UnityEngine;

namespace Game.Player.Weapons
{
    public class BrightZoneWeapon : BaseWeapon
    {
        [SerializeField] private float _range;
        [SerializeField] private Transform _targetContainer;
        private List<EnemyHealth> _enemiesInZone = new List<EnemyHealth>();
        private Coroutine _attackRoutine;
        private WaitForSeconds _timeBetweenAttack;

        private void OnEnable() => Activate();

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out EnemyHealth health));
            {
                if(health == null) return;
                _enemiesInZone.Add(health);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out EnemyHealth health));
                _enemiesInZone.Remove(health);
        }

        private void Activate()
        {
            SetStats(0);
            _attackRoutine = StartCoroutine(CheckZone());
        }

        private void Deactivate() => StopCoroutine(_attackRoutine);

        protected override void SetStats(int value)
        {
            base.SetStats(CurrentLevel-1);
            _timeBetweenAttack = new WaitForSeconds(WeaponStats[CurrentLevel-1].TimeBetweenAttack);
            _range = WeaponStats[CurrentLevel-1].Range;
            _targetContainer.transform.localScale = Vector3.one * _range;
        }
        

        private IEnumerator CheckZone()
        {
            while (true)
            {
                for (int i = 0; i < _enemiesInZone.Count; i++)
                {
                    _enemiesInZone[i].TakeDamage(_damage);
                    _damageTextSpawner.Activate(transform,(int)_damage);
                }
                yield return _timeBetweenAttack;
            }
        }
    }
}