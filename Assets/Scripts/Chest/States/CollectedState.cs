using System.Collections;
using System.Collections.Generic;
using ChestSystem.Main;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class CollectedState : IState
    {
        public ChestController Owner { get; set; }
        private ChestStateMachine stateMachine;

        public CollectedState(ChestStateMachine stateMachine) => this.stateMachine = stateMachine;


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

        public void OnClick()
        {

        }
    }
}

