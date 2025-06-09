using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class EpicChestStateMachine : GenericStateMachine<EpicChest>
    {
        public EpicChestStateMachine(EpicChest Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        public void CreateStates()
        {
            States.Add(ChestState.Locked, new LockedState<EpicChest>(this));
            States.Add(ChestState.Unlocked, new UnlockedState<EpicChest>(this));
            States.Add(ChestState.Unlocking, new UnlockingState<EpicChest>(this));
            States.Add(ChestState.Collected, new CollectedState<EpicChest>(this));
        }
    }
}
