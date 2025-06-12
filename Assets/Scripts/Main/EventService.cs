using System.Collections;
using System.Collections.Generic;
using ChestSystem.Chest;
using ChestSystem.Events;
using UnityEngine;

namespace ChestSystem.Main
{
    public class EventService
    {
        private static EventService instance;

        public static EventService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventService();
                }
                return instance;
            }
        }

        public EventController OnCreateChests { get; private set; }
        public EventController OnNotEnoughCoins { get; private set; }
        public EventController OnNotEnoughSlots { get; private set; }
        public EventController OnShowConfirmationPanel { get; private set; }
        public EventController<string> OnQueueAction { get; private set; }
        public EventController<int> OnSetGemsRequired { get; private set; }
        public EventController<int> OnAddGems { get; private set; }
        public EventController<int> OnAddCoins { get; private set; }
        public EventController<int> OnSubtractGems { get; private set; }
        public EventController<int> OnUpdateCoins { get; private set; }
        public EventController<int> OnUpdateGems { get; private set; }
        public EventController<ChestController> OnOpenWithoutGems { get; private set; }
        public EventController<ChestController> OnOpenWithGems { get; private set; }

        public EventService()
        {
            OnCreateChests = new EventController();
            OnNotEnoughCoins = new EventController();
            OnNotEnoughSlots = new EventController();
            OnShowConfirmationPanel = new EventController();
            OnSetGemsRequired = new EventController<int>();
            OnAddCoins = new EventController<int>();
            OnAddGems = new EventController<int>();
            OnSubtractGems = new EventController<int>();
            OnUpdateCoins = new EventController<int>();
            OnUpdateGems = new EventController<int>();
            OnQueueAction = new EventController<string>();
            OnOpenWithGems = new EventController<ChestController>();
            OnOpenWithoutGems = new EventController<ChestController>();
        }

    }
}


