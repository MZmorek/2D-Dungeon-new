using UnityEngine;

namespace Dungeons.States
{
    public class StateMachine : MonoBehaviour
    {
        BaseState currentState;

        private void Start ()
        {
            EnterState(new MenuState(this));
        }
        public void EnterState(BaseState newState)
        {
            if (currentState != null)
            {
                currentState.ExitState();
            }
            currentState = newState;

            currentState.EnterState();

        }

        private void OnDestroy()
        {
            currentState.ExitState();
        }
    }
}