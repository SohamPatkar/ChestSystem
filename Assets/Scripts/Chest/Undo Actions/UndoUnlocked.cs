using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            chestController.ChangeChestState(ChestState.Locked);
            chestController.MoveToState(ChestState.Locked);
        }
    }
}


