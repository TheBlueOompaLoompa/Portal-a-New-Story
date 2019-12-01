using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObject : MonoBehaviour
{
    public Collider[] colliders;
    public bool isDuplicate;
    public bool inPortal;
    public bool enterPortal; // False is portal a  True is portal b

    private void Start()
    {
        colliders = gameObject.GetComponents<Collider>();
        if (isDuplicate)
        {
            foreach (Collider col in colliders)
            {
                col.isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inPortal = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inPortal = false;
    }

    public void moveThroughPortal()
    {
        foreach(Collider col in colliders)
        {
            col.isTrigger = true;
        }
    }

    public void movedThroughPortal()
    {
        foreach (Collider col in colliders)
        {
            if (isDuplicate)
            {
                Destroy(gameObject);
            }
            col.isTrigger = false;
        }
    }
}
