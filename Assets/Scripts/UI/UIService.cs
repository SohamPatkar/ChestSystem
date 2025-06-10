using ChestSystem.Chest;
using ChestSystem.Main;
using TMPro;
using UnityEngine;

namespace ChestSystem.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private GameObject confirmationPanel;
        [SerializeField] private TextMeshProUGUI gemsButtonText;
        [SerializeField] private TextMeshProUGUI coinsUIText;
        [SerializeField] private TextMeshProUGUI gemsUIText;
        private ChestController chestController;

        void Start()
        {
            EventService.Instance.OnSetGemsRequired.AddListener(SetGemsNeeded);
            EventService.Instance.OnShowConfirmationPanel.AddListener(ShowConfirmationPanel);
            EventService.Instance.OnAddGems.AddListener(SetGems);
            EventService.Instance.OnAddCoins.AddListener(SetCoins);
        }

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
            gemsButtonText.text = gems.ToString();
        }

        public void SetCoins(int coins)
        {
            coinsUIText.text = "Coins: " + coins;
        }

        public void SetGems(int gems)
        {
            gemsUIText.text = "Gems: " + gems;
        }

        public void OpenChestWithoutGems()
        {
            confirmationPanel.SetActive(false);
            chestController?.ChangeChestState(ChestState.Unlocking);
            chestController?.MoveToState(ChestState.Unlocking);
        }

        public void OpenChestWithGems()
        {
            confirmationPanel.SetActive(false);
            chestController?.ChangeChestState(ChestState.Unlocked);
            chestController?.MoveToState(ChestState.Unlocked);
            EventService.Instance.OnSubtractGems.InvokeEvent(chestController.GetGemsRequired());
            SetGems(GameService.Instance.GetGems());
        }

        void OnDisable()
        {
            EventService.Instance.OnSetGemsRequired.RemoveListener(SetGemsNeeded);
            EventService.Instance.OnShowConfirmationPanel.RemoveListener(ShowConfirmationPanel);
            EventService.Instance.OnAddGems.RemoveListener(SetGems);
            EventService.Instance.OnAddCoins.RemoveListener(SetCoins);
        }
    }
}


