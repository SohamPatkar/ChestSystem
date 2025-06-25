using ChestSystem.Main;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class UnlockingState : IState
    {
        public ChestController Owner { get; set; }
        private ChestStateMachine stateMachine;
        private float timer;

        public UnlockingState(ChestStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState()
        {
            ResetTimer();
            Owner.GetChestView().SetSuggestedText("Opening");
        }

        private void ResetTimer()
        {
            timer = Owner.chestScriptableObject.Timer * 60f;
        }

        private void Timer()
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = 0f;
            }

            Owner.GetChestView().SetTimerText(Owner.FormatTime(timer));
        }

        public void OnExitState()
        {

        }

        public void Update()
        {
            Timer();

            if (timer <= 0f)
            {
                stateMachine.ChangeState(ChestState.Unlocked);
                GameService.Instance.ChestService.PushUndo(new UndoUnlocked(Owner));
                GameService.Instance.ChestService.OnChestUnlocked(Owner);
            }
        }

        public void OnClick()
        {

        }
    }
}


