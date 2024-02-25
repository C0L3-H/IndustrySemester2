using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoCameraTask : MonoBehaviour
{
    private CameraButton cameraButton;
//blackviewfinder is the black or default camera view 
    public GameObject blackViewFinder;
    private PlayerManager playerManager;


    // Start is called before the first frame update
    void Awake()
    {
        cameraButton = FindObjectOfType<CameraButton>();
        playerManager = FindObjectOfType<PlayerManager>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (cameraButton != null && cameraButton.CameraTaskActive && LookingAtCorrectObject())
        {
            blackViewFinder.SetActive(false);
        }
        else
        {
            blackViewFinder.SetActive(true);
            
        }

        
    }

    public bool LookingAtCorrectObject()
{
    if(playerManager != null)
    {
        switch(playerManager.currentPhotoIndex)
        {
            case 0:
                return playerManager.LookingAtObject1 && !playerManager.LookingAtObject2 && !playerManager.LookingAtObject3 && !playerManager.LookingAtObject4 && !playerManager.photosTaken[0];
            case 1:
                return !playerManager.LookingAtObject1 && playerManager.LookingAtObject2 && !playerManager.LookingAtObject3 && !playerManager.LookingAtObject4 && !playerManager.photosTaken[1];
            case 2:
                return !playerManager.LookingAtObject1 && !playerManager.LookingAtObject2 && playerManager.LookingAtObject3 && !playerManager.LookingAtObject4 && !playerManager.photosTaken[2];
            case 3:
                return !playerManager.LookingAtObject1 && !playerManager.LookingAtObject2 && !playerManager.LookingAtObject3 && playerManager.LookingAtObject4 && !playerManager.photosTaken[3];
            default:
                return false;
        }
    }
    return false;
    }
}
