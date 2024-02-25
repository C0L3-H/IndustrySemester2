using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    //referencing gameobject 
    public GameObject textOneOBJ;
    public GameObject textTwoOBJ;
    public GameObject textThreeOBJ;
    public GameObject textFourOBJ;
    

    //referencing text component (can be changed to image if preffered)
    public TMP_Text textOne;
    public TMP_Text textTwo;
    public TMP_Text textThree;
    public TMP_Text textFour;
    private PlayerManager playerManager;
    

    
    void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        textOne = textOneOBJ.GetComponent<TMP_Text>();
        textTwo = textTwoOBJ.GetComponent<TMP_Text>();
        textThree = textThreeOBJ.GetComponent<TMP_Text>();
        textFour = textFourOBJ.GetComponent<TMP_Text>();
        
        //ensuring all text components are disabled at the begining of the game 
        if (textOne !=null && textTwo !=null && textThree !=null && textFour !=null)
        {
            textOne.enabled = false;
            textTwo.enabled = false;
            textThree.enabled = false;
            textFour.enabled = false;
            
        }
    }
    public void OnButtonClick()
    {
        if (playerManager !=null && textOne != null)
        {
    
            int currentPhotoIndex = playerManager.currentPhotoIndex;
            
        

            if(currentPhotoIndex == 1)
            {   
                
                Debug.Log("currentPhotoIndex is 1");
                textOne.enabled = true;
            }
            else if(currentPhotoIndex != 1)
            {
            textOne.enabled = false;
            }

            if(currentPhotoIndex == 2)
            {
            
                Debug.Log("currentPhotoIndex is 2");
                textTwo.enabled = true;
            }
            else if(currentPhotoIndex != 2)
            {
            textTwo.enabled = false;
            Debug.Log("currentPhotoIndex is not 2");
            }
            
            if(currentPhotoIndex == 3)
            {
            
                Debug.Log("currentPhotoIndex is 3");
                textThree.enabled = true;
            }
            else if(currentPhotoIndex != 3)
            {
            textThree.enabled = false;
            Debug.Log("currentPhotoIndex is not 3");
            }

            if(currentPhotoIndex == 4)
            {
            
                Debug.Log("currentPhotoIndex is 4");
                textFour.enabled = true;
            }
            else if(currentPhotoIndex != 4)
            {
            textFour.enabled = false;
            Debug.Log("currentPhotoIndex is not 4");
            }

        }
        else
        {
            Debug.LogWarning("OnButtonClickNotWorking");
        }
    
    }

}
