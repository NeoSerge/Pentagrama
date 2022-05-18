using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkStartup : MonoBehaviour
{
    void Start()
    {
       if (SceneTransitionHandler.inst.initializeAsHost)
       {
            NetworkManager.Singleton.StartHost();
       }
       else
       {
            NetworkManager.Singleton.StartClient();
       }
    }
}
