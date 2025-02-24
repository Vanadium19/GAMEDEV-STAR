using R3;
using UnityEngine;

namespace Game.Core.Components
{
    public class HealthComponent : EntityComponent, IDamagable
    {
        private readonly int _maxHealth;

        private readonly ReactiveProperty<int> _currentHealth = new();
        private readonly ReactiveProperty<bool> _isDead = new();

        public HealthComponent(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth.Value = maxHealth;
        }

        public int MaxHealth => _maxHealth;
        public ReadOnlyReactiveProperty<int> CurrentHealth => _currentHealth;
        public ReadOnlyReactiveProperty<bool> IsDead => _isDead;

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                return;

            if (_currentHealth.Value <= 0)
                return;

            _currentHealth.Value = Mathf.Max(0, _currentHealth.Value - damage);

            if (_currentHealth.Value <= 0)
                _isDead.Value = true;
        }

        public void ResetHealth()
        {
            _isDead.Value = false;
            _currentHealth.Value = _maxHealth;
        }
    }
}