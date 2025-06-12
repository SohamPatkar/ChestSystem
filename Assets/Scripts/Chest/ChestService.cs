using System.Collections;
using System.Collections.Generic;
using ChestSystem.Main;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
        private ChestController chestController;
        private List<ChestController> chestControllers;
        private Stack<IUndoAction> undoState;
        private Queue<ChestController> unlockQueue;
        private ChestController currentlyUnlocking = null;

        public ChestService()
        {
            chestControllers = new List<ChestController>();
            undoState = new Stack<IUndoAction>();
            unlockQueue = new Queue<ChestController>();
        }

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
            else if (unlockQueue.Count == 0)
            {
                EventService.Instance.OnQueueAction.InvokeEvent("Added to Queue");
                unlockQueue.Enqueue(chestController);
            }
            else
            {
                EventService.Instance.OnQueueAction.InvokeEvent("Queue is full");
            }
        }

        public void PushUndo(IUndoAction undoAction)
        {
            undoState.Push(undoAction);
            Debug.Log(undoState.Count);
        }

        public void UndoAction()
        {
            if (undoState.Count > 0)
            {
                IUndoAction action = undoState.Pop();

                if (chestControllers.Contains(action.GetChestController()))
                {
                    action?.Undo();
                }
                else
                {
                    EventService.Instance.OnQueueAction.InvokeEvent("Nothing to Undo");
                }
            }
            else
            {
                EventService.Instance.OnQueueAction.InvokeEvent("Nothing to Undo");
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

        public void RemoveChestFromActiveChest(ChestController controller)
        {
            if (chestControllers.Contains(controller))
            {
                chestControllers.Remove(controller);
            }
        }

        public void DequeueChest(ChestController controller)
        {
            if (unlockQueue.Contains(controller))
            {
                EventService.Instance.OnQueueAction.InvokeEvent("Removed from the queue");
                unlockQueue.Dequeue();
            }
        }

    }
}


