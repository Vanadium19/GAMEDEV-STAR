using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class HealthView : MonoBehaviour
    {
        private const string AnimationId = "HealthView";
        private const float HealthAnimationFactor = 0.35f;

        [SerializeField] private Image _healthBar;
        [SerializeField] private float _fadeDuration = 1f;

        private Color _startColor;
        private bool _isFading;

        private void Awake()
        {
            _startColor = _healthBar.color;
        }

        public void SetHealth(int health, int maxHealth)
        {
            float healthValue = Mathf.Clamp01(Convert.ToSingle(health) / maxHealth);

            _healthBar.fillAmount = healthValue;

            if (healthValue < HealthAnimationFactor && !_isFading)
                StartFadeAnimation();
            else if (healthValue >= HealthAnimationFactor && _isFading)
                StopFadeAnimation();
        }

        private void StartFadeAnimation()
        {
            _isFading = true;

            _healthBar.DOFade(0f, _fadeDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear)
                .SetId(AnimationId);
        }

        private void StopFadeAnimation()
        {
            DOTween.Kill(AnimationId);

            _healthBar.color = _startColor;
            _isFading = false;
        }
    }
}