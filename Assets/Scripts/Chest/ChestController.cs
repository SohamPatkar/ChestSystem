using System.Collections;
using System.Collections.Generic;
using ChestSystem.Main;
using Unity.VisualScripting;
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
        private ChestStateMachine chestStateMachine;
        private ChestService chestService;
        private int gemsCalcRequired = 10;

        public ChestController(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel)
        {
            this.chestScriptableObject = chestScriptableObject;
            this.chestPanel = chestPanel;
            this.chestView = Object.Instantiate(chestView.gameObject, this.chestPanel.transform).GetComponent<ChestView>();
            this.chestView.SetController(this);

            Initialize();
        }

        private void Initialize()
        {
            CreateStateMachine();
            chestView.SetChestImage(chestScriptableObject.ChestClosed);
            SetChestState(ChestState.Locked);
            chestService = GameService.Instance.ChestService;
        }

        private void CreateStateMachine() => chestStateMachine = new ChestStateMachine(this);

        public virtual void UpdateChest()
        {
            chestStateMachine.Update();
        }

        public virtual void OnClickChest()
        {
            chestStateMachine.GetState().OnClick();
        }

        public void SetChestState(ChestState state)
        {
            chestScriptableObject.ChestState = state;
            chestStateMachine.ChangeState(state);
        }

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

        public void OpenWithGems()
        {
            GameService.Instance.CurrencyService.SubtractGems(GetGemsRequired());

            if (GameService.Instance.CurrencyService.GetGems() < GetGemsRequired())
            {
                return;
            }

            chestService.PushUndo(new UndoUnlocked(this));
            SetChestState(ChestState.Unlocked);
            chestView.DeactivateConfirmationPanel();
        }

        public void OpenWithoutGems()
        {
            chestView.SetSuggestedText("Queued");
            chestService.EnqueueChest(this);
            chestService.PushUndo(new UndoQueue(GameService.Instance.ChestService, this));
            chestView.DeactivateConfirmationPanel();
        }

        public int GetGemsRequired()
        {
            return (int)Mathf.Ceil(chestScriptableObject.Timer / gemsCalcRequired);
        }

        public int GemsToCollect()
        {
            return Random.Range(chestScriptableObject.MinGems, chestScriptableObject.MaxGems);
        }

        public int CoinsToCollect()
        {
            return Random.Range(chestScriptableObject.MinCoins, chestScriptableObject.MaxCoins);
        }

        public ChestView GetChestView()
        {
            return chestView;
        }
    }
}


