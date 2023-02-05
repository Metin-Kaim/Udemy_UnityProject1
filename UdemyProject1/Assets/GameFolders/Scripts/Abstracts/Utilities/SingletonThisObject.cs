using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Managers;
using UnityEngine;

namespace UdemyProject1.Abstracts.Utilities
{
    public abstract class SingletonThisObject<T> : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected void SingletonThisGameObject(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }

}
