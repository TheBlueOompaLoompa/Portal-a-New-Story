using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTop : MonoBehaviour
{
    bool pressed;
    public Transform ButtonThing;
    public LevelExit le;
    int trigger;
    private void OnTriggerStay(Collider other)
    {
        if (!pressed) 
        {
            ButtonThing.position = ButtonThing.position + new Vector3(0, -0.203f, 0);
            pressed = true;
            le.activators[trigger] = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (pressed)
        {
            ButtonThing.position = ButtonThing.position + new Vector3(0, 0.203f, 0);
            pressed = false;
            le.activators[trigger] = false;
        } 

    }
}