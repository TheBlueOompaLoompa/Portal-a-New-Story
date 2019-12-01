using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmancipationGrill : MonoBehaviour
{
    private PortalGrab pg;
    public bool player;
    public bool item;

    private void Start()
    {
        pg = Camera.main.GetComponent<PortalGrab>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "grab" && item) {
            pg.isHolding = false;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Player" && player)
        {
            Destroy(other.gameObject);
        }
    }
}
