using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Cake.FSM
{
    public abstract class AState
    {
        public StateMachine Owner
        {
            get;
            private set;
        }

        public void SetOwner(StateMachine p_owner)
        {
            Owner = p_owner;
        }

        public abstract void Update();

        public abstract void OnEnter();
        public abstract void OnExit();
    }

    public class StateMachine
    {
        private AState m_currentState;
        private List<AState> m_states = new List<AState>();
        // <from, <to, condition>>
        private Dictionary<AState, Dictionary<AState, Func<bool>>> m_transitions = new Dictionary<AState, Dictionary<AState, Func<bool>>>();

        //TODO: custom transition between two states not managed yet
        // private ATransition m_currentTransition

        public StateMachine(params AState[] p_states)
        {
            AddStates(p_states);
        }

        public StateMachine SetCurrentState(AState p_state)
        {
            if (!m_states.Contains(p_state))
            {
                return null;
            }

            m_currentState = p_state;
            return this;
        }

        protected StateMachine AddStates(params AState[] p_states)
        {
            for (int i = 0; i < p_states.Length; i++)
            {
                p_states[i].SetOwner(this);
                m_states.Add(p_states[i]);
            }

            return this;
        }

        public StateMachine AddTransition(AState p_from, AState p_to, Func<bool> p_condition = null)
        {
            // Initialization
            if (m_transitions == null)
            {
                m_transitions = new Dictionary<AState, Dictionary<AState, Func<bool>>>();
            }

            if (!m_transitions.ContainsKey(p_from))
            {
                m_transitions.Add(p_from, new Dictionary<AState, Func<bool>>());
            }

            // Add state
            m_transitions[p_from].Add(p_to, p_condition);

            return this;
        }

        public bool TransitionTo(AState p_to)
        {
            if (!m_transitions.ContainsKey(m_currentState))
            {
                Debug.Log("Current state has no transitions");
                return false;
            }

            if (!m_transitions[m_currentState].ContainsKey(p_to))
            {
                return false;
            }

            var condition = m_transitions[m_currentState][p_to];
            if (condition != null && !condition.Invoke())
            {
                return false;
            }

            m_currentState.OnExit();
            m_currentState = p_to;
            m_currentState.OnEnter();

            return true;
        }

        public void Update()
        {
            m_currentState.Update();
        }
    }

    public class Open : AState
    {
        public override void OnEnter()
        {
            Debug.Log("Door is now opened");
        }

        public override void OnExit()
        {

        }

        public override void Update()
        {

        }
    }

    public class Closed : AState
    {
        public override void OnEnter()
        {
            Debug.Log("Door is now closed");
        }

        public override void OnExit()
        {

        }

        public override void Update()
        {

        }
    }

    public class Locked : AState
    {
        public override void OnEnter()
        {
            Debug.Log("Door is now locked");
        }

        public override void OnExit()
        {

        }

        public override void Update()
        {

        }
    }
}