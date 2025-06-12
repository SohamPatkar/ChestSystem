using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public interface IUndoAction
    {
        void Undo();
        ChestController GetChestController();
    }
}


