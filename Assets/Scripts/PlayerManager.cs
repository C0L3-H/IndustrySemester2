using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;  
    [SerializeField] private float rotationSpeed = 100f;  
    [SerializeField] private float jumpForce = 4f;  
    [SerializeField] private bool isGrounded;

    public bool[] photosTaken = new bool[5];
    public int currentPhotoIndex = 0;

    private Rigidbody rb;
    public float interactionRange = 10000f; 
    [SerializeField] private Camera playerPOVCamera;

    private CameraButton cameraButton;

    public bool LookingAtObject1 = false;
    public bool LookingAtObject2 = false;
    public bool LookingAtObject3 = false;
    public bool LookingAtObject4 = false;

  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraButton = FindObjectOfType<CameraButton>();
    }

    void FindPlayerPOVCamera()
    {
        playerPOVCamera = GameObject.Find("PlayerPOVCamera")?.GetComponent<Camera>();

        // Handle the case when the camera is still not found
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * verticalInput * moveSpeed;
        float rotationInput = horizontalInput * rotationSpeed;

        rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * rotationInput * Time.deltaTime));

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (playerPOVCamera == null)
        {
            // If the camera is still null, try to find it again
            FindPlayerPOVCamera();
        }

        if (playerPOVCamera != null && cameraButton != null && cameraButton.CameraTaskActive == true)
        {
            // Debug information for troubleshooting
            Debug.DrawRay(playerPOVCamera.transform.position, playerPOVCamera.transform.forward, Color.red, 0.1f);

            if (Physics.Raycast(playerPOVCamera.transform.position, playerPOVCamera.transform.forward, out RaycastHit hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                //checking if player is looking at objects with correct tag and depending on how many photos have been taken 

                if (hitObject.CompareTag("Mirror") && !photosTaken[0])
                {
                    Debug.Log("Player is looking at a mirror!");
                    LookingAtObject1 = true;
                }
                else if (hitObject.CompareTag("Fridge") && !photosTaken[1])
                {
                    Debug.Log("Player is looking at a Fridge!");
                    LookingAtObject2 = true;
                }
                 else if (hitObject.CompareTag("Bed") && !photosTaken[2])
                {
                    Debug.Log("Player is looking at a Bed!");
                    LookingAtObject3 = true;
                }
                else if (hitObject.CompareTag("Window") && !photosTaken[3])
                {
                    Debug.Log("Player is looking at a window!");
                    LookingAtObject4 = true;
                    //Setting safe and bottle active when play
                }
                else 
                {
                    LookingAtObject1 = false;
                    LookingAtObject2 = false;
                    LookingAtObject3 = false;
                    LookingAtObject4 = false;
                }    
            }
        }
    }

    public void PhotoHasBeenTaken(int index)
    {
        if(index >= 0 && index < photosTaken.Length)
        {
            photosTaken[index] = true;
        }
    }
}

