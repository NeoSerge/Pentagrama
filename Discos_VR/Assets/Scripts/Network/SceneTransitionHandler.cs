using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionHandler : MonoBehaviour
{
    public static SceneTransitionHandler inst;

    public bool initializeAsHost;
    private void Awake()
    {
        if (SceneTransitionHandler.inst == null)
        {
            //primera vez. esta es la unica instancia
            SceneTransitionHandler.inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ya hay una instancia eliminar
            Destroy(gameObject);
        }      
    }
}
