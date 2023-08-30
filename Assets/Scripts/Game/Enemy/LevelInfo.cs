using System;
using Game.Enemy.Spawners;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
	[CreateAssetMenu(fileName = "LevelInfo", menuName = "ScriptableObject/LevelInfo")]
	public class LevelInfo : ScriptableObject
	{
		private SlimeSpawner _slimeSpawner;
		private PumaSpawner _pumaSpawner;
		[SerializeField] private bool _slimeActivate;
		[SerializeField] private bool _pumaActivate;
		[Inject] private void Construct(SlimeSpawner slimeSpawner, PumaSpawner pumaSpawner)
		{
			_slimeSpawner = slimeSpawner;
			_pumaSpawner = pumaSpawner;
		}

		public void Activate()
		{
			if(_slimeActivate)
				_slimeSpawner.Activate();
			if(_pumaActivate)
				_pumaSpawner.Activate();
		}
		public void Deactivate()
		{
			if(_slimeActivate)
				_slimeSpawner.Deactivate();
			if(_pumaActivate)
				_pumaSpawner.Deactivate();
		}
	}
}