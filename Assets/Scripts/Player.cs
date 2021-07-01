using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private Transform camera1PP = null;

    private Rigidbody playerBody;

    private bool jumpKeyWasPressed = false;
    private bool jumpIsLocked = false;
    [SerializeField] private float jumpImpulseFactor = 5;
    [SerializeField] private float gravityFactor = 2;
    private bool isFelt;

    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float speedFactor = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Prevent double jump in the air
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            //return;
            jumpIsLocked = true;
        }
        else
        {
            jumpIsLocked = false;
        }

        //Bring you back on the battle field
         if (isFelt)
        {
            playerBody.position = new Vector3(0, 5, 0);
            isFelt = false;
        }

         // Jumping command
        if (Input.GetKeyDown(KeyCode.Space) && !jumpIsLocked)
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = speedFactor * Input.GetAxis("Horizontal");
        verticalInput = speedFactor * Input.GetAxis("Vertical");
        
        Vector3 newRotation = new Vector3(0, camera1PP.transform.eulerAngles.y,0);
        Debug.Log(camera1PP.transform.eulerAngles.y);
        playerBody.transform.eulerAngles = newRotation;


    }

    private void FixedUpdate()
    {
        //Player movements
        playerBody.velocity = new Vector3(horizontalInput, playerBody.velocity.y, playerBody.velocity.z);
        playerBody.velocity = new Vector3(playerBody.velocity.x, playerBody.velocity.y, verticalInput);
        

        if (jumpKeyWasPressed)
        {
            playerBody.velocity = new Vector3(playerBody.velocity.x, playerBody.velocity.y * gravityFactor, playerBody.velocity.z);
            playerBody.AddForce(Vector3.up * jumpImpulseFactor, ForceMode.Impulse);
            jumpKeyWasPressed = false;
        }
    }

}
