using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        float mouseSpeed = PlayerPrefs.GetFloat("Mouse Speed");
        if (mouseSpeed > 1f)
        {
            mouseSensitivity = mouseSpeed;
            Debug.Log(mouseSensitivity);
        }
        else
        {
            mouseSensitivity = 200f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        if (gameObject.GetComponent<PortalGrab>().isHolding)
        {
            xRotation = Mathf.Clamp(xRotation, -89f, 50f);
        }
        else 
        {
            xRotation = Mathf.Clamp(xRotation, -89f, 89f);
        }

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
