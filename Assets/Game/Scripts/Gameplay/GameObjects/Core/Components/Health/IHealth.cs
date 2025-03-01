using R3;

namespace Game.Core.Components
{
    public interface IHealth
    {
        public int MaxHealth { get; }
        public ReadOnlyReactiveProperty<int> CurrentHealth { get; }
        public ReadOnlyReactiveProperty<bool> IsDead { get; }
    }
}
