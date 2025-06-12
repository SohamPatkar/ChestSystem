using System.Collections;
using System.Collections.Generic;
using ChestSystem.Main;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class CollectedState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public CollectedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;


        public void OnEnterState()
        {
            Object.Destroy(Owner.GetChestView().gameObject);
        }

        public void OnExitState()
        {

        }

        public void Update()
        {

        }
    }
}

