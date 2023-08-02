using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWitch.Scripts.FSM.States
{
    public class PlayerIdleState : PlayerStateBase
    {
        #region Variable

        /// <summary>
        /// Component that use to check move input that is given by player.
        /// </summary>
        private IMoveInput _playerMoveInput = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _playerMoveInput = gameObject.GetComponent<IMoveInput>();
        }

        #endregion

        #region PlayerStateBase

        public override void BuildTransitions()
        {
            AddTransition(PlayerStateTransition.START_RUN, PlayerStateID.RUN);
        }

        public override void Enter()
        {
            Debug.Log(_playerMoveInput);

            Debug.Log("Enter Idle");
        }

        public override void Exit()
        {
            Debug.Log("Exit Idle");
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                MakeTransition(PlayerStateTransition.START_RUN);
            }
        }

        #endregion
    }
}