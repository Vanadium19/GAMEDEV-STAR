using Game.Scripts.Common;
using R3;

namespace Game.Core.Components
{
    public interface IDamagable
    {
        public TeamType Team { get; }

        public void TakeDamage(int damage);
    }
}