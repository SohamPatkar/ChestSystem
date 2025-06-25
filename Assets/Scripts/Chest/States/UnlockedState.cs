using ChestSystem.Main;

namespace ChestSystem.Chest
{
    public class UnlockedState : IState
    {
        public ChestController Owner { get; set; }
        private ChestStateMachine stateMachine;
        public UnlockedState(ChestStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState()
        {
            Owner.GetChestView().SetChestImage(Owner.chestScriptableObject.ChestOpen);
            Owner.GetChestView().SetSuggestedText("Collect");
        }

        public void OnExitState()
        {
            GameService.Instance.ChestService.RemoveChestFromActiveChest(Owner);
        }

        public void Update()
        {

        }
        public void OnClick()
        {
            EventService.Instance.OnAddGems.InvokeEvent(Owner.GemsToCollect());
            EventService.Instance.OnAddCoins.InvokeEvent(Owner.CoinsToCollect());
            Owner.SetChestState(ChestState.Collected);
        }
    }
}


