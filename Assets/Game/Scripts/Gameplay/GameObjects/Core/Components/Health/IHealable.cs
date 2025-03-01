using Game.Scripts.Common;
using R3;

namespace Game.Core.Components
{
    public interface IHealable
    {
        public TeamType Team { get; }
        public int MaxHealth { get; }
        public ReadOnlyReactiveProperty<int> CurrentHealth { get; }
        
        public void TakeHeal(int heal);
    }
}
