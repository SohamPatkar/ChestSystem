using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Utilities
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private T instance;

        public T Instance { get { return instance; } }

        void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}


