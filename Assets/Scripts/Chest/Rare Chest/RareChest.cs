using UnityEngine.Sprites;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class RareChest : ChestController
    {
        private RareChestStateMachine rareChestStateMachine;

        public RareChest(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel) : base(chestScriptableObject, chestView, chestPanel)
        {
            this.chestView.SetController(this);
            CreateStateMachine();
            rareChestStateMachine.ChangeState(ChestState.Locked);
            chestScriptableObject.ChestState = ChestState.Locked;
        }

        private void CreateStateMachine() => rareChestStateMachine = new RareChestStateMachine(this);

        public override void MoveToState(ChestState chestState) => rareChestStateMachine.ChangeState(chestState);

        public override void UpdateChest()
        {
            rareChestStateMachine.Update();
        }
    }
}


