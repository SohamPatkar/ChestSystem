using System.Collections;
using System.Collections.Generic;
using ChestSystem.Chest;
using UnityEngine;

namespace ChestSystem.Utilities
{
    public class GenericStateMachine<T> where T : ChestController
    {
        protected T Owner;
        protected IState currentState;
        protected Dictionary<ChestState, IState> States = new Dictionary<ChestState, IState>();

        public GenericStateMachine(T Owner)
        {
            this.Owner = Owner;
        }

        protected void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }

        public void Update() => currentState?.Update();

        protected void ChangeState(IState newState)
        {
            currentState?.OnExitState();
            currentState = newState;
            currentState?.OnEnterState();
        }

        public void ChangeState(ChestState newState) => ChangeState(States[newState]);
    }
}


