using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script handles the interaction (collecting) of the zamzam bottle 

//attatched to the zamzam bottle game object
public class ZamZamBottle : MonoBehaviour
{
    private SafeManager safeManager;
    void Start()
    {
        //accessing safe manager script
        safeManager = FindObjectOfType<SafeManager>();
    }

 
    void Update()
    {
        //when the correct code has been entered and E is pressed the zamzam bottle will be inactivated 
        if(Input.GetKeyDown(KeyCode.E) && safeManager !=null)
        {
            if(safeManager.codeTextValue == safeManager.safeCode)
            {
                Debug.Log("ZamZambottle deactivated");
                gameObject.SetActive(false);
            }
        }
    }
}
