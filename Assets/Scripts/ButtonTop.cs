using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTop : MonoBehaviour
{
    bool pressed;
    public Transform ButtonThing;
    private void OnTriggerStay(Collider other)
    {
        if (!pressed) 
        {
            ButtonThing.position = ButtonThing.position + new Vector3(0, -0.25f, 0);
            pressed = true;
        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (pressed)
        {
            ButtonThing.position = ButtonThing.position + new Vector3(0, 0.25f, 0);
            pressed = false;
        } 

    }
}