using System.Collections;
using System.Collections.Generic;
using ChestSystem.Chest;
using ChestSystem.Main;
using TMPro;
using UnityEngine;

namespace ChestSystem.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private GameObject confirmationPanel;
        [SerializeField] private TextMeshProUGUI gemsText;
        private ChestController chestController;

        public void GetChestController(ChestController chestController)
        {
            this.chestController = chestController;
        }

        public void ShowConfirmationPanel()
        {
            confirmationPanel.SetActive(true);
        }

        public void SetGemsNeeded(int gems)
        {
            gemsText.text = gems.ToString();
        }

        public void OpenChestWithoutGems()
        {
            confirmationPanel.SetActive(false);
            chestController.ChangeChestState(ChestState.Unlocking);
            chestController.MoveToState(ChestState.Unlocking);
        }
    }
}


