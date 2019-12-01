using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTransport : MonoBehaviour
{
    private Transform pmove;
    private GameObject movingObject;
    PortalObject portalObject;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach(GameObject go in allObjects)
        {
            if(go.name == "Pmove")
            {
                pmove = go.GetComponent<Transform>();
                break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PortalObject>() != null)
        {
            movingObject = collision.gameObject;
            portalObject = collision.gameObject.GetComponent<PortalObject>();
            portalObject.moveThroughPortal();
        }
    }

    bool spawnedDupe;

    public void dupeExit()
    {
        spawnedDupe = false;
        portalObject.movedThroughPortal();
    }

    GameObject dupe; //Duplicate

    private void Update()
    {
        if(movingObject != null && !spawnedDupe)
        {
            dupe = Instantiate(movingObject);
            dupe.GetComponent<PortalObject>().isDuplicate = true;
            spawnedDupe = true;
        }
        if (spawnedDupe)
        {
            Debug.Log("dupe");
            if(gameObject.tag == "Portal A" && !portalObject.enterPortal)
            {
                Vector3 crossProd = new Vector3();
                crossProd.x = (gameObject.transform.position - GameObject.FindGameObjectWithTag("Portal B").transform.position).x * transform.forward.z;
                crossProd.y = -(gameObject.transform.position - GameObject.FindGameObjectWithTag("Portal B").transform.position).y * transform.forward.y;
                crossProd.z = (gameObject.transform.position - GameObject.FindGameObjectWithTag("Portal B").transform.position).z * transform.forward.x;

                dupe.transform.right = new Vector3(1, 0, 0);
                dupe.transform.position = portalObject.transform.position + crossProd;
                dupe.transform.rotation = Quaternion.Euler(portalObject.transform.rotation.eulerAngles + (GameObject.FindGameObjectWithTag("Portal B").transform.rotation.eulerAngles - gameObject.transform.rotation.eulerAngles) + new Vector3(0, 180, 0));
                Debug.Log(dupe.transform.right);
            }
        }
    }
}
