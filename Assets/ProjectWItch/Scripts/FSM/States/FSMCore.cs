using Overtime.FSM.Example;
using Overtime.FSM;
using UnityEngine;

namespace ProjectWitch.Scripts.FSM.States
{
    public class FSMCore : MonoBehaviour
    {
        private StateMachine<FSMCore, PlayerStateID, PlayerStateTransition> m_FSM;
        public StateMachine<FSMCore, PlayerStateID, PlayerStateTransition> FSM
        {
            get { return m_FSM; }
        }

        public PlayerStateID m_InitialState;

        public ScriptableObject[] m_States;

        public bool m_Debug;

        void OnDestroy()
        {
            m_FSM.Destroy();
        }

        void Start()
        {
            m_FSM = new StateMachine<FSMCore, PlayerStateID, PlayerStateTransition>(this, m_States, m_InitialState, m_Debug);
        }

        void Update()
        {
            m_FSM.Update();
        }

        void FixedUpdate()
        {
            m_FSM.FixedUpdate();
        }

#if UNITY_EDITOR
        void OnGUI()
        {
            if (m_Debug)
            {
                GUI.color = Color.white;
                GUI.Label(new Rect(0.0f, 0.0f, 500.0f, 500.0f), string.Format("Example State: {0}", FSM.CurrentStateName));
            }
        }
#endif
    }
}