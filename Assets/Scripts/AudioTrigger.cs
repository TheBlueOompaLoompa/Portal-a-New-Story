using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private bool isTriggered;
    public AudioClip ac;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonPlayer")
        {
            if (!isTriggered)
            {
                isTriggered = true;
                other.gameObject.GetComponent<AudioSource>().clip = ac;
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
