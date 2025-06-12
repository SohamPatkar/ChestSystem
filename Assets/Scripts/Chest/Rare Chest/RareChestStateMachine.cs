using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class RareChestStateMachine : GenericStateMachine<RareChest>
    {
        public RareChestStateMachine(RareChest Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        public void CreateStates()
        {
            States.Add(ChestState.Locked, new LockedState<RareChest>(this));
            States.Add(ChestState.Unlocked, new UnlockedState<RareChest>(this));
            States.Add(ChestState.Unlocking, new UnlockingState<RareChest>(this));
            States.Add(ChestState.Collected, new CollectedState<RareChest>(this));
        }
    }
}
