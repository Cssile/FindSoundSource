using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightsGroup;

    // Méthode appelée lorsqu'on clique sur l'interrupteur
    public void ToggleLights()
    {
        // Inversez l'état actuel des lumières
        lightsGroup.SetActive(!lightsGroup.activeSelf);
    }
}

