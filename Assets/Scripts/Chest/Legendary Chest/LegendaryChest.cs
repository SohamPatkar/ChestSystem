using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class LegendaryChest : ChestController
    {
        private LegendaryChestStateMachine legendaryChestStateMachine;

        public LegendaryChest(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel) : base(chestScriptableObject, chestView, chestPanel)
        {
            this.chestView.SetController(this);
            CreateStateMachine();
            legendaryChestStateMachine.ChangeState(ChestState.Locked);
            chestScriptableObject.ChestState = ChestState.Locked;
        }

        private void CreateStateMachine() => legendaryChestStateMachine = new LegendaryChestStateMachine(this);

        public override void MoveToState(ChestState chestState) => legendaryChestStateMachine.ChangeState(chestState);

        public override void UpdateChest()
        {
            legendaryChestStateMachine.Update();
        }

    }
}
