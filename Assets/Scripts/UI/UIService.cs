using System.Collections;
using ChestSystem.Main;
using TMPro;
using UnityEngine;

namespace ChestSystem.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsUIText;
        [SerializeField] private TextMeshProUGUI gemsUIText;
        [SerializeField] private GameObject notEnoughCoinsText;
        [SerializeField] private GameObject notEnoughSlotsText;
        [SerializeField] private GameObject QueueNotifier;
        [SerializeField] private TextMeshProUGUI QueueText;

        void Start()
        {
            EventService.Instance.OnUpdateGems.AddListener(SetGems);
            EventService.Instance.OnUpdateCoins.AddListener(SetCoins);
            EventService.Instance.OnNotEnoughSlots.AddListener(ShowNotEnoughSlotsText);
            EventService.Instance.OnNotEnoughCoins.AddListener(ShowNotEnoughCoinsText);
            EventService.Instance.OnQueueAction.AddListener(ShowQueueNotifier);
        }

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
            EventService.Instance.OnAddSlots.InvokeEvent();
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
            EventService.Instance.OnUpdateGems.RemoveListener(SetGems);
            EventService.Instance.OnUpdateCoins.RemoveListener(SetCoins);
            EventService.Instance.OnNotEnoughCoins.RemoveListener(ShowNotEnoughCoinsText);
            EventService.Instance.OnNotEnoughSlots.RemoveListener(ShowNotEnoughSlotsText);
            EventService.Instance.OnQueueAction.RemoveListener(ShowQueueNotifier);
        }
    }
}


