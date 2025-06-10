using System.Collections;
using System.Collections.Generic;
using ChestSystem.Chest;
using ChestSystem.UI;
using ChestSystem.Utilities;
using UnityEngine;

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
        private int gems;
        private int coins;

        private void Start()
        {
            foreach (ChestScriptableObject chest in chestScriptableObjects)
            {
                ChestService = new ChestService(chest, chestView, chestPanel);
            }

            EventService.Instance.OnAddGems.AddListener(AddGems);
            EventService.Instance.OnAddCoins.AddListener(AddCoins);
            EventService.Instance.OnSubtractGems.AddListener(SubtractGems);
        }

        public int GetGems()
        {
            return gems;
        }

        public void AddGems(int addGems)
        {
            gems += addGems;
            EventService.Instance.OnUpdateGems.InvokeEvent(gems);
            Debug.Log("Gems: " + addGems);
        }

        public void SubtractGems(int subGems)
        {
            gems -= subGems;

            if (gems < 0)
            {
                gems = 0;
            }
            EventService.Instance.OnUpdateGems.InvokeEvent(gems);
            Debug.Log("Gems: " + gems);
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
        }
    }
}


