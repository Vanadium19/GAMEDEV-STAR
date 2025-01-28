using System;

namespace Game.Components
{
    public interface IDamagable
    {
        public event Action<IDamagable> Died;
        
        public void TakeDamage(int damage);
    }
}