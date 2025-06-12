using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class LegendaryChestStateMachine : GenericStateMachine<LegendaryChest>
    {
        public LegendaryChestStateMachine(LegendaryChest Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        public void CreateStates()
        {
            States.Add(ChestState.Locked, new LockedState<LegendaryChest>(this));
            States.Add(ChestState.Unlocked, new UnlockedState<LegendaryChest>(this));
            States.Add(ChestState.Unlocking, new UnlockingState<LegendaryChest>(this));
            States.Add(ChestState.Collected, new CollectedState<LegendaryChest>(this));
        }
    }
}

