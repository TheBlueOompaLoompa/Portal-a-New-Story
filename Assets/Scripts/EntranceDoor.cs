using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    public GameObject doorOpen;
    public GameObject doorClosed;
    bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorClosed.SetActive(true);
        doorOpen.SetActive(false);
        triggered = true;
    }
}
