using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
        private ChestController chestController;

        public ChestService(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel)
        {
            CreateChest(chestScriptableObject, chestView, chestPanel);
        }


        public void CreateChest(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel)
        {

            switch (chestScriptableObject.ChestType)
            {
                case ChestType.RARE:
                    chestController = new RareChest(chestScriptableObject, chestView, chestPanel);
                    break;

                case ChestType.LEGENDARY:
                    chestController = new LegendaryChest(chestScriptableObject, chestView, chestPanel);
                    break;

                case ChestType.COMMON:
                    chestController = new CommonChest(chestScriptableObject, chestView, chestPanel);
                    break;

                case ChestType.EPIC:
                    chestController = new EpicChest(chestScriptableObject, chestView, chestPanel);
                    break;
            }
        }
    }
}


