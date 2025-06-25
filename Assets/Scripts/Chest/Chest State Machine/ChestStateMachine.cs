using System.Collections.Generic;


namespace ChestSystem.Chest
{
    public class ChestStateMachine
    {
        protected ChestController Owner;
        protected IState currentState;
        protected Dictionary<ChestState, IState> States = new Dictionary<ChestState, IState>();

        public ChestStateMachine(ChestController Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        public void CreateStates()
        {
            States.Add(ChestState.Locked, new LockedState(this));
            States.Add(ChestState.Unlocked, new UnlockedState(this));
            States.Add(ChestState.Unlocking, new UnlockingState(this));
            States.Add(ChestState.Collected, new CollectedState(this));
        }

        public void Update() => currentState?.Update();

        public IState GetState()
        {
            return currentState;
        }

        public void ChangeState(ChestState newState) => ChangeState(States[newState]);

        private void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }

        protected void ChangeState(IState newState)
        {
            currentState?.OnExitState();
            currentState = newState;
            currentState?.OnEnterState();
        }
    }
}
