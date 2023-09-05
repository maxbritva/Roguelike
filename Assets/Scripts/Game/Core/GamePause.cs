using UnityEngine;

namespace Game.Core
{
    public class GamePause : MonoBehaviour
    {
        private LevelSystem.LevelSystem _levelSystem;
        public void SetPause(bool value)
        {
            //Time.timeScale = value ? 0f : 1f;
        }
        
        
    }
}