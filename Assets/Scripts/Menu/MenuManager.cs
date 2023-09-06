using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
	public class MenuManager : MonoBehaviour
	{
		public void GameStart() => SceneManager.LoadSceneAsync(1);
	}
}