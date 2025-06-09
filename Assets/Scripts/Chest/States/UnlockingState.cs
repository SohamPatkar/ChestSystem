using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class UnlockingState<T> : IState where T : ChestController
    {
        public ChestController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private float timer;

        public UnlockingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState()
        {
            ResetTimer();
        }

        private void ResetTimer()
        {
            timer = Owner.chestScriptableObject.Timer * 60f;
        }

        private void Timer()
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }

        public void OnExitState()
        {

        }

        public void Update()
        {
            Timer();

            if (timer <= 0)
            {
                stateMachine.ChangeState(ChestState.Unlocked);
            }
        }
    }
}


