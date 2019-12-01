using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHideObjects : MonoBehaviour
{
    public GameObject[] allObjects;
    public bool[] hidden;
    public GameObject looker;
    public GameObject cam;

    private void Start()
    {
        allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        bool[] x = new bool[allObjects.Length];
        hidden = x;
    }

    private void Update()
    {
        looker.transform.position = transform.position - (transform.forward * 5);
        looker.transform.rotation = Quaternion.LookRotation(transform.forward);
        for (int x = 0; x < allObjects.Length; x++)
        {
            GameObject go = allObjects[x];
            if (gameObject.tag == "Portal B")
            {
                if(go.layer == 12)
                {
                    go.layer = 11;
                }
                if (go.layer == 10)
                {
                    go.layer = 0;
                }
            }
            else
            {
                if (go.layer == 11)
                {
                    go.layer = 0;
                }
                if (go.layer == 12)
                {
                    go.layer = 10;
                }
            }
        }
        GameObject hideObject = looker.gameObject.GetComponent<PortalLooker>().doRaycast();
        for(int x = 0; x < allObjects.Length; x++)
        {
            if(hideObject == allObjects[x])
            {
                hidden[x] = true;
                if (gameObject.tag == "Portal B")
                {
                    if (GameObject.FindGameObjectWithTag("Portal A").GetComponent<PortalHideObjects>().hidden[x])
                    {
                        allObjects[x].layer = 12;
                    }
                    else
                    {
                        allObjects[x].layer = 10;
                    }
                }
                else
                {
                    if (GameObject.FindGameObjectWithTag("Portal B").GetComponent<PortalHideObjects>().hidden[x])
                    {
                        allObjects[x].layer = 12;
                    }
                    else
                    {
                        allObjects[x].layer = 11;
                    }
                }
            }
        }
        
    }
}
