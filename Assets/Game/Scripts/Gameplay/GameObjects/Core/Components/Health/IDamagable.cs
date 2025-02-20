using R3;

namespace Game.Core.Components
{
    public interface IDamagable
    {
        public ReadOnlyReactiveProperty<int> CurrentHealth { get; }
        public ReadOnlyReactiveProperty<bool> IsDead { get; }

        public void TakeDamage(int damage);
    }
}