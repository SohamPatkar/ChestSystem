using UnityEngine.Sprites;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class RareChest : ChestController
    {
        public RareChest(ChestScriptableObject chestScriptableObject, ChestView chestView, GameObject chestPanel) : base(chestScriptableObject, chestView, chestPanel)
        {
            this.chestView.SetController(this);
        }

        public void Update()
        {

        }

        public override void OnClickChest()
        {
            Debug.Log("One");
        }

    }
}


