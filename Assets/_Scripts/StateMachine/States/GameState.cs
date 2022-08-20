using Dungeons.Player;
using Dungeons.UI;
using UnityEngine;

namespace Dungeons.States
{
    public class GameState : BaseState
    {
        private PlayerController playerController;

        public GameState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            playerController = GameObject.FindObjectOfType<PlayerController>();
            playerController.SwitchState(true);

            UIManager.Instance.ShowHUD();
        }

        public override void ExitState()
        {

        }
    }
}

