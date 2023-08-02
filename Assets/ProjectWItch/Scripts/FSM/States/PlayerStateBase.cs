using Overtime.FSM;

namespace ProjectWitch.Scripts.FSM.States
{
    public enum PlayerStateID
    {
        IDLE,
        RUN,
    }

    public enum PlayerStateTransition
    {
        START_RUN,
        STOP_RUN,
    }

    public abstract class PlayerStateBase : State<FSMCore, PlayerStateID, PlayerStateTransition>
    {
        public override void BuildTransitions()
        {
            
        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}