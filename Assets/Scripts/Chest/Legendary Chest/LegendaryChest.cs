using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class LegendaryChest : ChestController
    {
        public LegendaryChest(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel) : base(chestScriptableObject, chestView, chestPanel)
        {
            this.chestView.SetController(this);
        }

        public void Update()
        {

        }

        public override void OnClickChest()
        {
            Debug.Log("TWO");
        }

    }
}
