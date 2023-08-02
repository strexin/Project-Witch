using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWitch.Scripts.FSM.States
{
    public class PlayerRunState : PlayerStateBase, IMoveData
    {
        #region IMoveData

        [field: Header("Move Data")]

        [field: SerializeField]
        public float MoveSpeed { get; set; } = default;

        [field: SerializeField]
        public float RotationSpeed { get; set; } = default;

        [field: SerializeField]
        public float MaxVelocity { get; set; } = default;

        #endregion

        #region PlayerStateBase

        public override void BuildTransitions()
        {
            AddTransition(PlayerStateTransition.STOP_RUN, PlayerStateID.IDLE);
        }

        public override void Enter()
        {
            Debug.Log("Enter Run");
        }

        public override void Exit()
        {
            Debug.Log("Exit Run");
        }

        public override void Update()
        {
            Debug.Log("Get to run");

            if(Input.GetKeyDown(KeyCode.S))
            {
                MakeTransition(PlayerStateTransition.STOP_RUN);
            }
        }

        #endregion
    }
}