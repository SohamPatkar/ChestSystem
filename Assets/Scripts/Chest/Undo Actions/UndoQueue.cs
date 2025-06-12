using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class UndoQueue : IUndoAction
    {
        private ChestService chestService;
        private ChestController chestController;

        public UndoQueue(ChestService chestService, ChestController chestController)
        {
            this.chestService = chestService;
            this.chestController = chestController;
        }

        public void Undo()
        {
            chestService.DequeueChest(chestController);
        }
    }
}


