using System.Collections;
using System.Collections.Generic;
using ChestSystem.Chest;
using TMPro;
using UnityEngine;

namespace ChestSystem.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private GameObject confirmationPanel;
        [SerializeField] private TextMeshProUGUI gemsText;

        public void ShowConfirmationPanel()
        {
            confirmationPanel.SetActive(true);
        }

        public void SetGemsNeeded(int gems)
        {
            gemsText.text = gems.ToString();
        }
    }
}


