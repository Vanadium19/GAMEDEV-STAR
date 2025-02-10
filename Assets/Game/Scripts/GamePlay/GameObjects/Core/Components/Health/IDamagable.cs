using System;

namespace Game.Core.Components
{
    public interface IDamagable
    {
        public event Action Died;
        public void TakeDamage(int damage);
    }
}