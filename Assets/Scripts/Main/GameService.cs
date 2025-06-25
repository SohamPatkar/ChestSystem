using System.Collections.Generic;
using ChestSystem.Chest;
using ChestSystem.Currency;
using ChestSystem.Slots;
using ChestSystem.UI;
using ChestSystem.Utilities;
using UnityEngine;


namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public ChestService ChestService { get; private set; }
        public UIService UIService { get { return uIService; } }
        public CurrencyService CurrencyService;
        public SlotManager SlotManager { get { return slotManager; } }

        [SerializeField] private UIService uIService;
        [SerializeField] private SlotManager slotManager;
        [SerializeField] private GameObject chestPanel;
        [SerializeField] private ChestView chestView;
        [SerializeField] private List<ChestScriptableObject> chestScriptableObjects;

        private List<GameObject> slots;
        private List<ChestController> chests;
        private int slotCount;

        private void Start()
        {
            CurrencyService = new CurrencyService();

            EventService.Instance.OnAddGems.AddListener(CurrencyService.AddGems);
            EventService.Instance.OnAddCoins.AddListener(CurrencyService.AddCoins);
            EventService.Instance.OnSubtractGems.AddListener(CurrencyService.SubtractGems);
            EventService.Instance.OnCreateChests.AddListener(CreateChests);

            ChestService = new ChestService();
        }

        public void CreateChests()
        {
            slots = SlotManager.ReturnSlots();
            slotCount = slots.Count;

            if (SlotManager.GetSlots() >= slotCount)
            {
                EventService.Instance.OnNotEnoughSlots.InvokeEvent();
                return;
            }

            ChestScriptableObject randomChestData = Instantiate(chestScriptableObjects[Random.Range(0, chestScriptableObjects.Count)]);

            ChestService.CreateChest(randomChestData, chestView, slots[SlotManager.GetSlots()]);
        }



        private void OnDisable()
        {
            EventService.Instance.OnAddGems.RemoveListener(CurrencyService.AddGems);
            EventService.Instance.OnAddCoins.RemoveListener(CurrencyService.AddCoins);
            EventService.Instance.OnSubtractGems.RemoveListener(CurrencyService.SubtractGems);
            EventService.Instance.OnCreateChests.RemoveListener(CreateChests);
        }
    }
}


