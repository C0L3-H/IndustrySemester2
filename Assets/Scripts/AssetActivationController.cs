using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is handleing the activation of the safe, teh diary and the zamzam bottle
public class AssetActivationController : MonoBehaviour
{
    private bool zamZamBottleIsActive = false;
     public GameObject safe;
    public GameObject keypad;
    public GameObject zamZamBottle;
    public GameObject diary;
    private PlayerManager playerManager;

    
    void Awake()
    {
        safe.SetActive(false);
        keypad.SetActive(false);
        zamZamBottle.SetActive(false);
        diary.SetActive(false);
    }

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerManager.photosTaken[3])
        {
            Debug.Log("4 Photos taken");
            diary.SetActive(true);
            safe.SetActive(true);

//flag is used to to make sure that the zamzam bottle is only activated once so when the when the player presses E
//to collect the bottle it will not be activated again 
            if(!zamZamBottleIsActive)
            {
                zamZamBottle.SetActive(true);
                zamZamBottleIsActive = true;
            }
        }
    }
}
