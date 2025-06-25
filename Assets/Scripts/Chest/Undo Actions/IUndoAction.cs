namespace ChestSystem.Chest
{
    public interface IUndoAction
    {
        void Undo();
        ChestController GetChestController();
    }
}


