using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    public GameObject doorOpen;
    public GameObject doorClosed;

    private void OnTriggerEnter(Collider other)
    {
        doorClosed.SetActive(false);
        doorOpen.SetActive(true);
    }
}
