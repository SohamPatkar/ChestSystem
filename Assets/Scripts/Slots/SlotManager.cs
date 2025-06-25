using System.Collections.Generic;
using ChestSystem.Main;
using UnityEngine;

namespace ChestSystem.Slots
{
    public class SlotManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> slots;
        [SerializeField] private GameObject slotPrefab;
        [SerializeField] private GameObject chestPanel;

        void OnEnable()
        {
            EventService.Instance.OnAddSlots.AddListener(AddSlot);
        }

        void OnDisable()
        {
            EventService.Instance.OnAddSlots.RemoveListener(AddSlot);
        }

        public List<GameObject> ReturnSlots()
        {
            return slots;
        }

        private void AddSlot()
        {
            slots.Add(Instantiate(slotPrefab, chestPanel.transform));
        }

        public int GetSlots()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].transform.childCount == 0)
                {
                    return i;
                }
            }

            return slots.Count;
        }
    }
}


