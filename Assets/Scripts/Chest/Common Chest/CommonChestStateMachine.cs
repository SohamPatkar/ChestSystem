using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using Unity.Burst.Intrinsics;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class CommonChestStateMachine : GenericStateMachine<CommonChest>
    {
        public CommonChestStateMachine(CommonChest Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        public void CreateStates()
        {
            States.Add(ChestState.Locked, new LockedState<CommonChest>(this));
            States.Add(ChestState.Unlocked, new UnlockedState<CommonChest>(this));
            States.Add(ChestState.Unlocking, new UnlockingState<CommonChest>(this));
            States.Add(ChestState.Collected, new CollectedState<CommonChest>(this));
        }
    }
}


