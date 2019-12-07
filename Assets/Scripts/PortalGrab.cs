using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGrab : MonoBehaviour
{
    public bool isHolding;
    public Transform holdPoint;
    private GameObject objectToHold;
    public Vector3 velocityOfObject;
    public Transform portalA;
    public Transform portalB;

    void Update()
    {
        if (isHolding)
        {
            if(Vector3.Distance(holdPoint.position, objectToHold.transform.position) > 2f)
            {
                isHolding = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isHolding)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if (hit.collider.gameObject.tag == "grab" && hit.distance < 4.5)
                    {
                        objectToHold = hit.collider.gameObject;
                        isHolding = true;
                    }
                }
            }
            else
            {
                isHolding = false;
            }
            
        }

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if(hit.collider.gameObject.GetComponent<PortalSurface>() != null)
                {
                    portalA.position = hit.point;
                    portalA.rotation = Quaternion.LookRotation(hit.collider.gameObject.GetComponent<PortalSurface>().direction);
                }
                if (hit.collider.gameObject.tag == "Portal A")
                {
                    portalA.position = new Vector3(0, 0, 0);
                    portalA.forward = new Vector3(0, -1, 0);
                    portalA.position = hit.point;
                    portalA.forward = -hit.collider.gameObject.transform.forward;
                }
                if (hit.collider.gameObject.tag == "Portal B")
                {
                    portalB.position = new Vector3(0, 0, 0);
                    portalB.forward = new Vector3(0, -1, 0);
                    portalA.position = hit.point;
                    portalA.forward = -hit.collider.gameObject.transform.forward;
                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.gameObject.GetComponent<PortalSurface>() != null)
                {
                    portalB.position = hit.point;
                    portalB.rotation = Quaternion.LookRotation(hit.collider.gameObject.GetComponent<PortalSurface>().direction);
                }
                if (hit.collider.gameObject.tag == "Portal A")
                {
                    portalA.position = new Vector3(0, 0, 0);
                    portalA.forward = new Vector3(0, -1, 0);
                    portalB.position = hit.point;
                    portalB.forward = -hit.collider.gameObject.transform.forward;
                }
                if (hit.collider.gameObject.tag == "Portal B")
                {
                    portalB.position = new Vector3(0, 0, 0);
                    portalB.forward = new Vector3(0, -1, 0);
                    portalB.position = hit.point;
                    portalB.forward = -hit.collider.gameObject.transform.forward;
                }
            }
        }

    }

    private void FixedUpdate()
    {
        if (isHolding)
        {
            objectToHold.GetComponent<Rigidbody>().velocity = (holdPoint.position - objectToHold.transform.position) * 60;
            velocityOfObject = objectToHold.GetComponent<Rigidbody>().velocity;
            objectToHold.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
