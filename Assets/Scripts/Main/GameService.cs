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
        }

        public void AddGems(int addGems)
        {
            gems += addGems;
            Debug.Log("Gems: " + gems);
        }

        public void AddCoins(int addCoins)
        {
            coins += addCoins;
            Debug.Log("Coins: " + coins);
        }
    }
}


