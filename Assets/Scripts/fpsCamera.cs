using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsCamera : MonoBehaviour
{
   public float mouseSensitivity = 90f;
   private float leftRight;
   private float upDown;
    
    //public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        // Hide mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Taking mouse input
        leftRight += Time.deltaTime *mouseSensitivity * Input.GetAxis("Mouse X");
        upDown -= Time.deltaTime * mouseSensitivity * Input.GetAxis("Mouse Y");
        upDown = Mathf.Clamp(upDown, -90f, 90f);

        transform.eulerAngles = new Vector3(upDown, leftRight, 0.0f);
    }
}
