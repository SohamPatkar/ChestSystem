using System.Collections;
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
        [SerializeField] private GameObject notEnoughCoinsText;
        private ChestController chestController;

        void Start()
        {
            EventService.Instance.OnSetGemsRequired.AddListener(SetGemsNeeded);
            EventService.Instance.OnShowConfirmationPanel.AddListener(ShowConfirmationPanel);
            EventService.Instance.OnUpdateGems.AddListener(SetGems);
            EventService.Instance.OnUpdateCoins.AddListener(SetCoins);
            EventService.Instance.OnNotEnoughCoins.AddListener(ShowNotEnoughCoinsText);
        }

        public void GetChestController(ChestController chestController)
        {
            this.chestController = chestController;
        }

        private void ShowNotEnoughCoinsText()
        {
            notEnoughCoinsText.SetActive(true);
            StartCoroutine(HideNotEnoughCoinsText());
        }

        private void ShowConfirmationPanel()
        {
            confirmationPanel.SetActive(true);
        }

        private void SetGemsNeeded(int gems)
        {
            gemsButtonText.text = gems.ToString();
        }

        private void SetCoins(int coins)
        {
            coinsUIText.text = "Coins: " + coins;
        }

        private void SetGems(int gems)
        {
            gemsUIText.text = "Gems: " + gems;
        }

        public void OpenChestWithoutGems()
        {
            confirmationPanel.SetActive(false);
            EventService.Instance.OnOpenWithoutGems.InvokeEvent(chestController);
        }

        public void OpenChestWithGems()
        {
            confirmationPanel.SetActive(false);
            EventService.Instance.OnOpenWithGems.InvokeEvent(chestController);
        }

        IEnumerator HideNotEnoughCoinsText()
        {
            yield return new WaitForSeconds(2f);
            notEnoughCoinsText.SetActive(false);
        }

        void OnDisable()
        {
            EventService.Instance.OnSetGemsRequired.RemoveListener(SetGemsNeeded);
            EventService.Instance.OnShowConfirmationPanel.RemoveListener(ShowConfirmationPanel);
            EventService.Instance.OnUpdateGems.RemoveListener(SetGems);
            EventService.Instance.OnUpdateCoins.RemoveListener(SetCoins);
            EventService.Instance.OnNotEnoughCoins.RemoveListener(ShowNotEnoughCoinsText);
        }
    }
}


