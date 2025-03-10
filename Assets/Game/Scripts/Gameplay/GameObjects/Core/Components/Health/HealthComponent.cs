using Game.Modules.Entities;
using Game.Scripts.Common;
using R3;
using UnityEngine;

namespace Game.Core.Components
{
    public class HealthComponent : EntityComponent, IDamagable, IHealable, IHealth
    {
        private readonly TeamType _team;
        private readonly int _maxHealth;

        private readonly ReactiveProperty<int> _currentHealth = new();
        private readonly ReactiveProperty<bool> _isDead = new();

        public HealthComponent(int maxHealth, TeamType team)
        {
            _team = team;
            _maxHealth = maxHealth;
            _currentHealth.Value = maxHealth;
        }

        public TeamType Team => _team;
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

            Debug.Log($"Damage taken: {damage}");

            if (_currentHealth.Value <= 0)
                _isDead.Value = true;
        }

        public void TakeHeal(int heal)
        {
            if (heal <= 0)
                return;

            if (_currentHealth.Value <= 0)
                return;

            _currentHealth.Value = Mathf.Max(_maxHealth, _currentHealth.Value + heal);
        }

        public void ResetHealth()
        {
            _isDead.Value = false;
            _currentHealth.Value = _maxHealth;
        }
    }
}