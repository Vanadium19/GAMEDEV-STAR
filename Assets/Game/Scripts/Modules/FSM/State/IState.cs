namespace Game.Modules.FSM
{
    public interface IState
    {
        public void OnEnter();
        public void OnUpdate(float deltaTime);
        public void OnExit();
    }
}