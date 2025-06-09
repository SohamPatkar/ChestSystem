using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using ChestSystem.Main;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        private ChestController chestController;
        [SerializeField] private Image chestSprite;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI suggestedText;

        void Start()
        {

        }

        void Update()
        {
            chestController.UpdateChest();
        }

        public void SetChestImage(Sprite image)
        {
            chestSprite.sprite = image;
        }

        public void OnClickButton()
        {
            GameService.Instance.UIService.GetChestController(chestController);
            chestController.OnClickChest();
        }

        public void SetTimerText(float time)
        {
            timerText.text = "" + (int)time;
        }

        public void SetController(ChestController controller)
        {
            chestController = controller;
        }
    }
}


