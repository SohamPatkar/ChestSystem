using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class LockedState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public LockedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState()
        {
            Owner.GetChestView().SetChestImage(Owner.chestScriptableObject.ChestClosed);
            Owner.GetChestView().SetSuggestedText("Open");
        }

        public void OnExitState()
        {

        }

        public void Update()
        {

        }
    }
}


