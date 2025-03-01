using Game.Core;

namespace Game.Content.Traps
{
    public interface IInteractableArea
    {
        public void Enter(IEntity entity);
        public void Exit(IEntity entity);
    }
}