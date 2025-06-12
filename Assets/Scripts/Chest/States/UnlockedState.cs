using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using ChestSystem.Main;
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
            Owner.ChangeChestState(ChestState.Unlocked);
            Owner.GetChestView().SetChestImage(Owner.chestScriptableObject.ChestOpen);
            Owner.GetChestView().SetSuggestedText("Collect");
        }

        public void OnExitState()
        {

        }

        public void Update()
        {

        }
    }
}


