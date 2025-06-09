using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class UnlockedState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        public UnlockedState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState()
        {
            Owner.ChangeChestState(ChestState.Unlocking);
            Owner.GetChestView().SetChestImage(Owner.chestScriptableObject.ChestOpen);
        }

        public void OnExitState()
        {

        }

        public void Update()
        {

        }
    }
}


