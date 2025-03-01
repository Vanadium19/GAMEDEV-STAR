using Game.Scripts.Common;
using R3;

namespace Game.Core.Components
{
    public interface IHealable
    {
        public void TakeHeal(int heal);
    }
}
