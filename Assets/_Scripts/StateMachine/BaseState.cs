namespace Dungeons.States
{
    public abstract class BaseState
    {
        protected StateMachine myStateMachine;

        protected virtual void Initialize(StateMachine stateMachine)
        {
            myStateMachine = stateMachine;
        }

        public abstract void EnterState();

        public abstract void UpdateState();

        public abstract void ExitState();
    }
}
