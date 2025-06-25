using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class LockedState : IState
    {
        public ChestController Owner { get; set; }
        private ChestStateMachine stateMachine;

        public LockedState(ChestStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void OnEnterState()
        {
            Owner.GetChestView().SetChestImage(Owner.chestScriptableObject.ChestClosed);
            Owner.GetChestView().SetSuggestedText("Open");
            Owner.GetChestView().SetTimerText(Owner.FormatTime(Owner.TimerText()));
        }

        public void OnExitState()
        {

        }

        public void Update()
        {

        }

        public void OnClick()
        {
            Owner.GetChestView().ShowConfirmationPanel();
            Owner.GetChestView().SetGemsNeeded(Owner.GetGemsRequired());
        }
    }
}


