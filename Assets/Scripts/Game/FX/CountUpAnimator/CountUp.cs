using System.Collections;
using TMPro;
using UnityEngine;

namespace Game.FX.CountUpAnimator
{
    [RequireComponent(typeof(AudioSource))]
    public class CountUp : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        private WaitForSeconds _tick = new WaitForSeconds(0.1f);
        private float _targetTimer;
        private const float AnimationDuration = 2.5f;

        private IEnumerator SoundScore() {
            _targetTimer = 0f;
            _audioSource.pitch = 1f;
            while (_targetTimer <=2.5f) {
                _audioSource.Play();
                _audioSource.pitch += 0.1f;
                _targetTimer += 0.1f;
                yield return _tick;
            }
        }
        
        public IEnumerator Activate(float targetValue, float currentValue, TextMeshProUGUI targetText) {
            StartCoroutine(SoundScore());
            float rate = Mathf.Abs(targetValue - currentValue) / AnimationDuration;
            while (currentValue != targetValue) {
                currentValue = Mathf.MoveTowards(currentValue, targetValue, rate * Time.deltaTime);
                targetText.text = ((int)currentValue).ToString();
                yield return null;
            }
        }
    }
}