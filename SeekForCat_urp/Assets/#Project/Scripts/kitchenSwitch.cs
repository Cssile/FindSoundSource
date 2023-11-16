using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenSwitch : MonoBehaviour
{
    public Light kitchenLight;

      private void Start()
    {
        //lumière éteinte au début 
        kitchenLight.enabled = false;
    }

    private void OnMouseDown()
    {

        kitchenLight.enabled = !kitchenLight.enabled;
    }
}
