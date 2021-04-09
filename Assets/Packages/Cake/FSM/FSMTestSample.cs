using UnityEngine;

namespace Cake.FSM
{
    public class FSMTestSample : MonoBehaviour
    {
        [SerializeField] private bool m_hasALock;

        private StateMachine m_fsm;
        private Open m_openState;
        private Closed m_closedState;
        private Locked m_lockedState;

        private void Start()
        {
            m_openState = new Open();
            m_closedState = new Closed();
            m_lockedState = new Locked();

            m_fsm = new StateMachine(m_openState, m_closedState, m_lockedState)
                .AddTransition(m_openState, m_closedState)
                .AddTransition(m_closedState, m_openState)
                .AddTransition(m_lockedState, m_closedState)
                .AddTransition(m_closedState, m_lockedState, () =>
                {
                    return m_hasALock;
                })
                .SetCurrentState(m_openState);
        }

        [ContextMenu("Test")]
        private void Test()
        {
            m_fsm.TransitionTo(m_closedState);
            m_fsm.TransitionTo(m_lockedState);

            m_fsm.TransitionTo(m_closedState);
            m_fsm.TransitionTo(m_openState);
            m_hasALock = false;
            m_fsm.TransitionTo(m_closedState);
            m_fsm.TransitionTo(m_lockedState);
        }
    }
}