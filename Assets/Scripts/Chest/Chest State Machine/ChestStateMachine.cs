using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestStateMachine : GenericStateMachine<ChestController>
    {
        public ChestStateMachine(ChestController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        public void CreateStates()
        {
            States.Add(ChestState.Locked, new LockedState<ChestController>(this));
            States.Add(ChestState.Unlocked, new UnlockedState<ChestController>(this));
            States.Add(ChestState.Unlocking, new UnlockingState<ChestController>(this));
            States.Add(ChestState.Collected, new CollectedState<ChestController>(this));
        }
    }
}
