using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLooker : MonoBehaviour
{
    public GameObject doRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }
}
