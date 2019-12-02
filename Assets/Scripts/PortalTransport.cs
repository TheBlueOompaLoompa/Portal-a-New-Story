using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTransport : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {/*
        if(collision.gameObject.GetComponent<PortalObject>() != null)
        {
            movingObject = collision.gameObject;
            portalObject = collision.gameObject.GetComponent<PortalObject>();
            portalObject.moveThroughPortal();
        }
        */
        Debug.Log(collision.gameObject.tag);

        if(collision.gameObject.tag == "Player") // The portal mechanic is not working yet so this is the version for making puzzles.
        {
            if(gameObject.tag == "Portal A")
            {
                collision.transform.position = GameObject.FindGameObjectWithTag("Portal B").transform.position + GameObject.FindGameObjectWithTag("Portal B Point").transform.localPosition;
                collision.transform.rotation = Quaternion.Euler(collision.transform.rotation.eulerAngles + (GameObject.FindGameObjectWithTag("Portal B").transform.rotation.eulerAngles + transform.rotation.eulerAngles) + new Vector3(0, 180, 0));
            }
            else
            {

            }
        }
    }
}
