namespace ChestSystem.Chest
{
    public class UndoUnlocked : IUndoAction
    {
        private ChestController chestController;

        public UndoUnlocked(ChestController chestController)
        {
            this.chestController = chestController;
        }

        public ChestController GetChestController()
        {
            return chestController;
        }

        public void Undo()
        {
            chestController.SetChestState(ChestState.Locked);
        }
    }
}


