using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class EpicChest : ChestController
    {
        private EpicChestStateMachine epicChestStateMachine;

        public EpicChest(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel) : base(chestScriptableObject, chestView, chestPanel)
        {
            this.chestView.SetController(this);
            CreateStateMachine();
            epicChestStateMachine.ChangeState(ChestState.Locked);
            chestScriptableObject.ChestState = ChestState.Locked;
        }

        private void CreateStateMachine() => epicChestStateMachine = new EpicChestStateMachine(this);

        public override void MoveToState(ChestState chestState) => epicChestStateMachine.ChangeState(chestState);

        public override void UpdateChest()
        {
            epicChestStateMachine.Update();
        }
    }
}
