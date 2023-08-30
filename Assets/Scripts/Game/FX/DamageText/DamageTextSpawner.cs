using System.Collections;
using Game.Core.Pool;
using TMPro;
using UnityEngine;

namespace Game.FX.DamageText
{
	public class DamageTextSpawner : MonoBehaviour
	{
		[SerializeField] private ObjectPool _objectPool;
		private readonly WaitForSeconds _wait = new WaitForSeconds(0.05f);

		public void Activate(Transform target, int damage)
		{
			GameObject effect = _objectPool.GetFromPool();
			effect.transform.SetParent(transform);
			effect.transform.position = target.position + NewRandomPositionText();
			if (!effect.TryGetComponent(out TextMeshProUGUI damageText)) return;
			damageText.text = damage.ToString();
			float damageSize = damage / 15f;
			damageText.fontSize = Mathf.Clamp(damageSize, 1f,5f);
			effect.SetActive(true);
			StartCoroutine(DamageTextSetup(damageText, effect));
		}
		private Vector3 NewRandomPositionText() => new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));

		private IEnumerator DamageTextSetup(TextMeshProUGUI text, GameObject targetEffect) {
			Color color = text.color;
			color.a = 1f;
			for (float f = 1f; f >= -0.05f; f-=0.05f) 
			{
				text.color = color;
				color.a = f;
				yield return _wait;
			}
			targetEffect.SetActive(false);
		}
	}
}