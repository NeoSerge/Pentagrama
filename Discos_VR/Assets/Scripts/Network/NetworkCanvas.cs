using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCanvas : MonoBehaviour
{
    public void InitializeAsHost(bool host)
    {
        SceneTransitionHandler.inst.initializeAsHost = host;
    }
}
