using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
        private ChestController chestController;
        private List<ChestController> chestControllers;
        private Queue<ChestController> unlockQueue = new Queue<ChestController>();
        private ChestController currentlyUnlocking = null;
        public ChestService() { chestControllers = new List<ChestController>(); }

        public void CreateChest(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel)
        {

            switch (chestScriptableObject.ChestType)
            {
                case ChestType.RARE:
                    chestController = new RareChest(chestScriptableObject, chestView, chestPanel);
                    chestControllers.Add(chestController);
                    break;

                case ChestType.LEGENDARY:
                    chestController = new LegendaryChest(chestScriptableObject, chestView, chestPanel);
                    chestControllers.Add(chestController);
                    break;

                case ChestType.COMMON:
                    chestController = new CommonChest(chestScriptableObject, chestView, chestPanel);
                    chestControllers.Add(chestController);
                    break;

                case ChestType.EPIC:
                    chestController = new EpicChest(chestScriptableObject, chestView, chestPanel);
                    chestControllers.Add(chestController);
                    break;
            }
        }

        public void EnqueueChest(ChestController chestController)
        {
            if (currentlyUnlocking == null)
            {
                StartUnlocking(chestController);
            }
            else
            {
                Debug.Log("Added to queue");
                unlockQueue.Enqueue(chestController);
            }
        }

        private void StartUnlocking(ChestController chest)
        {
            currentlyUnlocking = chest;
            chest.ChangeChestState(ChestState.Unlocking);
            chest.MoveToState(ChestState.Unlocking);
        }

        public void OnChestUnlocked(ChestController unlockedChest)
        {
            if (currentlyUnlocking == unlockedChest)
            {
                currentlyUnlocking = null;

                if (unlockQueue.Count > 0)
                {
                    StartUnlocking(unlockQueue.Dequeue());
                }
            }
        }

        public bool IsAnyChestUnlocking()
        {
            foreach (var chest in chestControllers)
            {
                if (chest != null && chest.chestScriptableObject.ChestState == ChestState.Unlocking)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveChest(ChestController controller)
        {
            if (chestControllers.Contains(controller))
                chestControllers.Remove(controller);
        }
    }
}


