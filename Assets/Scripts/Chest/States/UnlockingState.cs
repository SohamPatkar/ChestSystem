using System.Collections;
using System.Collections.Generic;
using ChestSystem.Utilities;
using ChestSystem.Main;
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
            Owner.GetChestView().SetTimerText(FormatTime(timer));
        }

        private string FormatTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void OnExitState()
        {
            GameService.Instance.ChestService.RemoveChest(Owner);
        }

        public void Update()
        {
            Timer();

            if (timer <= 0f)
            {
                timer = 0f;
                stateMachine.ChangeState(ChestState.Unlocked);
                GameService.Instance.ChestService.OnChestUnlocked(Owner);
            }
        }
    }
}


