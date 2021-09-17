using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCam : MonoBehaviour
{
    public Camera BattleCamera;
    
    public void switchcam(int x)
    {
        BattleCamera.enabled = true;
    }
}
