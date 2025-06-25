using UnityEngine.UI;
using TMPro;
using UnityEngine;


namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        private ChestController chestController;
        [SerializeField] private Image chestSprite;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI suggestedText;
        [SerializeField] private GameObject confirmationPanel;
        [SerializeField] private TextMeshProUGUI gemsButtonText;
        [SerializeField] private Button openWithGems;
        [SerializeField] private Button openWithoutGems;

        void Start()
        {
            openWithGems.onClick.AddListener(chestController.OpenWithGems);
            openWithoutGems.onClick.AddListener(chestController.OpenWithoutGems);
            SetTimerText(chestController.FormatTime(chestController.TimerText()));
        }

        void Update()
        {
            chestController.UpdateChest();
        }

        public void SetChestImage(Sprite image)
        {
            chestSprite.sprite = image;
        }

        public void SetGemsNeeded(int gems)
        {
            gemsButtonText.text = gems.ToString();
        }

        public void ShowConfirmationPanel()
        {
            confirmationPanel.SetActive(true);
        }

        public void OnClickButton()
        {
            chestController.OnClickChest();
        }

        public void SetTimerText(string time)
        {
            timerText.text = time;
        }

        public void DeactivateConfirmationPanel()
        {
            confirmationPanel.SetActive(false);
        }

        public void SetSuggestedText(string text)
        {
            suggestedText.text = text;
        }

        public void SetController(ChestController controller)
        {
            chestController = controller;
        }
    }
}


