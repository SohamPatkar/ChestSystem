using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class CommonChest : ChestController
    {
        private CommonChestStateMachine commonChestStateMachine;

        public CommonChest(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel) : base(chestScriptableObject, chestView, chestPanel)
        {
            this.chestView.SetController(this);
            CreateStateMachine();
            commonChestStateMachine.ChangeState(ChestState.Locked);
        }

        private void CreateStateMachine() => commonChestStateMachine = new CommonChestStateMachine(this);

        public override void UpdateChest()
        {
            commonChestStateMachine.Update();
        }
    }
}
