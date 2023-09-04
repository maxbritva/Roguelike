using UnityEngine;

namespace Game.Core
{
    public class GamePause : MonoBehaviour
    {
        public void SetPause(bool value) => Time.timeScale = value ? 1f : 0f;
    }
}