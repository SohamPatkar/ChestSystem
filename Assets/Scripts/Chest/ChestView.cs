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
            EventService.Instance.OnOpenWithGems.AddListener(chestController.OpenWithGems);
            EventService.Instance.OnOpenWithoutGems.AddListener(chestController.OpenWithoutGems);
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

        public void SetTimerText(string time)
        {
            timerText.text = time;
        }

        public void SetController(ChestController controller)
        {
            chestController = controller;
        }

        void OnDisable()
        {
            EventService.Instance.OnOpenWithGems.RemoveListener(chestController.OpenWithGems);
            EventService.Instance.OnOpenWithoutGems.RemoveListener(chestController.OpenWithoutGems);
        }
    }
}


