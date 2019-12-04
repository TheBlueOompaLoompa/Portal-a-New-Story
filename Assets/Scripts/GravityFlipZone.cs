using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlipZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().gravity = -GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().gravity;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().velocity.y = 0;
            Debug.Log("Player Entered Filp");
        }
    }
}
