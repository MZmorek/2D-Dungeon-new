using Dungeons.UI;

namespace Dungeons.States
{
    public class MenuState : BaseState
    {
        public MenuState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }
        public override void EnterState()
        {
            EventManager.EnterGameplay += EventManager_EnterGameplay;
            UIManager.Instance.ShowMainMenu();
        }

        public override void ExitState()
        {
            EventManager.EnterGameplay -= EventManager_EnterGameplay;
        }

        private void GoToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }

        private void EventManager_EnterGameplay()
        {
            GoToGame();
        }
    }
}

