using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerData : MonoBehaviour
    {
        public float MaxHealth { get; private set; }
        public float Speed { get; private set; }
        public float Regeneration { get; private set; }
        public float RangeExp { get; private set; }

        private void Start()
        {
            MaxHealth = 100f;
            Speed = 4f;
            Regeneration = 1f;
            RangeExp = 1.5f;
        }
    }
}