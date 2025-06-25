using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public interface IState
    {
        public ChestController Owner { get; set; }

        public void OnEnterState();
        public void OnExitState();
        public void Update();
        void OnClick();
    }
}


