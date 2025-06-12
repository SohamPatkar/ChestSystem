using System.Collections;
using System.Collections.Generic;
using ChestSystem.Main;
using UnityEngine;

namespace ChestSystem.Chest
{
    public enum ChestType
    {
        RARE,
        LEGENDARY,
        COMMON,
        EPIC
    }

    public enum ChestState
    {
        None,
        Locked,
        Unlocking,
        Unlocked,
        Collected
    }

    public class ChestController
    {
        protected ChestView chestView;
        protected GameObject chestPanel;
        public ChestScriptableObject chestScriptableObject;

        public ChestController(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel)
        {
            this.chestScriptableObject = chestScriptableObject;
            this.chestPanel = chestPanel;
            this.chestView = Object.Instantiate(chestView.gameObject, this.chestPanel.transform).GetComponent<ChestView>();
        }

        public virtual void UpdateChest() { }

        public virtual void OnClickChest()
        {
            switch (chestScriptableObject.ChestState)
            {
                case ChestState.Locked:
                    EventService.Instance.OnShowConfirmationPanel.InvokeEvent();
                    EventService.Instance.OnSetGemsRequired.InvokeEvent(GetGemsRequired());
                    break;

                case ChestState.Unlocked:
                    EventService.Instance.OnAddGems.InvokeEvent(GemsToCollect());
                    EventService.Instance.OnAddCoins.InvokeEvent(CoinsToCollect());
                    ChangeChestState(ChestState.Collected);
                    MoveToState(ChestState.Collected);
                    break;
            }
        }

        public virtual void ChangeChestState(ChestState state)
        {
            chestScriptableObject.ChestState = state;
        }

        public virtual void MoveToState(ChestState chestState) { }

        public float TimerText()
        {
            return chestScriptableObject.Timer * 60f;
        }

        public string FormatTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void OpenWithGems(ChestController chestController)
        {
            if (chestController == this)
            {
                GameService.Instance.SubtractGems(chestController.GetGemsRequired());

                if (GameService.Instance.GetGems() < chestController.GetGemsRequired())
                {
                    return;
                }

                GameService.Instance.ChestService.PushUndo(new UndoUnlocked(this));
                chestController.ChangeChestState(ChestState.Unlocked);
                chestController.MoveToState(ChestState.Unlocked);
            }
        }

        public void OpenWithoutGems(ChestController chestController)
        {
            if (chestController == this)
            {
                chestView.SetSuggestedText("Queued");
                GameService.Instance.ChestService.EnqueueChest(this);
                GameService.Instance.ChestService.PushUndo(new UndoQueue(GameService.Instance.ChestService, this));
            }
        }

        private int GetGemsRequired()
        {
            return (int)Mathf.Ceil(chestScriptableObject.Timer / 10);
        }

        private int GemsToCollect()
        {
            return Random.Range(chestScriptableObject.MinGems, chestScriptableObject.MaxGems);
        }

        private int CoinsToCollect()
        {
            return Random.Range(chestScriptableObject.MinCoins, chestScriptableObject.MaxCoins);
        }

        public ChestView GetChestView()
        {
            return chestView;
        }
    }
}


