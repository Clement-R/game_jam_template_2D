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
}