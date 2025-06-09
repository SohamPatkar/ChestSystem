using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    [CreateAssetMenu(menuName = "CHESTSO")]
    public class ChestScriptableObject : ScriptableObject
    {
        public int Id;
        public string Name;
        public Sprite ChestClosed;
        public Sprite ChestOpen;
        public ChestType ChestType;
        public ChestState chestState;
        public int MaxCoins;
        public int MinCoins;
        public int MaxGems;
        public int MinGems;
        public int Timer;
    }
}


