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

        }

        public ChestView GetChestView()
        {
            return chestView;
        }
    }
}


