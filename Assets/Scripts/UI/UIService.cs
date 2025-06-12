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
        [SerializeField] private GameObject chestPanel;
        [SerializeField] private TextMeshProUGUI gemsButtonText;
        [SerializeField] private TextMeshProUGUI coinsUIText;
        [SerializeField] private TextMeshProUGUI gemsUIText;
        [SerializeField] private GameObject notEnoughCoinsText;
        [SerializeField] private GameObject notEnoughSlotsText;
        [SerializeField] private GameObject QueueNotifier;
        [SerializeField] private TextMeshProUGUI QueueText;
        [SerializeField] private GameObject slotPrefab;
        [SerializeField] private List<GameObject> slots;

        private ChestController chestController;

        void Start()
        {
            EventService.Instance.OnSetGemsRequired.AddListener(SetGemsNeeded);
            EventService.Instance.OnShowConfirmationPanel.AddListener(ShowConfirmationPanel);
            EventService.Instance.OnUpdateGems.AddListener(SetGems);
            EventService.Instance.OnUpdateCoins.AddListener(SetCoins);
            EventService.Instance.OnNotEnoughSlots.AddListener(ShowNotEnoughSlotsText);
            EventService.Instance.OnNotEnoughCoins.AddListener(ShowNotEnoughCoinsText);
            EventService.Instance.OnQueueAction.AddListener(ShowQueueNotifier);
        }

        public List<GameObject> ReturnSlots() { return slots; }

        public void GetChestController(ChestController chestController) { this.chestController = chestController; }

        private void ShowNotEnoughCoinsText()
        {
            notEnoughCoinsText.SetActive(true);
            StartCoroutine(HideText(notEnoughCoinsText));
        }

        private void ShowQueueNotifier(string text)
        {
            QueueNotifier.SetActive(true);
            QueueText.text = text;
            StartCoroutine(HideText(QueueNotifier));
        }

        private void ShowNotEnoughSlotsText()
        {
            notEnoughSlotsText.SetActive(true);
            StartCoroutine(HideText(notEnoughSlotsText));
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
            coinsUIText.text = "" + coins;
        }

        private void SetGems(int gems)
        {
            gemsUIText.text = "" + gems;
        }

        public void CreateASlot()
        {
            slots.Add(Instantiate(slotPrefab, chestPanel.transform));
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

        public void CreateChests()
        {
            EventService.Instance.OnCreateChests.InvokeEvent();
        }

        public void UndoLastAction()
        {
            GameService.Instance.ChestService.UndoAction();
        }

        IEnumerator HideText(GameObject text)
        {
            yield return new WaitForSeconds(2f);
            text.SetActive(false);
        }

        void OnDisable()
        {
            EventService.Instance.OnSetGemsRequired.RemoveListener(SetGemsNeeded);
            EventService.Instance.OnShowConfirmationPanel.RemoveListener(ShowConfirmationPanel);
            EventService.Instance.OnUpdateGems.RemoveListener(SetGems);
            EventService.Instance.OnUpdateCoins.RemoveListener(SetCoins);
            EventService.Instance.OnNotEnoughCoins.RemoveListener(ShowNotEnoughCoinsText);
            EventService.Instance.OnNotEnoughSlots.RemoveListener(ShowNotEnoughSlotsText);
            EventService.Instance.OnQueueAction.RemoveListener(ShowQueueNotifier);
        }
    }
}


