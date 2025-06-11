using System.Collections;
using System.Collections.Generic;
using ChestSystem.Chest;
using ChestSystem.UI;
using ChestSystem.Utilities;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public ChestService ChestService { get; private set; }
        [SerializeField] private UIService uIService;
        public UIService UIService { get { return uIService; } }

        [SerializeField] private GameObject chestPanel;
        [SerializeField] private ChestView chestView;
        [SerializeField] private List<ChestScriptableObject> chestScriptableObjects;

        private List<GameObject> slots;
        private List<ChestController> chests;
        private int gems;
        private int coins;
        private int slotCount;

        private void Start()
        {
            ChestService = new ChestService();

            Initialize();

            EventService.Instance.OnAddGems.AddListener(AddGems);
            EventService.Instance.OnAddCoins.AddListener(AddCoins);
            EventService.Instance.OnSubtractGems.AddListener(SubtractGems);
            EventService.Instance.OnCreateChests.AddListener(CreateChests);
        }

        public void CreateChests()
        {
            slots = UIService.ReturnSlots();
            slotCount = UIService.ReturnSlots().Count;

            if (GetSlots() >= slotCount)
            {
                EventService.Instance.OnNotEnoughSlots.InvokeEvent();
                return;
            }

            ChestScriptableObject randomChestData = Instantiate(chestScriptableObjects[Random.Range(0, chestScriptableObjects.Count)]);

            ChestService.CreateChest(randomChestData, chestView, slots[GetSlots()]);
        }

        public void Initialize()
        {
            gems = 0;
            coins = 0;
        }

        private int GetSlots()
        {
            for (int i = 0; i < slotCount; i++)
            {
                if (slots[i].transform.childCount == 0)
                {
                    return i;
                }
            }

            return slotCount;
        }

        public int GetGems()
        {
            return gems;
        }

        public void AddGems(int addGems)
        {
            gems += addGems;
            EventService.Instance.OnUpdateGems.InvokeEvent(gems);
        }

        public void SubtractGems(int subGems)
        {
            gems -= subGems;

            if (gems <= 0 || gems < subGems)
            {
                EventService.Instance.OnNotEnoughCoins.InvokeEvent();
                gems = 0;
            }

            EventService.Instance.OnUpdateGems.InvokeEvent(gems);
        }

        public void AddCoins(int addCoins)
        {
            coins += addCoins;
            EventService.Instance.OnUpdateCoins.InvokeEvent(coins);
        }

        private void OnDisable()
        {
            EventService.Instance.OnAddGems.RemoveListener(AddGems);
            EventService.Instance.OnAddCoins.RemoveListener(AddCoins);
            EventService.Instance.OnSubtractGems.RemoveListener(SubtractGems);
            EventService.Instance.OnCreateChests.RemoveListener(CreateChests);
        }
    }
}


