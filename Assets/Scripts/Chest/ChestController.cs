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
                    GameService.Instance.UIService.ShowConfirmationPanel();
                    GameService.Instance.UIService.SetGemsNeeded(GetGemsRequired());
                    break;

                case ChestState.Unlocked:
                    GameService.Instance.AddGems(GemsToCollect());
                    GameService.Instance.AddCoins(CoinsToCollect());
                    break;
            }
        }

        public virtual void ChangeChestState(ChestState state)
        {
            chestScriptableObject.ChestState = state;
        }

        public virtual void MoveToState(ChestState chestState) { }

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


