using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public GameObject doorOpen;
    public GameObject doorClosed;
    public bool[] activators;
    public bool isAllTrue = true;
    public Utilities util;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isAllTrue = true;
        for (int i = 0; i < activators.Length; i++)
        {
            if (!activators[i])
            {
                isAllTrue = false;
            }
        }

        if (isAllTrue)
        {
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
        }
        else
        {
            doorClosed.SetActive(true);
            doorOpen.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            util.loadNextLevel();
        }
    }
}
